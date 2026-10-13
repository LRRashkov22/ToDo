using System.ComponentModel.DataAnnotations;
using To_Do.Domain.Enums;

namespace To_Do.Domain.Entities;

public class ToDoTask
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool isDone { get; set; }
    public Priority _priority { get; set; }
}
