using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        private readonly MagazynContext magazynContext;

        public GenericRepository(MagazynContext magazynContext)
        {
            this.magazynContext = magazynContext;
        }

        public async Task<Entity> GetEntityById(int id)
        {
            return await magazynContext.Set<Entity>().FindAsync(id);
        }


    }
}
