using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Tasks;
using Core.Interfaces;
using Core.Interfaces.Repositories.System;
using Infrastructure.AutoMapper;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.Portfolio;
using Service.Dtos.Task;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/tasks")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskApiController : BaseApiController
    {
        private readonly ITaskRepository _repository;
        private readonly IComplete _unitOfWork;

        public TaskApiController(IUnitOfWork unitOfWork, ILogger logger, ISessionService sessionService)
            : base(logger, sessionService)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Tasks;
        }

        [ResponseType(typeof(ICollection<ServerTaskDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var tasks = await _repository.GetAllTaskRunsAsync();

            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks.Map<ICollection<ServerTaskDto>>());
        }

        [ResponseType(typeof(ServerTaskDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var task = await _repository.GetAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task.Map<PortfolioDto>());
        }

        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, ServerTaskDto task)
        {
            var taskInDb = await _repository.GetAsync(id);

            if (taskInDb == null)
            {
                return NotFound();
            }

            _repository.Add(task.Map<ServerTask>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(ServerTaskDto task)
        {
            _repository.Add(task.Map<ServerTask>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + task.Id), task);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var task = await _repository.GetAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _repository.Remove(task);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpGet, Route("runs")]
        public async Task<IHttpActionResult> GetTaskRunsAsync()
        {
            var taskRuns = await _repository.GetAllTaskRunsAsync();

            if (taskRuns == null)
            {
                return NotFound();
            }

            return Ok(taskRuns.Map<IList<TaskRunDto>>());
        }

        [HttpGet, Route("{id}/runs")]
        public async Task<IHttpActionResult> GetTaskRunsByTaskIdAsync(int id)
        {
            var task = await _repository.GetAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            var taskRuns = task.Runs;

            return Ok(taskRuns.Map<TaskRunDto>());
        }
    }
}