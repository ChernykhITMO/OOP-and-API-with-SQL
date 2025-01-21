using LaboratoryWork5.Adapters;
using LaboratoryWork5.Ports.Ports;
using Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Itmo.ObjectOrientedProgramming.Lab5;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ListenLocalhost(5001);
        });

        builder.Services.AddControllers()
            .AddApplicationPart(Assembly.Load("LaboratoryWork5.Adapters"));

        const string connectionString = "Host=localhost;Port=54321;Username=postgres;Password=postgres;Database=postgres";
        builder.Services.AddScoped<OperationValidator>();
        builder.Services.AddSingleton<IAccountRepository>(new AccountRepository(connectionString));
        builder.Services.AddScoped<IAccountFacade, AccountFacade>();
        builder.Services.AddScoped<IAccountLogicService, AccountLogicService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATM API V1");
            c.RoutePrefix = string.Empty;
        });

        app.MapControllers();

        app.Run();
    }
}
