using AutoMapper;
using BP.Application.Mapper.Core;
using BP.Application.Services.Core;
using BP.Domain.Core.MdrAgg.Repository;
using BP.Domain.Core.TransactionAgg;
using BP.Domain.Core.TransactionAgg.Commands;
using BP.Domain.Core.TransactionAgg.Commands.Handlers;
using BP.Infra.Data.Repository;
using BP.Interface.Application.Core.MDR;
using BP.Interface.Application.Core.Transaction;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            // Domain - Commands
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
        }

        private static void RegisterMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(new MdrProfile());

                x.AllowNullCollections = true;
                x.AllowNullDestinationValues = true;
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
