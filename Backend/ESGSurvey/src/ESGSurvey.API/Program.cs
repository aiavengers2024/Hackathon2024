using ESGSurvey.Data.BusinessObject;
using ESGSurvey.Data.Core;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.Configure<ConfigurationSettings>(builder.Configuration.GetSection("AzureAISearch"));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddApplicationInsightsTelemetry();

var aiOptions = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions();
// Disables adaptive sampling.
aiOptions.EnableAdaptiveSampling = false;
aiOptions.EnableQuickPulseMetricStream = false;
builder.Services.AddApplicationInsightsTelemetry(aiOptions);

builder.Services.AddTransient<IAzureAISearchServicesCore, AzureAISearchServicesCore>()
.AddTransient<IAzureAISearchServicesBO, AzureAISearchServicesBO>()
.AddTransient<IBlobServiceCore, BlobServiceCore>()
.AddTransient<IBlobServiceBO, BlobServiceBO>()
.AddTransient<IOpenAIServiceCore, OpenAIServiceCore>()
.AddTransient<IOpenAIServiceBO, OpenAIServiceBO>()
.AddSingleton<IConfigurationSettings, ConfigurationSettings>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin()
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
app.MapControllers();
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.Run();

