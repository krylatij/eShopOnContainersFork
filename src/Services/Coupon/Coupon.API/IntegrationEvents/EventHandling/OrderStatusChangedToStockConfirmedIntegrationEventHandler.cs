namespace Coupon.API.IntegrationEvents.EventHandling
{
    using Coupon.API.IntegrationEvents.Events;
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Serilog.Context;
    using System.Threading.Tasks;

    public class OrderStatusChangedToAwaitingCouponValidationIntegrationEventHandler :
        IIntegrationEventHandler<OrderStatusChangedToAwaitingCouponValidationIntegrationEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<OrderStatusChangedToAwaitingCouponValidationIntegrationEventHandler> _logger;

        public OrderStatusChangedToAwaitingCouponValidationIntegrationEventHandler(
            IEventBus eventBus,
            ILogger<OrderStatusChangedToAwaitingCouponValidationIntegrationEventHandler> logger)
        {
            _eventBus = eventBus;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task Handle(OrderStatusChangedToAwaitingCouponValidationIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                IntegrationEvent orderPaymentIntegrationEvent;

                //Business feature comment:
                // When OrderStatusChangedToStockConfirmed Integration Event is handled.
                // Here we're simulating that we'd be performing the payment against any payment gateway
                // Instead of a real payment we just take the env. var to simulate the payment 
                // The payment can be successful or it can fail

                if (_settings.PaymentSucceeded)
                {
                    orderPaymentIntegrationEvent = new OrderPaymentSucceededIntegrationEvent(@event.OrderId);
                }
                else
                {
                    orderPaymentIntegrationEvent = new OrderPaymentFailedIntegrationEvent(@event.OrderId);
                }

                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", orderPaymentIntegrationEvent.Id, Program.AppName, orderPaymentIntegrationEvent);

                _eventBus.Publish(orderPaymentIntegrationEvent);

                await Task.CompletedTask;
            }
        }
    }
}