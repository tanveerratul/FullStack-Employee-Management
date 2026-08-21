using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add API Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configure SQLite Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=employees.db"));

// 3. Configure CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular default port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();
app.MapControllers();

app.Run();