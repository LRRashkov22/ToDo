using To_Do.Domain.Enums;

namespace To_Do.Application.DTOs;

public class EditTaskDto
{
    public string? Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public bool? isDone { get; set; }
    public Priority? _priority { get; set; }
}
