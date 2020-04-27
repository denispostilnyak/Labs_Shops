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
    public class SellerController : ControllerBase
    {
        private readonly Labs2_Context _context;
        public SellerController(Labs2_Context context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSeller() {
            return await _context.Sellers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSeller(int? id) {
            return await _context.Sellers.Where(c => c.Id == id).ToListAsync();
        }
        [HttpPost]
        public void PostSeller([FromBody]Seller sell) {
            _context.Sellers.Add(sell);
            _context.SaveChanges();
        }
        [HttpDelete]
        public ActionResult DeleteSellers(int? id) {
            Seller cat = _context.Sellers.Where(c => c.Id == id).FirstOrDefault();
            if (cat != null) {
                _context.Sellers.Remove(cat);
                _context.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }

        }
        [HttpPut]
        public ActionResult ChangeSeller(int? id, [FromBody]Seller cat) {
            var check = _context.Sellers.Any(c => c.Id == id);
            if (check) {
                Seller categoryBefore = _context.Sellers.Where(c => c.Id == id).FirstOrDefault();
                if (cat.Name != null) {
                    categoryBefore.Name = cat.Name;
                }
                if (cat.Adress != null) {
                    categoryBefore.Adress = cat.Adress;
                }
                if (cat.Rating != 0) {
                    categoryBefore.Rating = cat.Rating;
                }
                _context.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }
        }
    }
}