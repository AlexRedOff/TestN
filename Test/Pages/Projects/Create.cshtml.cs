using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Data;
using Test.Models;

namespace Test.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly Test.Data.TestContext _context;

        public CreateModel(Test.Data.TestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public project project { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.project.Add(project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
