using FeedbackApp.Infrastructure.Extensions;
using FeedbackApp.Application.Extensions;
using FeedbackApp.API.Extensions;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirSwagger", policy =>
    {
        policy.WithOrigins(
            "https://localhost:7235",
            "http://localhost:5233"
            )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddCustomAuthorization()
    .AddJwtAuthentication(builder.Configuration)
    .AddSwagger();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("PermitirSwagger");
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerUIIfDev();
app.MapControllers();
app.Run();
