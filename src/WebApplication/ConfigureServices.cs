using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Entities;
using Gateways.Storages;
using Usecases.Contracts;
using Usecases.Boundaries.Inputs;
using Usecases.Boundaries.Outputs;
using Usecases;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Collections.Generic;

namespace WebApplication
{
    public static class ServicesConfig
    {

        
        private const string CONNECTION_STRING = "CONNECTION_STRING";
        private const string SUPPLIER_DATABASE = "DATABASE";
        private const string SUPPLIER_REPOSITORY = "SUPPLIER_REPOSITORY";

        private const string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        private const string SANDBOX = "Sandbox";

        public static void Drivers(IServiceCollection services)
        {

            if (IsEnvironment(SANDBOX))
            {
                return;
            }

            var client = new MongoClient( GetEnvironmentVariable(CONNECTION_STRING) );
            var database = client.GetDatabase( GetEnvironmentVariable(SUPPLIER_DATABASE) );
            var supplierCollection = database.GetCollection<Supplier>( GetEnvironmentVariable(SUPPLIER_REPOSITORY) );

            services.AddSingleton(supplierCollection);
        }

        public static void Controllers(IServiceCollection services)
        {
            var assembly = Assembly.Load(new AssemblyName("Controllers"));
            services
                .AddControllers( _ => _.Filters.Add( new HttpResponseExceptionFilter() ))
                    .AddControllersAsServices()
                        .AddApplicationPart(assembly);
        }

        public static void Gateways(IServiceCollection services)
        {
            if ( IsEnvironment(SANDBOX) ) 
            {
                services.AddSingleton<IStorableSupplier, SupplierInMemoryRepository>();
                return;
            }

            services.AddSingleton<IStorableSupplier, SupplieRepository>();
        }

        public static void Usecases(IServiceCollection services)
        {
            services.AddTransient<IHandleable<string, SupplierOutput>, QuerySupplier>();
            services.AddTransient<IHandleable<SupplierInput, SupplierIdOutput>, SupplierRegistry>();
        }


        private static string GetEnvironmentVariable(string key) 
            => Environment.GetEnvironmentVariable(key);

        private static bool IsEnvironment(string env)
            => Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT).Equals(env);
    }
}
