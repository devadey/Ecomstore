using API.Data;
using API.DTOs;
using API.Entities;
using API.Entities.OrderAggregate;
using API.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class OrdersController:BaseApiController
{
    private readonly StoreContext _context;

    public OrdersController(StoreContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> GetOrders()
    {
        return await _context.Orders
        .ProjectOrderToOrderDto()
        .Where(x => x.BuyerId == User.Identity.Name)
        .ToListAsync();
    }

    [HttpGet("{id}", Name = "GetOrder")]
    public async Task<ActionResult<OrderDto>> GetOrder(int id)
    {
        return await _context.Orders
            .ProjectOrderToOrderDto()
            .Where(b => b.Id == id && b.BuyerId == User.Identity.Name)
            .FirstOrDefaultAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(CreateOrderDto createOrder)
    {
        var basket = await _context.Baskets
            .RetrieveBasketWithItems(User.Identity.Name)
            .FirstOrDefaultAsync();

        if (basket is null) return BadRequest(new ProblemDetails { Title="Couldn't locate the basket" });

        var items = new List<OrderItem>();

        foreach (var item in basket.Items)
        {
            var productInDb = await _context.Products.FindAsync(item.ProductId);
            var itemOrderedDetails = new ProductItemOrdered
            {
                ProductId = productInDb.Id,
                Name = productInDb.Name,
                PictureUrl = productInDb.PictureUrl,
            };

            var orderItem = new OrderItem
            {
                ItemOrdered = itemOrderedDetails,
                Price = productInDb.Price,
                Quantity = item.Quantity
            };
            items.Add(orderItem);
            productInDb.QuantityInStock -=  item.Quantity;
        }

        var subTotal = items.Sum(item => item.Price * item.Quantity);
        var deliveryFee = subTotal > 10000 ? 0 : 500;

        var order = new Order
        {
            DeliveryFee = deliveryFee,
            Subtotal = subTotal,
            OrderItems = items,
            BuyerId = User.Identity.Name,
            ShippingAddress = createOrder.ShippingAddress
        };

        _context.Orders.Add(order);
        _context.Baskets.Remove(basket);

        if (createOrder.SaveAddress)
        {
            var user = _context.Users
                .Include(a => a.Address)
                .FirstOrDefault(x => x.UserName == User.Identity.Name);
            var address = new UserAddress
            {
                FullName = createOrder.ShippingAddress.FullName,
                Address1 = createOrder.ShippingAddress.Address1,
                Address2 = createOrder.ShippingAddress.Address2,
                City = createOrder.ShippingAddress.City,
                State = createOrder.ShippingAddress.State,
                Zip = createOrder.ShippingAddress.Zip,
                Country = createOrder.ShippingAddress.Country,
            };
            user.Address = address;

            //_context.Update(user);
        }
        var identityResult = await _context.SaveChangesAsync();
        if (identityResult > 0)
        {
            return CreatedAtRoute("GetOrder", new { id = order.Id }, order.Id);
        }
        return BadRequest("Problem creating order");
    }
}
