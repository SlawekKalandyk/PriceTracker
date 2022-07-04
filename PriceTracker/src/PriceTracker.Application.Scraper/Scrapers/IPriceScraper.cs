﻿using PriceTracker.Application.Scraper.Traits;

namespace PriceTracker.Application.Scraper.Scrapers
{
    public interface IPriceScraper
    {
        Price ScrapePrice();
    }
}
