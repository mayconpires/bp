using AutoMapper;
using BP.Application.Mapper.Core;
using BP.Application.Services.Core;
using BP.Domain.Core.MdrAgg.Repository;
using BP.Domain.Core.TransactionAgg;
using BP.Domain.Core.TransactionAgg.Commands;
using BP.Domain.Core.TransactionAgg.Commands.Handlers;
using BP.Domain.Core.TransactionAgg.Repository;
using BP.Domain.Shared.Notification;
using BP.Infra.Data.Repository;
using BP.Infra.Log.Loggers;
using BP.Interface.Application.Core.MDR;
using BP.Interface.Application.Core.Transaction;
using CorrelationId;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.IoC.Setup
{
    public class Injector
    {

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterApplication(services);
            RegisterRepository(services);
            RegisterMapper(services);
            RegisterCommandHandler(services);
            RegisterDomainService(services);
            RegisterCrossCutting(services);
            RegisterLogging(services, configuration);
        }

        private static void RegisterLogging(IServiceCollection services, IConfiguration configuration)
        {
            var file = configuration["LogConfiguration:LogDirectoryName"] + "\\" + configuration["LogConfiguration:LogFileName"] + ".txt";
            var sistema = configuration["BP:Sistema"];

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
               .Enrich.FromLogContext()
               .Enrich.WithProperty("Sistema", sistema)
               //.WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] ({Sistema}) ({Operacao}) {Message}{NewLine}{Exception}{NewLine}")
               .WriteTo.File(path: file,
                             rollingInterval: RollingInterval.Day,
                             outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] ({Sistema}) ({Operacao}) {Message}{NewLine}{Exception}{NewLine}")
               .CreateLogger();
        }

        private static void RegisterCrossCutting(IServiceCollection services)
        {
            services.AddSingleton<ILogUtil, LogUtil>();
        }

        private static void RegisterCommandHandler(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateTransactionCommand, Transaction>, TransactionCommandHandler>();
        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IMdrService, MdrService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IMdrRepository, MdrRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }

        private static void RegisterMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(new MdrProfile());
                x.AddProfile(new TransactionProfile());

                x.AllowNullCollections = true;
                x.AllowNullDestinationValues = true;
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }

        private static void RegisterDomainService(IServiceCollection services)
        {
            services.AddScoped<INotificationDomainService, NotificationDomainService>();
        }
    }
}
