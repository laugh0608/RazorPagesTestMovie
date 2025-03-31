using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }  // 属性可为空
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }  // 属性可为空
    public decimal Price { get; set; }
}