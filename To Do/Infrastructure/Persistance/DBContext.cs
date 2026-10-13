using Microsoft.EntityFrameworkCore;
using To_Do.Domain.Entities;
namespace To_Do.Infrastructure.Persistance;

public class BContext : DbContext
{
    public BContext(DbContextOptions<BContext> options) : base(options) { }

    public DbSet<ToDoTask> toDoTask => Set<ToDoTask>();
}
