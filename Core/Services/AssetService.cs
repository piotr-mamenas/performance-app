using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Assets;
using Core.Domain.Portfolios;
using Core.Enums.Domain;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IBondRepository _bondRepository;

        public AssetService(IUnitOfWork unitOfWork)
        {
            _assetRepository = unitOfWork.Assets;
            _bondRepository = unitOfWork.Bonds;
        }
        
        public decimal? GetPortfolioAssetReturnsForPeriod(List<Tuple<DateTime,DateTime>> calculationPeriods, Portfolio portfolio, Asset asset)
        {
            var initialDatetime = calculationPeriods.Min(p => p.Item1).Date;
            var finalDatetime = calculationPeriods.Max(p => p.Item2).Date;

            try
            {
                var periodIncomes = portfolio.Positions
                    .Where(p => p.AssetId == asset.Id)
                    .Where(p => p.Timestamp >= initialDatetime && p.Timestamp <= finalDatetime)
                    .Select(p => new Tuple<decimal, DateTime>(p.Amount, p.Timestamp))
                    .ToList();

                asset.CalculateReturn(ReturnType.HoldingPeriodReturn, calculationPeriods, periodIncomes);

                return asset.Returns
                    .Where(r => r.Id == 0)
                    .Select(crr => crr.Rate)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw new NoCalculationResultException($"No result for period from {initialDatetime} to {finalDatetime}");
            }
        }
    }
}
