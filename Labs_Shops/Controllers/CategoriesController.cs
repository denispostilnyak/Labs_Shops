using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Labs_Shops.Models;
using Microsoft.EntityFrameworkCore;

namespace Labs_Shops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase {
        private readonly Labs2_Context _context;
        public CategoriesController(Labs2_Context context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() {
            return await _context.Categories.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(int? id) {
            return await _context.Categories.Where(c => c.Id == id).ToListAsync();
        }
        [HttpPost]
        public void PostCategories([FromBody]Category Product) {
            _context.Categories.Add(Product);
            _context.SaveChanges();
        }
        [HttpDelete]
        public ActionResult DeleteCategories(int? id) {
            Category cat = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (cat != null)  {
                _context.Categories.Remove(cat);
                _context.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }
           
        }
        [HttpPut]
        public ActionResult ChangeCategory(int? id, [FromBody]Category cat) {
            var check = _context.Categories.Any(c => c.Id == id);
            if (check) {
                Category categoryBefore = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
                if (cat.Name!=null) {
                    categoryBefore.Name = cat.Name;
                    _context.SaveChanges();
                }
                return Ok();
            } else {
                return NotFound();
            }
        }

    }
}