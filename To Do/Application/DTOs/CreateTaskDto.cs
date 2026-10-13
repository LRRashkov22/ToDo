using To_Do.Domain.Enums;

namespace To_Do.Application.DTOs
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string Desctiption { get; set; } = string.Empty;
        public Priority _priority { get; set; }
    }
}
