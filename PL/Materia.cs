using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Materia
    {         
        public static void GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            if(result.Correct)
            {
                foreach (ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("IdMateria: " + materia.IdMateria);
                    Console.WriteLine("Nombre: " + materia.Nombre);
                    Console.WriteLine("Descripcion: " + materia.Descripcion);
                    Console.WriteLine("Creditos: " + materia.Creditos);
                    Console.WriteLine("Costo: " + materia.Costo);

                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error"+result.ErrorMessage);
            }
        }
        public static void Add()
        {

            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese el nombre: ");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el número de crédidos");

            materia.Creditos = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Ingrese los temas de la materia");

            materia.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el costo de la materia");

            materia.Costo = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Ingrese el Id del Semestre");

            materia.Semestre = new ML.Semestre();
            materia.Semestre.IdSemestre = Convert.ToByte(Console.ReadLine());
            
            //ML.Result result = BL.Materia.Add(materia);
            ML.Result result = BL.Materia.AddSP(materia);

            if (result.Correct)
            {
                Console.WriteLine("Se insertó correctamente la materia");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar la materia");
            }
        }

        public void Update()
        {

            //Id, Nombre, Creditos, Temas, Descripcion, Costo
            Console.WriteLine("Ingrese el ID de la materia de requiera modificar");

            int IdMateria = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre: ");
            string Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el número de crédidos");

            byte Creditos = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Ingrese los temas de la materia");

            string Temas = Console.ReadLine();





        }


        public void Delete()
        {

            //Id, Nombre, Creditos, Temas, Descripcion, Costo
            Console.WriteLine("Ingrese el ID de la materia de requiera modificar");

            int IdMateria = Convert.ToInt32(Console.ReadLine());




        }
    }
}
