using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyChoose.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyChoose.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly GiftContext _context;
        public DataController(GiftContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var count = _context.Gifts.Count();
            var random = new Random().Next(1,count+1);
            var result = await _context.Gifts.FindAsync(random);
            return Ok(new { gift = result.GiftName });
        }
    }
}
