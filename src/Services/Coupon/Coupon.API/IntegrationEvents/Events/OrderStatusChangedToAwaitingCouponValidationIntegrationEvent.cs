using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using Newtonsoft.Json;

namespace Coupon.API.IntegrationEvents.Events
{
    public record OrderStatusChangedToAwaitingCouponValidationIntegrationEvent : IntegrationEvent
    {
        [JsonProperty]
        public int OrderId { get; set; }

        public string OrderStatus { get; set; }

        public string BuyerName { get; set; }

        public string Code { get; set; }
    }
}
