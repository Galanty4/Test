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

namespace WindowsFormsApp1
{
    public class Startup
    {

        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;

            var service = new ServiceCollection();
            var context = new MagazynContext();
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddDbContext<MagazynContext>(option => option.UseSqlServer(configuration.GetConnectionString()))
        }
    }
}
