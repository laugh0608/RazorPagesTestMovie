using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestMovie.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Movie
{
    public int Id { get; set; }
    // string.Empty 表示一个空字符串，即初始值为空
    public string Title { get; set; } = string.Empty;
    
    // 该属性指定字段的显示名称，是 Release Date 而不是 ReleaseDate
    [Display(Name = "Release Date")]
    // 该属性指定数据的类型 (Date)，此字段中存储的时间信息不显示
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; } = string.Empty;
    
    // 该数据注释使 Entity Framework Core 可以将 Price 正确映射到数据库中的货币
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    // 添加分级属性
    public string Rating { get; set; } = string.Empty;
}