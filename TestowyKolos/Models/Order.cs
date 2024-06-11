using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestowyKolos.Models;

public class Order
{
    [Key]
    [Column("ID")]
    public int IdOrder { get; set; }
    
    [Required]
    [Column("CreatedAt")]
    public DateTime DateCreated { get; set; }
    public DateTime DateFinished { get; set; }
    
    public int ClientID { get; set; }
    public int StatusID { get; set; }
    
    [ForeignKey("ClientID")]
    public Client Client { get; set; }
    [ForeignKey("StatusID")]
    public Status Status { get; set; }
    
    public ICollection<Product_Order> Product_Orders { get; set; }
    
  
}