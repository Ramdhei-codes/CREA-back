using CREA_back_application.DataAccess;
using CREA_back_application.Services;
using CREA_back_application.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IListClassroomsService, ListClassroomsService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IReadClassroomsFileService, ReadClassroomsFileService>();
builder.Services.AddDbContext<ClassroomsDbContext>(options => options.UseSqlite(connectionString, b => b.MigrationsAssembly("CREA-back")), ServiceLifetime.Transient);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
