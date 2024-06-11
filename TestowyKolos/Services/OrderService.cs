using Microsoft.EntityFrameworkCore;
using TestowyKolos.Context;
using TestowyKolos.Models;
using TestowyKolos.RequestModels;
using TestowyKolos.ResponseModels;
using Products = TestowyKolos.ResponseModels.Products;

namespace TestowyKolos.Services;

public interface IOrderService
{
    Task<ResponseOrderDetailsModel> GetOrderDetails(int orderId);
    Task<RequestOrderModel> CreateOrder(RequestOrderModel requestOrderModel, int clientId);
}

public class OrderService(DatabaseContext context) : IOrderService
{
    public async Task<ResponseOrderDetailsModel> GetOrderDetails(int orderId)
    {
        var result = await context.Order
            .Where(e => e.IdOrder == orderId)
            .Select(e => new ResponseOrderDetailsModel
            {
                OrderId = e.IdOrder,
                ClientsLastsName = e.Client.LastName,
                CreatedAt = e.DateCreated,
                FulfilledAt = e.DateFinished,
                Status = e.Status.Name,
                ProductsList = e.Product_Orders.Select(e => new Products
                {
                    ProductName = e.Product.Name,
                    ProductPrice = e.Product.Price,
                    ProductAmmount = e.Ammount
                }).ToList()
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Order with id:{orderId} does not exist");
        }

        return result;
    }

    public async Task<RequestOrderModel> CreateOrder(RequestOrderModel requestOrderModel, int clientId)
    {
        using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var order = new Order
            {
                DateCreated = requestOrderModel.createdAt,
                DateFinished = requestOrderModel.fulfilledAt,
                ClientID = clientId,
                StatusID = 1
            };

            context.Order.Add(order);
            await context.SaveChangesAsync();

            foreach (var product in requestOrderModel.products)
            {
                var productOrder = new Product_Order
                {
                    Ammount = product.ammount,
                    ProductID = product.idProduct,
                    OrderID = order.IdOrder
                };

                context.Product_Order.Add(productOrder);
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return requestOrderModel;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}

public class NotFoundException(string message) : Exception(message);

