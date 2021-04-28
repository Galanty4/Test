using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Repository;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Dto;

namespace WindowsFormsApp1.Service.TypeOfCarService
{
    /// <summary>
    /// Service type of car odpowiada za logikę biznesową wszystkic działań związanych z typo of car
    /// Services odpowiadaj za logikę biznesowa jego metoedy np. dostaja w parametrze jakieś dane które są interpretowane w ciele metody
    /// np. dostajemy paramiet 2 i 5 nasza metoda odpowaida za dodawanie  więc logika bedzie wykoanie działania 2+ 5 i zwracmey wtedy 7
    /// </summary>
    public class TypeOfCarSerivce : ITypeOfCarService
    {
        private readonly IGenericRepository<TypeOfCar> _genericRepository;

        public TypeOfCarSerivce(IGenericRepository<TypeOfCar> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public TypeOfCar AddTypeOfCar(TypeOfCarDto value)
        {
            var newTypeOfCar = new TypeOfCar() { Name = value.Name };
            _genericRepository.AddEntity(newTypeOfCar);
            //Trzeba pobrać nowo dodany item do bayz aby zwracalo z ID 
            return newTypeOfCar;
        }

        public TypeOfCar GetTypeOfCarById(int id)
        {
           return _genericRepository.GetEntityById(id);
        }
    }
}
