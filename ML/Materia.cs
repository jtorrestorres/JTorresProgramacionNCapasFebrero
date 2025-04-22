using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string Nombre { get; set; }

        public byte Creditos { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public string Prueba { get; set; }
        public ML.Semestre Semestre { get; set; }
        public string FechaRegistro { get; set; }

        public byte[] Imagen { get; set; }
        public string Action { get; set; } //Add, Update

        public List<object> Materias { get; set; }

        public ML.Grupo Grupo { get; set; }

        public ML.MateriaImagen MateriaImagen { get; set; }

        //1-1, 1-m , M:N
    } 

}
