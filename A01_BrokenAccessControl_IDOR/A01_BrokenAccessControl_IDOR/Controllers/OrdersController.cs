using Microsoft.AspNetCore.Mvc;

namespace A01_BrokenAccessControl_IDOR.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Dictionary<int, Order> _orders = new()
        {
            { 1, new Order { Id = 1, UserId = 101, Details = "Zamówienie 1 - użytkownik 101" } },
            { 2, new Order { Id = 2, UserId = 202, Details = "Zamówienie 2 - użytkownik 202" } }
        };

        private int GetCurrentUserId()
        {
            // W rzeczywistej aplikacji: pobieranie z tożsamości użytkownika
            return 101;
        }

        [HttpGet("orders/vulnerable")]
        public IActionResult GetOrderVulnerable(int orderId)
        {
            // IDOR podatność: brak sprawdzenia właściciela zamówienia
            if (_orders.TryGetValue(orderId, out var order))
            {
                return Ok(order);
            }

            return NotFound("Order not found.");
        }

        [HttpGet("orders/secure")]
        public IActionResult GetOrderSecure(int orderId)
        {
            var currentUserId = GetCurrentUserId();
            if (_orders.TryGetValue(orderId, out var order))
            {
                if (order.UserId == currentUserId)
                    return Ok(order);
                else
                    return StatusCode(403, "Brak dostępu do tego zamówienia.");
            }
            return NotFound("Zamówienie nie istnieje.");
        }
    }
}
