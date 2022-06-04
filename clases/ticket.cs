using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    class ticket
    {
        private int id_ticket;
        private decimal total_final;
        private DateTime fecha;
        private int id_producto;
        private string total_venta;
        private string descuento;
        private string recibido;
        private string cambio;
        private string unitario;
        private string totalPP;
        private string cantidadPP;

        public ticket(int id_ticket, decimal total_final, DateTime fecha, int id_producto, string total_venta, string descuento, string recibido, string cambio, string unitario, string totalPP, string cantidadPP)
        {
            this.id_ticket1 = id_ticket;
            this.total_final1 = total_final;
            this.fecha1 = fecha;
            this.id_producto1 = id_producto;
            this.total_venta1 = total_venta;
            this.descuento1 = descuento;
            this.recibido1 = recibido;
            this.cambio1 = cambio;
            this.unitario1 = unitario;
            this.totalPP1 = totalPP;
            this.cantidadPP1 = cantidadPP;
        }

        public int id_ticket1 { get; set; }
        public decimal total_final1 { get; set; }
        public DateTime fecha1 { get; set; }
        public int id_producto1 { get; set; }
        public string total_venta1 { get; set; }
        public string descuento1 { get; set; }
        public string recibido1 { get; set; }
        public string cambio1 { get; set; }
        public string unitario1 { get; set; }
        public string totalPP1 { get; set; }
        public string cantidadPP1 { get; set; }
    }
}
