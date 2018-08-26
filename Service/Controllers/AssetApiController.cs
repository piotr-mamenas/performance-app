using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Assets;
using Core.Enums.Domain;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Core.Interfaces.Services;
using Infrastructure.AutoMapper;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.Asset;
using Service.Dtos.Shared;
using Service.Filters;
using Service.Helpers;

namespace Service.Controllers
{
    [RoutePrefix("api/assets")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AssetApiController : BaseApiController
    {
        private readonly IAssetService _assetService;
        private readonly IAssetRepository _assetRepository;
        private readonly IBondRepository _bondRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IComplete _unitOfWork;

        public AssetApiController(IUnitOfWork unitOfWork, 
            IAssetService assetService,
            ISessionService sessionService,
            ILogger logger)
            : base(logger, sessionService)
        {
            _assetService = assetService;
            _unitOfWork = (IComplete)unitOfWork;
            _assetRepository = unitOfWork.Assets;
            _bondRepository = unitOfWork.Bonds;
            _portfolioRepository = unitOfWork.Portfolios;
        }

        [ResponseType(typeof(ICollection<AssetDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            var assets = await _assetRepository.GetAllAssetsWithPricesAsync();

            if (assets == null)
            {
                return NotFound();
            }

            return Ok(assets.Map<ICollection<AssetDto>>());
        }

        [ResponseType(typeof(AssetDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var asset = await _assetRepository.GetAsync(id);

            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset.Map<AssetDto>());
        }

        [ResponseType(typeof(decimal))]
        [HttpPost, Route("{assetId}/portfolios/{portfolioId}/returns")]
        public async Task<IHttpActionResult> GetReturnsForCalculationPeriodAsync(int assetId, int portfolioId, ICollection<DatePeriodDto> calculationPeriods)
        {
            var assetInDb = await _assetRepository.GetAsync(assetId);

            if (assetInDb == null)
            {
                return NotFound();
            }

            var portfolioInDb = await _portfolioRepository.GetAsync(portfolioId);

            if (portfolioInDb == null)
            {
                return NotFound();
            }

            var submittedPeriods = calculationPeriods.Map<List<Tuple<DateTime, DateTime>>>();

            try
            {
                var calculatedReturnRate = _assetService.GetPortfolioAssetReturnsForPeriod(submittedPeriods, portfolioInDb, assetInDb);

                _assetRepository.Add(assetInDb);

                return Ok(calculatedReturnRate);
            }
            catch (NoCalculationResultException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ResponseType(typeof(ICollection<AssetDto>))]
        [HttpGet, Route("portfolios/{id}")]
        public async Task<IHttpActionResult> GetByPortfolioAsync(int id)
        {
            var assets = await _assetRepository.GetAllAssetsWithDetailsByPortfolioAsync(id);

            if (assets == null)
            {
                return NotFound();
            }
            
            // TODO: Move the logic to a service
            var assetsDtos = assets.Map<ICollection<AssetDto>>();
            foreach (var assetDto in assetsDtos)
            {
                var lastHoldingPeriodReturn = assets.Select(a => a.Returns
                    .Where(r => r.Type == ReturnType.HoldingPeriodReturn && r.AssetId == assetDto.Id)
                    .OrderByDescending(r => r.CalculatedTime).SingleOrDefault())
                    .Select(r => r?.Rate)
                    .FirstOrDefault();

                var bondAsset = await _bondRepository.GetBondAssetWithCurrencyAsync(assetDto.Id);

                if (bondAsset != null)
                {
                    assetDto.CurrencyCode = bondAsset.Currency.Code;
                }
                assetDto.HoldingPeriodReturnRate = lastHoldingPeriodReturn;
            }

            return Ok(assetsDtos);
        }

        [ResponseType(typeof(AssetPriceDto))]
        [HttpGet, Route("prices")]
        public async Task<IHttpActionResult> GetPricesAsync()
        {
            var assetPrices = await _assetRepository.GetPrices(p => p.Asset != null);

            if (assetPrices == null)
            {
                return NotFound();
            }
            return Ok(assetPrices.Map<ICollection<AssetPriceDto>>());
        }

        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, AssetDto asset)
        {
            var assetInDb = await _assetRepository.GetAsync(id);

            if (assetInDb == null)
            {
                return NotFound();
            }

            _assetRepository.Add(asset.Map<Asset>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(AssetDto asset)
        {
            _assetRepository.Add(asset.Map<Asset>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + asset.Id), asset);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var asset = await _assetRepository.GetAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            _assetRepository.Remove(asset);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
