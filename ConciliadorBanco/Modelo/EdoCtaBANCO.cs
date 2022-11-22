using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciliadorBanco.Modelo
{
    public class EdoCtaBANCO
    {
        public int Referencia { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public int Dia { get; set; }
        public string Clave { get; set; }   
        public int Movimiento { get; set; }
    }
}
