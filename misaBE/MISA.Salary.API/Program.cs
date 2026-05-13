using MISA.Salary.API.Middleware;
using MISA.Salary.BL.Services;
using MISA.Salary.DL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MISA Salary API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "http://localhost:3000",
                "http://localhost:4173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

// DL
builder.Services.AddScoped<ISalaryCompositionRepository>(
    _ => new SalaryCompositionRepository(connectionString));
builder.Services.AddScoped<ISalaryCompositionSystemRepository>(
    _ => new SalaryCompositionSystemRepository(connectionString));
builder.Services.AddScoped<IOrganizationRepository>(
    _ => new OrganizationRepository(connectionString));
builder.Services.AddScoped<IGridConfigRepository>(
    _ => new GridConfigRepository(connectionString));

// BL
builder.Services.AddScoped<ISalaryCompositionService, SalaryCompositionService>();
builder.Services.AddScoped<ISalaryCompositionSystemService, SalaryCompositionSystemService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IGridConfigService, GridConfigService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA Salary API v1"));
}

app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
