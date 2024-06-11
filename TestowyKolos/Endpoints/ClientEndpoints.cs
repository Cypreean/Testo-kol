using Microsoft.AspNetCore.Mvc;
using TestowyKolos.RequestModels;
using TestowyKolos.Services;

namespace TestowyKolos.Endpoints;
[ApiController]
[Route("api/clients")]
public class ClientEndpoints : ControllerBase
{
    private readonly IOrderService _orderService;
    
    public ClientEndpoints(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost("{id:int}/orders")]
    public async Task<IActionResult> AddOrder(int id, RequestOrderModel requestOrderModel)
    {
        try
        {
            await _orderService.CreateOrder(requestOrderModel, id);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}