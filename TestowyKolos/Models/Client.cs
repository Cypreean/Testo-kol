using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestowyKolos.Models;

public class Client
{
    [Key]
    [Column("ID")]
    public int IdClient { get; set; }
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}