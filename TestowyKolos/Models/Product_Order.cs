using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestowyKolos.Models;
[PrimaryKey("ProductID", "OrderID")]
public class Product_Order
{
    public int Ammount { get; set; }
    [Key]
    public int ProductID { get; set; }
    [Key]
    public int OrderID { get; set; }
    
    [ForeignKey("OrderID")]
    public Order Order { get; set; }
    [ForeignKey("ProductID")]
    public Product Product { get; set; }
}