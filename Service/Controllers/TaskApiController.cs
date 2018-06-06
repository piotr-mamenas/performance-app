using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Tasks;
using Core.Interfaces;
using Core.Interfaces.Repositories.System;
using Infrastructure.AutoMapper;
using Service.Dtos.Portfolio;
using Service.Dtos.Task;

namespace Service.Controllers
{
    [RoutePrefix("api/tasks")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskApiController : ApiController
    {
        private readonly ITaskRepository<ServerTask> _repository;
        private readonly IComplete _unitOfWork;

        public TaskApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ICollection<ServerTaskDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var tasks = await _repository.GetAll().ToListAsync();

            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks.Map<ICollection<ServerTaskDto>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        public async Task<IHttpActionResult> UpdateAsync(int id, ServerTaskDto task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
        public async Task<IHttpActionResult> CreateAsync(ServerTaskDto task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
            var tasks = await _repository.GetAll()
                .Include(t => t.Runs)
                .Include(t => t.Type)
                .ToListAsync();

            if (tasks == null)
            {
                return NotFound();
            }

            var taskRuns = tasks.SelectMany(tr => tr.Runs).ToList();

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