namespace Coupon.API.IntegrationEvents.Events
{
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

    public record OrderCouponConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public string CouponCode { get; set; }

        public OrderCouponConfirmedIntegrationEvent(int orderId, string couponCode)
        {
            OrderId = orderId;
            CouponCode = couponCode;
        }
    }
}