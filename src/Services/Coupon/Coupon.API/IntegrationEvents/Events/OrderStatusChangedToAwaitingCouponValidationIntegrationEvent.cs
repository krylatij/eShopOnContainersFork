using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using Newtonsoft.Json;

namespace Coupon.API.IntegrationEvents.Events
{
    public record OrderStatusChangedToAwaitingCouponValidationIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; init; }

        public string OrderStatus { get; init; }

        public string BuyerName { get; init; }

        public string Code { get; init; }
    }
}
