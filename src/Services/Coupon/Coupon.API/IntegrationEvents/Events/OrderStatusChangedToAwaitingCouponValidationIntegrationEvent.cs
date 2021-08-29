namespace Coupon.API.IntegrationEvents.Events
{
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

    public record OrderStatusChangedToAwaitingCouponValidationIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public string CouponCode { get; set; }

        public OrderStatusChangedToAwaitingCouponValidationIntegrationEvent(int orderId, string couponCode)
        {
            OrderId = orderId;
            CouponCode = couponCode;
        }
    }
}