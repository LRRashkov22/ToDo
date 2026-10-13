using Microsoft.AspNetCore.Mvc;
using To_Do.Application.DTOs;
using To_Do.Application.Interfaces;
using To_Do.Domain.Entities;

namespace To_Do.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ICrudTask _task;
        public ToDoController(ICrudTask _task)
        {
            this._task = _task;
        }


        [HttpGet("all")]
        public async Task<ActionResult<ToDoTask>> GetTasksList()
        {
            var tasks = await _task.GetTasks();
            if (!tasks.Success) return BadRequest(tasks.Error);
            return Ok(tasks.Value);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoTask>> CreateTask(CreateTaskDto req)
        {
            var task = await _task.CreateTask(req);
            if (!task.Success) return BadRequest(task.Error);
            return Ok(task.Value);
        }


        [HttpPatch("{taskid}")]
        public async Task<ActionResult<ToDoTask>> EditTask(EditTaskDto req, int taskid)
        {
            var task = await _task.EditTask(req, taskid);
            if (!task.Success) return BadRequest(task.Error);
            return Ok(task.Value);
        }

        [HttpDelete("{taskid}")]
        public async Task<ActionResult<bool>> DeleteTask(int taskid)
        {
            var task = await _task.DeleteTask(taskid);
            if (!task.Success) return BadRequest(task.Error);
            return Ok(task.Value);
        }
    }
}
