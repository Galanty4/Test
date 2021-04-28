using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Repository;
using WindowsFormsApp1.Service.TypeOfCarService;

namespace WindowsFormsApp1
{
    static class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var services = new ServiceCollection();
            RegisterServie(services);

            //zbudowanie dostawcy
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }

        private static void RegisterServie(IServiceCollection services)
        {
            // Dodanie ustawienie domyœlnej œcie¿ki i zarejestroanie user secretsów
            Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddUserSecrets(typeof(Program).Assembly)
            .Build();

            // wstrzykniêcie zale¿noœci DI
            services.AddSingleton<Form1>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ITypeOfCarService,TypeOfCarSerivce>();
            services.AddDbContext<MagazynContext>(option => option.UseSqlServer(Configuration.GetConnectionString("MagazynDB")));
        }
    }
}
