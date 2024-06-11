using System.ComponentModel.DataAnnotations;

namespace TestowyKolos.Models;

public class Status
{
    [Key]
    public int IdStatus { get; set; }
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}