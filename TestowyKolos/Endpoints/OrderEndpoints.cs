using Microsoft.AspNetCore.Mvc;
using TestowyKolos.Services;

namespace TestowyKolos.Endpoints;
[Route("api/clients/{id:int}/orders")]
public class OrderEndpoints : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderEndpoints(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders(int id)
    {
        try
        {
            return Ok(await _orderService.GetOrderDetails(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

  
    
}