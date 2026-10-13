using To_Do.Domain.Enums;

namespace To_Do.Application.DTOs;

public class GetTaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool isDone { get; set; }
    public Priority _priority { get; set; }
}
