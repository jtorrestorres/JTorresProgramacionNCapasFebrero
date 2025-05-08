using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Semestre
    {
        [Display(Name ="Semestre")]
        public byte IdSemestre { get; set; }

        [Required]
        public string Nombre { get; set; }

        public List<object> Semestres { get; set; } //UNICA PARA EL DROP DOWN LIST
    }
}
