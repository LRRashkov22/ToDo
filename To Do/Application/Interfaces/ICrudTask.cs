using To_Do.Application.DTOs;
using To_Do.Domain.Shared;

namespace To_Do.Application.Interfaces;

public interface ICrudTask
{
    Task<Result<List<GetTaskDto>>> GetTasks();
    Task<Result<GetTaskDto>> CreateTask(CreateTaskDto req);
    Task<Result<GetTaskDto>> EditTask(EditTaskDto req, int taskId);
    Task<Result<bool>> DeleteTask(int taskId);
}
