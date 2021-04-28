using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1.Repository
{
    /// <summary>
    /// Generyczny wzorzec repozytorium dzięki któremu można odezwać się do każdego modelu w bazie danych za pomocą tych samych metod
    /// Jego metody służą jedynie do komunikacja z bazą danych
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        private readonly MagazynContext magazynContext;

        public GenericRepository(MagazynContext magazynContext)
        {
            this.magazynContext = magazynContext;
        }

        public void AddEntity(Entity entity)
        {
            var result = magazynContext.Set<Entity>().Add(entity);
            magazynContext.SaveChanges();
        }

        public Entity GetEntityById(int id)
        {
            return magazynContext.Set<Entity>().Find(id);
        }
    }
}
