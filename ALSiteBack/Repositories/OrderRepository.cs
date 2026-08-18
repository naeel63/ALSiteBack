using ALSiteBack.Data;
using ALSiteBack.Dto;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ALSiteBack.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(OrderDto orderDto)
        {
            if (orderDto.Customer == null)
                throw new Exception("Не указаны данные покупателя.");

            if (orderDto.Items == null || orderDto.Items.Count == 0)
                throw new Exception("Корзина пуста.");

            if (!orderDto.Customer.PersonalDataConsent)
                throw new Exception(
                    "Необходимо согласие на обработку персональных данных."
                );

            var productIds = orderDto.Items
                .Select(item => item.ProductId)
                .Distinct()
                .ToList();

            var products = await _context.Products
                .Where(product => productIds.Contains(product.Id))
                .ToListAsync();

            if (products.Count != productIds.Count)
                throw new Exception(
                    "Один или несколько товаров не найдены."
                );

            var order = new Order
            {
                Name = orderDto.Customer.Name,
                Phone = orderDto.Customer.Phone,
                Comment = orderDto.Customer.Comment,

                PersonalDataConsent =
                    orderDto.Customer.PersonalDataConsent,

                Currency = orderDto.Currency,
                CreatedAt = DateTime.UtcNow,

                Items = new List<OrderItem>()
            };

            var total = 0;

            foreach (var item in orderDto.Items)
            {
                if (item.Quantity <= 0)
                    throw new Exception(
                        $"Некорректное количество товара: {item.ProductId}"
                    );

                var product = products
                    .First(product => product.Id == item.ProductId);

                if (product.Ostatok < item.Quantity)
                    throw new Exception(
                        $"Недостаточно товара: {product.Name}"
                    );

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,

                    Code = product.Code,
                    Name = product.Name,
                    Price = product.Price,

                    Quantity = item.Quantity
                };

                order.Items.Add(orderItem);

                total += product.Price * item.Quantity;
            }

            order.Total = total;

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order;
        }
    }
}