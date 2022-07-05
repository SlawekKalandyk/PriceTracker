﻿using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Scraper.Application.Common.Interfaces
{
    public interface IScraperApplicationDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Price> Prices { get; }
        DbSet<Availability> Availabilities { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}