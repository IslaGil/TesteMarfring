using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marfriing.Models
{
    public class CompraGado
    {
        public int Id { get; set; }
        public int IdPecuarista { get; set; }
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
