using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestMovie.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Movie
{
    // TODO: 特别需要注意的是，更改数据结构之后要记得添加 EF Core迁移和更新数据库，保持数据库和数据结构的一致性
    // [Required] 和 [MinimumLength] 特性指示属性必须具有一个值。 不阻止用户输入空格来满足此验证
    // [RegularExpression] 特性用于限制可输入的字符
    
    public int Id { get; set; }
    
    // 添加验证字段，最小为 3，最大为 60
    [StringLength(60, MinimumLength = 3)]
    [Required]
    // string.Empty 表示一个空字符串，即初始值为空
    // 或者简写为一行：
    // [StringLength(60, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;
    
    // 该属性指定字段的显示名称，是 Release Date 而不是 ReleaseDate
    [Display(Name = "Release Date")]
    // 该属性指定数据的类型 (Date)，此字段中存储的时间信息不显示
    [DataType(DataType.Date)]
    // 或者显性指定时间格式
    // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    // 或者简写为一行：
    // [Display(Name = "Release Date"), DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    // 只能使用字母，第一个字母必须为大写，允许使用空格，但不允许使用数字和特殊字符
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    // 或者简写为一行：
    // [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
    public string Genre { get; set; } = string.Empty;
    
    // 最小为 1，最大为 100
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    // 或者简写为一行：
    // [Range(1, 100), DataType(DataType.Currency)]
    // 该数据注释使 Entity Framework Core 可以将 Price 正确映射到数据库中的货币
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    
    // 第一个字符为大写字母，允许在后续空格中使用特殊字符和数字。 “PG-13”对“分级”有效，但对于“Genre”无效
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    // 或者简写为一行：
    // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
    public string Rating { get; set; } = string.Empty;
}