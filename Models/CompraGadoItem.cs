using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marfriing.Models
{
    public class CompraGadoItem
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public int IdCompraGado { get; set; }
        public virtual CompraGado CompraGado { get; set; }

        [Required(ErrorMessage = "Animal é obrigatorio.")]
        public int IdAnimal { get; set; }
        public virtual Animal Animal { get; set; }
       




    }
}
