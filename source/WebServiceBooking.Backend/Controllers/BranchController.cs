using KnowledgeSpace.BackendServer.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBooking.Backend.Data;
using WebServiceBooking.Data.Entities;
using WebServiceBooking.ViewModels.Contents;

namespace WebServiceBooking.Backend.Controllers
{
    public class BranchController : BaseController
    {
        private readonly WebDBContext _context;
        public BranchController(WebDBContext context)
        {
            _context = context;
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostBranch([FromBody]  BranchCreateRequest request)
        {
            var branch = new Branch()
            {
                Id = request.BranchID,
                BranchCode = request.BranchCode,
                BranchName = request.BranchName,
                Address = request.Address,
                MyHotelRestaurantID = request.MyHotelRestaurantID
            };
            _context.Branches.Add(branch);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetAllBranches), request);
            }
            else
            {
                return BadRequest();
            }
        }

        //GETAll
        public async Task<ActionResult> GetAllBranches()
        {
            var br = await _context.Branches.ToListAsync();

            //var brVm = br.Select(b => new BranchVm()
            //{
            //    BranchID=b.BranchID,
            //    BranchCode = b.BranchCode,
            //    BranchName=b.BranchName
            //}
            //
            var brVm = br.Select(c => branchVm(c)).ToList();
            return Ok(brVm);

        }
        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, [FromBody] BranchCreateRequest request)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (id == null)
                return NotFound(new ApiNotFoundResponse($" Your Branch: id = {id} is not found")); // 400

            branch.Id = request.BranchID;
            branch.BranchCode = request.BranchCode;
            branch.BranchName = request.BranchName;
            branch.Address = request.Address;

            _context.Branches.Update(branch);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetAllBranches), request);
            }
            else
            {
                return BadRequest();
            }
        }

        //



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await _context.Branches.FindAsync(id);

            if (branch == null)
                return NotFound(new ApiNotFoundResponse($" Your Branch: id = {id} is not found")); // 400

            _context.Branches.Remove(branch);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                BranchVm vm = branchVm(branch);  // return: user.info by deleted
                return Ok(vm);
            };            
            return BadRequest();
        }
        private static BranchVm branchVm(Branch br)
        {
            return new BranchVm()
            {
                BranchID = br.BranchID,
                BranchCode = br.BranchCode,
                BranchName = br.BranchName
            };
        }
    }
}
