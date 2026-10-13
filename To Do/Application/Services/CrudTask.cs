using Microsoft.EntityFrameworkCore;
using To_Do.Application.DTOs;
using To_Do.Application.Interfaces;
using To_Do.Domain.Entities;
using To_Do.Domain.Shared;
using To_Do.Infrastructure.Persistance;
namespace To_Do.Application.Services;

public class CrudTask : ICrudTask
{
    private readonly BContext context;
    public CrudTask(BContext context)
    {
        this.context = context;
    }

    public async Task<Result<List<GetTaskDto>>> GetTasks()
    {
        var task = await context
            .toDoTask.Select(x => x)
            .ToArrayAsync();
        var result = task.Select(t => new GetTaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            isDone = t.isDone,
            _priority = t._priority,
        }).ToList();

        return Result<List<GetTaskDto>>.Ok(result);
    }

    public async Task<Result<GetTaskDto>> CreateTask(CreateTaskDto req)
    {
        var task = new ToDoTask
        {
            Title = req.Title,
            Description = req.Desctiption,
            _priority = req._priority,
            isDone = false
        };

        await context.AddAsync(task);
        await context.SaveChangesAsync();

        var response = await context.toDoTask.Select(t => new GetTaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            _priority = t._priority,
            isDone = t.isDone
        }).FirstOrDefaultAsync();

        return Result<GetTaskDto>.Ok(response!);
    }

    public async Task<Result<GetTaskDto>> EditTask(EditTaskDto req, int taskId)
    {
        var task = await context.toDoTask.FirstOrDefaultAsync(t => t.Id == taskId);

        if (task is null) return Result<GetTaskDto>.Fail("Not Found");

        if (req.isDone.HasValue)
            task.isDone = req.isDone.Value;

        if (req._priority.HasValue)
            task._priority = req._priority.Value;

        if (req.Title is not null)
            task.Title = req.Title;

        if (req.Description is not null)
            task.Description = req.Description;

        await context.AddAsync(task);
        await context.SaveChangesAsync();

        var response = new GetTaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            _priority = task._priority,
            isDone = task.isDone
        };
        return Result<GetTaskDto>.Ok(response);
    }

    public async Task<Result<bool>> DeleteTask(int taskId)
    {
        var task = await context.toDoTask.FirstOrDefaultAsync(t => t.Id == taskId);

        if (task is null)
            return Result<bool>.Fail("Task not found");

        context.toDoTask.Remove(task);
        await context.SaveChangesAsync();

        return Result<bool>.Ok(true);
    }
}