using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly Test.Data.TestContext _context;

        public DetailsModel(Test.Data.TestContext context)
        {
            _context = context;
        }

        public project project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            project = await _context.project.FirstOrDefaultAsync(m => m.Id == id);

            if (project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
