using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Assets;
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
        private readonly IAssetRepository<Asset> _repository;
        private readonly IComplete _unitOfWork;

        public AssetApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Assets;
        }

        [ResponseType(typeof(ICollection<AssetDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var assets = await _repository.GetAll()
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
            var asset = await _repository.GetAsync(id);

            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset.Map<AssetDto>());
        }

        [ResponseType(typeof(AssetDto))]
        [HttpGet, Route("portfolios/{id}")]
        public async Task<IHttpActionResult> GetByPortfolioAsync(int id)
        {
            var assets = await _repository.GetAll()
                .Where(a => a.Portfolios.Any(p => p.Id == id))
                .Include(a => a.Class)
                .Include(a => a.Prices)
                .Include(a => a.Prices.Select(p => p.Currency))
                .ToListAsync();

            if (assets == null)
            {
                return NotFound();
            }
            return Ok(assets.Map<ICollection<AssetDto>>());
        }

        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, AssetDto asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var assetInDb = await _repository.GetAsync(id);

            if (assetInDb == null)
            {
                return NotFound();
            }

            _repository.Add(asset.Map<Asset>());

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

            _repository.Add(asset.Map<Asset>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + asset.Id), asset);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var asset = await _repository.GetAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            _repository.Remove(asset);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
