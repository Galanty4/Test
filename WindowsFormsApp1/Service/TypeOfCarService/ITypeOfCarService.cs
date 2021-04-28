using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Dto;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Service.TypeOfCarService
{
    public interface ITypeOfCarService
    {
        public TypeOfCar GetTypeOfCarById(int id);
        public TypeOfCar AddTypeOfCar(TypeOfCarDto value);
    }
}
