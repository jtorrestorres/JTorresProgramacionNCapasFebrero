using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class MateriaImagen
    {
        public int IdMateriaImagen { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public List<object> MateriasImagenes { get; set; }
    }
}
