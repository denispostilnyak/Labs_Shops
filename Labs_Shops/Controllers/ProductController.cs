using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs_Shops.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Labs_Shops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Labs2_Context _context;
        public ProductController(Labs2_Context context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct() {
            return await _context.Products.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct(int? id) {
            return await _context.Products.Where(c => c.Id == id).ToListAsync();
        }
        [HttpPost]
        public ActionResult PostProduct([FromBody]Product Product) {
            _context.Products.Add(Product);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int? id) {
            Product cat = _context.Products.Where(c => c.Id == id).FirstOrDefault();
            if (cat != null) {
                _context.Products.Remove(cat);
                _context.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }

        }
        [HttpPut]
        public ActionResult ChangeProduct(int? id, [FromBody]Product cat) {
            var check = _context.Products.Any(c => c.Id == id);
            if (check) {
                Product categoryBefore = _context.Products.Where(c => c.Id == id).FirstOrDefault();
                if (cat.Name != null) {
                    categoryBefore.Name = cat.Name;
                }
                if (cat.Info != null) {
                    categoryBefore.Info = cat.Info;
                }
                if (cat.Rating != 0) {
                    categoryBefore.Rating = cat.Rating;
                }
                if (cat.Specification != null) {
                    categoryBefore.Specification = cat.Specification;
                }
                _context.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }
        }
    }
}