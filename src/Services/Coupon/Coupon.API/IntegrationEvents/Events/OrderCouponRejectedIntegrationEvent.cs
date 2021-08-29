namespace Payment.API.IntegrationEvents.Events
{
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

    public record OrderCouponRejectedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public string CouponCode { get; set; }

        public OrderCouponRejectedIntegrationEvent(int orderId, string couponCode)
        {
            OrderId = orderId;
            CouponCode = couponCode;
        }
    }
}