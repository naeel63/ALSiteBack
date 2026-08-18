using ALSiteBack.Dto;
using ALSiteBack.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ALSiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateOrder(
            [FromBody] OrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var order =
                    await _orderRepository.CreateOrder(orderDto);

                return StatusCode(
                    StatusCodes.Status201Created,
                    new
                    {
                        id = order.Id,
                        orderNumber = order.Id,
                        total = order.Total,
                        currency = order.Currency
                    }
                );
            }
            catch (Exception exception)
            {
                return BadRequest(new
                {
                    message = exception.Message
                });
            }
        }
    }
}