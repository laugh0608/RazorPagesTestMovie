// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
// using RazorPagesTestMovie.Data;
using RazorPagesTestMovie.Models;

namespace RazorPagesTestMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Data.RazorPagesTestMovieContext _context;

        public IndexModel(Data.RazorPagesTestMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
