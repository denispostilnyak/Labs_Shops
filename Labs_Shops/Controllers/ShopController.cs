using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs_Shops.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labs_Shops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly Labs2_Context _context;
        public ShopController(Labs2_Context context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShop() {
            return await _context.Shops.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShop(int? id) {
            return await _context.Shops.Where(c => c.Id == id).ToListAsync();
        }
        [HttpPost]
        public void PostShop([FromBody]Shop Shop) {
            _context.Shops.Add(Shop);
            _context.SaveChanges();
        }
        [HttpDelete]
        public ActionResult DeleteShop(int? id) {
            Shop cat = _context.Shops.Where(c => c.Id == id).FirstOrDefault();
            if (cat != null) {
                _context.Shops.Remove(cat);
                _context.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }

        }
        [HttpPut]
        public ActionResult ChangeShop(int? id, [FromBody]Shop cat) {
            var check = _context.Categories.Any(c => c.Id == id);
            if (check) {
                Category categoryBefore = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
                _context.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }
        }
    }
}