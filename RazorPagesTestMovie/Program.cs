using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
using RazorPagesTestMovie.Data;
using RazorPagesTestMovie.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesTestMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesTestMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesTestMovieContext' not found.")));

var app = builder.Build();

// 添加数据库种子初始值设定项
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();