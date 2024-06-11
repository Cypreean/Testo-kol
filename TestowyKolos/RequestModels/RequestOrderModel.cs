using TestowyKolos.Models;

namespace TestowyKolos.RequestModels;

public class RequestOrderModel
{
    public DateTime createdAt { get; set; }
    public DateTime fulfilledAt { get; set; }
    public List<Products> products { get; set; }
}
public class Products
{
    public int idProduct { get; set; }
    public int ammount { get; set; }
}