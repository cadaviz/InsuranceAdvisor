using InsuranceAdvisor.IoC;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
     options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

     var enumConverter = new JsonStringEnumConverter(JsonNamingPolicy.CamelCase);
     options.JsonSerializerOptions.Converters.Add(enumConverter);
 });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInternalServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
