// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using RazorPagesTestMovie.Data;
using RazorPagesTestMovie.Models;

namespace RazorPagesTestMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Data.RazorPagesTestMovieContext _context;

        public CreateModel(Data.RazorPagesTestMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        // 当返回类型是 IActionResult 或 Task<IActionResult> 时，必须提供返回语句
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
