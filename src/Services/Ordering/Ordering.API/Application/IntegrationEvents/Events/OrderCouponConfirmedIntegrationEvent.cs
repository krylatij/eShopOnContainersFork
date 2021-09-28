﻿namespace Ordering.API.Application.IntegrationEvents.Events
{
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
    using Newtonsoft.Json;

    public record OrderCouponConfirmedIntegrationEvent : IntegrationEvent
    {
        [JsonProperty]
        public int OrderId { get; set; }

        [JsonProperty]
        public int Discount { get; set; }
    }
}