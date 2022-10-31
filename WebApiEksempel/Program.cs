using WebApiEksempel.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ITodoService, TodoService>();

builder.Services.AddEndpointsApiExplorer(); // ADDED
builder.Services.AddSwaggerGen(); // ADDED

var app = builder.Build();

// Configure the HTTP request pipeline.

#region Swagger Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // ADDED
    app.UseSwaggerUI(); // ADDED
}
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
