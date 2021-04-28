using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Repository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Entity GetEntityById(int id);
        void AddEntity(Entity entity);

    }
}
