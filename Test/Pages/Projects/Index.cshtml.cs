using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly Test.Data.TestContext _context;

        public IndexModel(Test.Data.TestContext context)
        {
            _context = context;
        }

        public IList<project> project { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Title { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ProjectsTitle { get; set; }

        public async Task OnGetAsync()
        {
            var Title = from m in _context.project
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Title = Title.Where(s => s.Title.Contains(SearchString));
            }
            
            project = await Title.ToListAsync();
        }
    }
}
