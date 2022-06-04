using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    public class ticketGenerado
    {
        private string producto;
        private int cantidad;
        private decimal precioUnitario;
        private decimal total;
        private decimal descuento;
        private decimal totalPP;

        public ticketGenerado(string producto, int cantidad, decimal precioUnitario, decimal total, decimal descuento, decimal totalPP)
        {
            this.producto1 = producto;
            this.cantidad1 = cantidad;
            this.precioUnitario1 = precioUnitario;
            this.total1 = total;
            this.descuento1 = descuento;
            this.totalPP1 = totalPP;
        }

        public string producto1 { get; set; }
        public int cantidad1 { get; set; }
        public decimal precioUnitario1 { get; set; }
        public decimal total1 { get; set; }
        public decimal descuento1 { get; set; }
        public decimal totalPP1 { get; set; }
    }
}
