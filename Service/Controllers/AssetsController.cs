using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Assets;
using Core.Dtos;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.AutoMapper;

namespace Service.Controllers
{
    [RoutePrefix("api/assets")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AssetsController : ApiController
    {
        private readonly IAssetRepository<Asset> _repository;
        private readonly IComplete _unitOfWork;

        public AssetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Assets;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ICollection<AssetDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var assets = await _repository.GetAll()
                .ToListAsync();

            if (assets == null)
            {
                return NotFound();
            }
            return Ok(assets.Map<ICollection<AssetDto>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="asset"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
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
