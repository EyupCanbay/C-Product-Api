using System.ComponentModel.DataAnnotations;

namespace BestPracticeApi.Models;

public class CreateProductDto
{
    [Required(ErrorMessage = "Ürün adı boş olamaz.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Ürün adı 3 ile 100 karakter arasında olmalıdır.")]
    public string Name { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
    public decimal Price { get; set; }
}