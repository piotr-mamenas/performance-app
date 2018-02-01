using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Assets;
using Core.Domain.Returns;
using Core.Enums.Domain;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Service.Dtos.Asset;

namespace Service.Controllers
{
    [RoutePrefix("api/assets")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AssetApiController : ApiController
    {
        private readonly IAssetRepository<Asset> _assetRepository;
        private readonly IAssetRepository<Bond> _bondRepository;
        private readonly IReturnRepository<HoldingPeriodReturn> _returnRepository;
        private readonly IComplete _unitOfWork;

        public AssetApiController(IUnitOfWork unitOfWork)
        {
            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.ContractResolver = new AssetContractResolver();

            _unitOfWork = (IComplete)unitOfWork;
            _assetRepository = unitOfWork.Assets;
            _returnRepository = unitOfWork.HoldingPeriodReturns;
            _bondRepository = unitOfWork.Bonds;
        }

        [ResponseType(typeof(ICollection<AssetDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var assets = await _assetRepository.GetAll()
                .Include(a => a.Prices)
                .Include(a => a.Class)
                .ToListAsync();

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

        [ResponseType(typeof(ICollection<AssetDto>))]
        [HttpGet, Route("portfolios/{id}")]
        public async Task<IHttpActionResult> GetByPortfolioAsync(int id)
        {
            var assets = await _assetRepository.GetAll()
                .Where(a => a.Portfolios.Any(p => p.Id == id))
                .Include(a => a.Class)
                .Include(a => a.Prices)
                .Include(a => a.Prices.Select(p => p.Currency))
                .Include(a => a.Returns)
                .ToListAsync();

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

                var bondAsset = _bondRepository.GetAll()
                    .Include(b => b.Currency)
                    .SingleOrDefault(b => b.Id == assetDto.Id);

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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
        public async Task<IHttpActionResult> CreateAsync(AssetDto asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
