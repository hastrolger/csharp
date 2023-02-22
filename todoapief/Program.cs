using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapief;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTasks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TasksContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("BD en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) => 
{
    return Results.Ok(dbContext.Tasks.Include(t => t.Category));
});

app.MapGet("/api/categories", async ([FromServices] TasksContext dbContext) => 
{
    return Results.Ok(dbContext.Categories);
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] todoapief.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreatedAt = DateTime.Now;
    await dbContext.Tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] todoapief.Task task, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);

    if(currentTask != null)
    {
        currentTask.CategoryId = task.CategoryId;
        currentTask.TaskName = task.TaskName;   
        currentTask.TaskDescription = task.TaskDescription;
        currentTask.TaskPriority = task.TaskPriority;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) => 
{
    var currentTask = dbContext.Tasks.Find(id);

    if(currentTask != null)
    {
        dbContext.Tasks.Remove(currentTask);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();   

});

app.Run();
