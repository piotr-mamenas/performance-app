using System;
using System.Collections.Generic;
using Core.Domain.Assets;
using Core.Domain.Portfolios;

namespace Core.Interfaces.Services
{
    public interface IAssetService
    {
        decimal? GetPortfolioAssetReturnsForPeriod(List<Tuple<DateTime, DateTime>> calculationPeriods, Portfolio portfolio, Asset asset);
    }
}