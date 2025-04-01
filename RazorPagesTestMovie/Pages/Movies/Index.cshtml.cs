using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestMovie.Data;
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
        // [BindProperty] 会绑定名称与属性相同的表单值和查询字符串
        // 在 HTTP GET 请求中进行绑定需要 [BindProperty(SupportsGet = true)]
        [BindProperty(SupportsGet = true)]
        // SearchString：包含用户在搜索文本框中输入的文本
        public string? SearchString { get; set; }
        // Genres：包含流派列表，使用户能够从列表中选择一种流派
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        // MovieGenre：包含用户选择的特定流派
        public string? MovieGenre { get; set; }
        
        // 对页面发出 GET 请求时，OnGetAsync 方法向 Razor 页面返回影片列表
        // OnGetAsync 或 OnGet 在 Razor 页面上调用，以初始化该页面的状态
        public async Task OnGetAsync()
        {
            // Movie = await _context.Movie.ToListAsync();
            // 创建 LINQ 查询用于选择电影
            var movies = from m in _context.Movie
                select m;
            // 如果 SearchString 属性不为 null 或空，则电影查询会修改为根据搜索字符串进行筛选
            if (!string.IsNullOrEmpty(SearchString))
            {
                // s => s.Title.Contains() 代码是 Lambda 表达式
                //  Lambda 在基于方法的 LINQ 查询中用作标准查询运算符方法的参数，如 Where 方法或 Contains
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();
        }
        
    }
}
