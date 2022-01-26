using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marfriing.Models
{
    public class CompraGado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* Pecuarista é Obrigatorio.")]
        public int IdPecuarista { get; set; }

        [Required(ErrorMessage = "* Preenchimento obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }

        public ICollection<CompraGadoItem> compraGadoItem;
        public ICollection<CompraGadoItem> GetCompraGadoItem()
        {
            return compraGadoItem;
        }
        public void SetCompraGadoItem(ICollection<CompraGadoItem> value)
        {
            compraGadoItem = value;
        }

    }
}
