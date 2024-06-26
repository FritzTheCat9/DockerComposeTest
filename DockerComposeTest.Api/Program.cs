var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DockerTest.Api");
        options.RoutePrefix = string.Empty;
    });
}

//app.UseHttpsRedirection();

app.MapGet("/api", () =>
{
    return "Api 1";
})
.WithName("GetApi")
.WithOpenApi();

app.Run();
