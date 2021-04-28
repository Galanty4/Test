using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Service.TypeOfCarService;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ITypeOfCarService _typeOfCarService;

        /// <summary>
        /// Dzięki DI w klasie program mamy uzupęłnione serwisy
        /// </summary>
        /// <param name="typeOfCarService"></param>
        public Form1(ITypeOfCarService typeOfCarService)
        {
            _typeOfCarService = typeOfCarService;
            InitializeComponent();
        }

        /// <summary>
        /// Testowa metoda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var value = _typeOfCarService.GetTypeOfCarById(1);
            Console.WriteLine(value.Id);
        }
    }
}
