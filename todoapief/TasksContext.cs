using Microsoft.EntityFrameworkCore;

namespace todoapief;

public class TasksContext: DbContext 
{
    public DbSet<Category> Categories {get; set;}
    public DbSet<Task> Tasks {get; set;}

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
    
    // metodo que se invoca para la creacion de bd - se sobreescribe
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
        List<Category> categoryInit = new List<Category>();
        categoryInit.Add(new Category() {
            CategoryId = Guid.Parse("d78cfb1d-1f0a-4f55-bca5-0e78ea11252d"),
            CategoryName = "Personal activities",
            CategoryDescription = "Kind if personal activities",
            Weight = 15, 
        });
         categoryInit.Add(new Category() {
            CategoryId = Guid.Parse("5c6a28dc-c167-4b7d-aa7b-0f37f7e67f97"),
            CategoryName = "Job activities",
            CategoryDescription = "Kind of job activities",
            Weight = 10, 
        });
        
        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.CategoryName).IsRequired().HasMaxLength(150);
            category.Property(p => p.CategoryDescription);
            category.Property(p => p.Weight);
            category.HasData(categoryInit);
        });

        List<Task> taskInit = new List<Task>();
        taskInit.Add(new Task() {
            TaskId = Guid.Parse("02c30a2d-3850-47e4-beb2-28a6d853ca39"),
            CategoryId = Guid.Parse("d78cfb1d-1f0a-4f55-bca5-0e78ea11252d"),
            TaskName = "Do the dishes",
            TaskDescription = "Do the dish before go the bed",
            TaskPriority = Priority.Low,
            CreatedAt = DateTime.Now,
        });
         taskInit.Add(new Task() {
            TaskId = Guid.Parse("4be134e4-c867-481e-9410-21fdb296e7e9"),
            CategoryId = Guid.Parse("5c6a28dc-c167-4b7d-aa7b-0f37f7e67f97"),
            TaskName = "Prepare report of service",
            TaskDescription = "Report of the monitoring service",
            TaskPriority = Priority.High,
            CreatedAt = DateTime.Now,
        });

        modelBuilder.Entity<Task>(task => {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.TaskName).IsRequired().HasMaxLength(150);
            task.Property(p => p.TaskDescription);
            task.Property(p => p.TaskPriority);
            task.Property(p => p.CreatedAt);
            task.Ignore(p => p.Summary);
            task.HasData(taskInit);
        });
    }
}