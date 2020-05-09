using DWork.CollegeSystem.Infrastructure.Identity;
using DWork.CollegeSystem.Infrastructure.Persistence;
using DWork.CollegeSystem.WebUI;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sample.IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;
        private static string _currentUserId;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var services = new ServiceCollection();
            var startup = new Startup(_configuration);

            //for Identity services will get object reference error
            //it looking for iwebhostenvironment
            //best solution is to create mock
            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.ApplicationName == "DWork.CollegeSystem.WebUI" &&
                w.EnvironmentName == "Development"
            ));
            startup.ConfigureServices(services);

            //to get mediatr,dbcontext we need scopefactory for test isolation

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };
        }
        //reset database to clean slate
        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));
        }

        public static async Task<string> RunAsDefaultUserAsync()
        {
            return await RunAsUserAsync("test@local", "Testing1234!");
        }

        public static async Task<string> RunAsUserAsync(string userName, string password)
        {
            //using var scope = _scopeFactory.CreateScope();

            //var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

            //var user = new ApplicationUser { UserName = userName, Email = userName };
            //var result = await userManager.CreateAsync(user, password);
            //_currentUserId = user.Id;

            //return _currentUserId;
            await Task.CompletedTask;
            return string.Empty;
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Add(entity);//new ef core: dont need to specify the type
            await context.SaveChangesAsync();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediatR = scope.ServiceProvider.GetService<IMediator>();

            return await mediatR.Send(request);
        }

        public static async Task<TEntity> FindAsync<TEntity, TType>(TType id, string includes = "")
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            var entity = await context.FindAsync<TEntity>(id);
            if (includes != "")
                await context.Entry(entity).Collection(includes).LoadAsync();

            return entity;
        }
    }
}
