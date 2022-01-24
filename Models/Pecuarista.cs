using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marfriing.Models
{
    public class Pecuarista
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<CompraGado> compraGado;
        public ICollection<CompraGado> GetCompraGado()
        {
            return compraGado;
        }
        public void SetCompraGado(ICollection<CompraGado> value)
        {
            compraGado = value;
        }

    }
}
