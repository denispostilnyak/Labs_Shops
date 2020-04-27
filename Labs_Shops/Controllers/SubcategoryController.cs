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
    public class SubcategoryController : ControllerBase
    {
        private readonly Labs2_Context _context;
        public SubcategoryController(Labs2_Context context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubCategories() {
            return await _context.Subcategories.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubCategories(int? id) {
            return await _context.Subcategories.Where(c => c.Id == id).ToListAsync();
        }
        [HttpPost]
        public void PostSubCategories([FromBody]Category Product) {
            _context.Categories.Add(Product);
            _context.SaveChanges();
        }
        [HttpDelete]
        public ActionResult DeleteSubCategories(int? id) {
            Subcategory cat = _context.Subcategories.Where(c => c.Id == id).FirstOrDefault();
            if (cat != null) {
                _context.Subcategories.Remove(cat);
                _context.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }

        }
        [HttpPut]
        public ActionResult ChangeSubCategory(int? id, [FromBody]Subcategory cat) {
            var check = _context.Subcategories.Any(c => c.Id == id);
            if (check) {
                Subcategory categoryBefore = _context.Subcategories.Where(c => c.Id == id).FirstOrDefault();
                if (cat.Name != null) {
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