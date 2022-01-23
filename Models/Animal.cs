using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marfriing.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Preco { get; set; }
    }
}
