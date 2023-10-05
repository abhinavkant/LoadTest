using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SampleApp;
using Prometheus;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Formatting.Compact;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new RenderedCompactJsonFormatter())
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console(new RenderedCompactJsonFormatter()));

// Add services to the container.

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidIssuer = builder.Configuration["Jwt:Issuer"],
//         ValidAudience = builder.Configuration["Jwt:Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = false,
//         ValidateIssuerSigningKey = true
//     };

//     Console.WriteLine(builder.Configuration["Jwt:Issuer"]);
//     Console.WriteLine(builder.Configuration["Jwt:Audience"]);
// });

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//         .AddJwtBearer(options =>
//         {
//             options.RequireHttpsMetadata = true;
//             options.SaveToken = true;

//             // API Authenticator Endpoint
//             options.SetJwksOptions(new JwkOptions(
//                 builder.Configuration["JwksUri"],
//                 builder.Configuration["Jwt:Issuer"],
//                 TimeSpan.FromMinutes(15)
//             ));
//         });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient(Options.DefaultName)
    .UseHttpClientMetrics();

var app = builder.Build();

app.UseSerilogRequestLogging(options =>
{
    // Customize the message template
    options.MessageTemplate = "Handled {RequestPath}";

    // Emit debug-level events instead of the defaults
    // options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

    // Attach additional properties to the request completion event
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
        diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
    };
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
app.UseAuthorization();

app.UseMetricServer();
app.MapControllers();
app.UseHttpMetrics();

app.Run();
