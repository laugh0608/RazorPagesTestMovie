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

        // OnGet 方法初始化页面所需的任何状态
        // “创建”页没有任何要初始化的状态，因此返回 Page
        // TODO: Page 方法创建用于呈现 Create.cshtml 页的 PageResult 对象
        public IActionResult OnGet()
        {
            return Page();
        }

        // Movie 属性使用 [BindProperty] 特性来选择加入模型绑定
        // 当“创建”表单发布表单值时，ASP.NET Core 运行时将发布的值绑定到 Movie 模型
        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        // 当返回类型是 IActionResult 或 Task<IActionResult> 时，必须提供返回语句
        // 当页面发布表单数据时，运行 OnPostAsync 方法
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
        // 如果不存在任何模型错误，将重新显示表单，以及发布的任何表单数据
        // 在发布表单前，可以在客户端捕获到大部分模型错误
        // 模型错误的一个示例是，发布的日期字段值无法转换为日期
    }
}
