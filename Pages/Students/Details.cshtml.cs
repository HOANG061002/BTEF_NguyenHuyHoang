using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetRazorsPageEFCore.Data;
using AspNetRazorsPageEFCore.Models;

namespace AspNetRazorsPageEFCore.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetRazorsPageEFCore.Data.AspNetRazorsPageEFCoreContext _context;

        public DetailsModel(AspNetRazorsPageEFCore.Data.AspNetRazorsPageEFCoreContext context)
        {
            _context = context;
        }

      public Student Student { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }
    }
}
