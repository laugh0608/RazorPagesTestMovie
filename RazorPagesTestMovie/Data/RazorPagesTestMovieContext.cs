using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestMovie.Models;

namespace RazorPagesTestMovie.Data
{
    public class RazorPagesTestMovieContext : DbContext
    {
        public RazorPagesTestMovieContext (DbContextOptions<RazorPagesTestMovieContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTestMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
