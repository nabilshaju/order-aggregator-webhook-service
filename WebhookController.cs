using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[ApiController]
[Route("api/v1/webhooks")]
public class OrderWebhookController : ControllerBase
{
    private readonly IOrderMappingService _mappingService;
    private readonly IHubContext<OrderHub> _hubContext;

    public OrderWebhookController(IOrderMappingService mappingService, IHubContext<OrderHub> hubContext)
    {
        _mappingService = mappingService;
        _hubContext = hubContext;
    }

    [HttpPost("receive-order")]
    public async Task<IActionResult> HandleOrder([FromBody] dynamic payload, [FromHeader(Name = "X-Aggregator-Source")] string source)
    {
        // 1. Logic to verify HMAC signatures or API Keys would go here
        if (string.IsNullOrEmpty(source)) return Unauthorized();

        // 2. Map the dynamic payload to a structured InternalOrder
        var internalOrder = _mappingService.MapToInternalOrder(payload, source);

        // 3. Trigger a real-time notification to the ERP Dashboard via SignalR
        await _hubContext.Clients.All.SendAsync("NewOrderReceived", new {
            OrderId = internalOrder.ExternalOrderId,
            Platform = source,
            Timestamp = DateTime.UtcNow
        });

        return Ok(new { Message = "Order synced to ERP successfully" });
    }
}
