// Models/UpdateProductDto.cs
using System.ComponentModel.DataAnnotations;

namespace BestPracticeApi.Models;

public class UpdateProductDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Range(0.01, 1000000)]
    public decimal Price { get; set; }
}