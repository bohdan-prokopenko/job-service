using JobService.Domain.Configuration;
using JobService.Domain.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomain();
builder.Services.AddControllers();
builder.Services.Configure<CalculatorConfig>(builder.Configuration.GetSection("CalculatorSettings"));

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseRouting()
    .UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
