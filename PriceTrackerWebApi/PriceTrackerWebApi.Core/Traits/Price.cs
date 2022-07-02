﻿namespace PriceTrackerWebApi.Core.Traits
{
    public record Price(decimal CurrentPrice, decimal Discount, DateTime TimeStamp)
    {
        public decimal OriginalPrice => CurrentPrice + Discount;
    }
}
