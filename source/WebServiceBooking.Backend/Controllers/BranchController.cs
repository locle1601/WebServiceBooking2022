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
