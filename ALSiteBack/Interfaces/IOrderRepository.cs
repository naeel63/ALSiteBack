using ALSiteBack.Dto;
using ALSiteBack.Models;

namespace ALSiteBack.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(OrderDto orderDto);
    }
}