using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
using RazorPagesTestMovie.Data;
using RazorPagesTestMovie.Models;

// 创建一个带有预配置默认值的 WebApplicationBuilder，向 Razor 添加 Pages 支持，并生成应用
var builder = WebApplication.CreateBuilder(args);
// 为容器添加服务
builder.Services.AddRazorPages();
// 基架工具自动创建数据库上下文并将其注册到依赖关系注入容器
// RazorPagesTestMovieContext 对象处理连接到数据库并将 Movie 对象映射到数据库记录的任务
// ASP.NET Core 配置系统会读取 ConnectionString 键。 进行本地开发时，配置从 appsettings.json 文件获取连接字符串
builder.Services.AddDbContext<RazorPagesTestMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesTestMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesTestMovieContext' not found.")));
var app = builder.Build();

// 添加数据库种子初始值设定项
// 从依赖注入 (DI) 容器中获取数据库上下文实例
using (var scope = app.Services.CreateScope())
{
    // 调用 seedData.Initialize 方法，并向其传递数据库上下文实例
    var services = scope.ServiceProvider;
    // Seed 方法完成时释放上下文。 using 语句将确保释放上下文
    SeedData.Initialize(services);
}

// 异常终结点设置为 /Error，并且当应用未在开发模式中运行时，启用 HSTS 协议
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // HSTS 的默认值为 30 天，在生产情况下，需要更改该值，详见：https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// 将 HTTP 请求重定向到 HTTPS
app.UseHttpsRedirection();
// 向中间件管道添加路由匹配
app.UseRouting();
// 授权用户访问安全资源，此应用不使用授权，因此可删除此行
app.UseAuthorization();
// 优化应用中静态资产的交付，例如 HTML、CSS、图像和 JavaScript
app.MapStaticAssets();
// 为 Razor Pages 配置终结点路由
app.MapRazorPages()
    .WithStaticAssets();
// 运行应用
app.Run();