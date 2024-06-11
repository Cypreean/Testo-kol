using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TestowyKolos.Models;

public class Product
{
    [Key]
    [Column("ID")]
    public int IdProduct { get; set; }
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    [Required]
    [Column (TypeName = "decimal(6,2)")]
    public float Price { get; set; }
    
    public ICollection<Product_Order> Product_Orders { get; set; }
}