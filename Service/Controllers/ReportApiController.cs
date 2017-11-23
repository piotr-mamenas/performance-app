using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Reports;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Service.Dtos.Portfolio;
using Service.Dtos.Report;

namespace Service.Controllers
{
    [RoutePrefix("api/reports")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReportApiController : ApiController
    {
        private readonly IReportRepository<Report> _repository;
        private readonly IComplete _unitOfWork;

        public ReportApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Reports;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ICollection<ReportDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var reports = await _repository.GetAll()
                .ToListAsync();

            if (reports == null)
            {
                return NotFound();
            }
            return Ok(reports.Map<ICollection<ReportDto>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(ReportDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var report = await _repository.GetAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report.Map<ReportDto>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, ReportDto report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var reportInDb = await _repository.GetAsync(id);

            if (reportInDb == null)
            {
                return NotFound();
            }

            _repository.Add(report.Map<Report>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> CreateAsync(PortfolioDto report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(report.Map<Report>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + report.Id), report);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var report = await _repository.GetAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            _repository.Remove(report);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}