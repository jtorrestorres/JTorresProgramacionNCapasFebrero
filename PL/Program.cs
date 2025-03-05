using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object X = "Kevin";
            object Y = 20;
            object Z = true;
            object A = 20.3; //Boxing

            int Edad = 28;

            Console.WriteLine((decimal)A); //Unboxing
            Console.WriteLine((bool)X); //PRIMITIVO


            ML.Materia materia = new ML.Materia();

            materia.Nombre = "Inglés IV";
            materia.Creditos = 15;



            object Q = materia;


            Console.WriteLine(((ML.Materia)Q).Nombre  //COMPLEJO         );






            // PL.Materia.GetAll();
             

    }
    }
}
