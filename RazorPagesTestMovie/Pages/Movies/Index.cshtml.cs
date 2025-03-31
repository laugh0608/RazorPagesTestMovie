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
    // 此构造函数使用依赖关系注入将 RazorPagesMovieContext 添加到页面：
    public class IndexModel : PageModel
    {
        private readonly Data.RazorPagesTestMovieContext _context;

        public IndexModel(Data.RazorPagesTestMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        // 对页面发出 GET 请求时，OnGetAsync 方法向 Razor 页面返回影片列表
        // OnGetAsync 或 OnGet 在 Razor 页面上调用，以初始化该页面的状态
        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
