using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBooking.Backend.Data;

namespace WebServiceBooking.Backend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly WebDBContext _context;

        public IndexModel(ILogger<IndexModel> logger, WebDBContext _ct)
        {
            _logger = logger;
            _context = _ct;
        }

        public void OnGet()
        {

        }
    }
}
