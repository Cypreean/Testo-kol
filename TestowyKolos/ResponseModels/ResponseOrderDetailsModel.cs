namespace TestowyKolos.ResponseModels;

public class ResponseOrderDetailsModel
{
    public int OrderId { get; set; }
    public string ClientsLastsName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime FulfilledAt { get; set; }
    public string Status { get; set; }
    public List<Products> ProductsList { get; set; }
}

public class Products
{
    public string ProductName { get; set; }
    public float ProductPrice { get; set; }
    public int ProductAmmount { get; set; }
}