using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyChoose.Models;
using Microsoft.EntityFrameworkCore;
using MyChoose.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyChoose.Controllers
{
    [Route("api/[controller]")]
    public class AdminGiftController : Controller
    {
        private readonly GiftContext _context;
        public AdminGiftController(GiftContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var gifts = new List<GiftView>();
            var prices = _context.Prices.Select(p => p.Value).OrderBy(v => v).ToList();
            var categories = _context.Categories.Select(c => c.CategoryName).OrderBy(c => c).ToList();
            var dataGifts = _context.Gifts.Include(g => g.PriceFrom).Include(g => g.PriceTo).Include(g => g.CategoryDetails).ThenInclude(c => c.Category).ToList();
            foreach (var gift in dataGifts)
            {
                var giftView = new GiftView
                {
                    Id = gift.Id,
                    Name = gift.GiftName,
                    CreateDate = gift.CreateDate,
                    UpdateDate = gift.UpdateDate,
                    PriceFrom = gift.PriceFrom.Value,
                    PriceTo = gift.PriceTo.Value,
                    Categories = gift.CategoryDetails.Select(c => c.Category.CategoryName).ToList()
                };
                gifts.Add(giftView);
            }
            return Ok(new { Gifts = gifts, Prices = prices, Categories = categories });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
