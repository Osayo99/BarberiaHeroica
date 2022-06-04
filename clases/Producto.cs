using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    class Producto
    {
        private int id_producto;
        private string nombre_producto;
        private int cant_existencia;
        private decimal precio_unitario;
        private decimal precio_mayorista;

        public Producto()
        {

        }
        public Producto(int id_producto, string nombre_producto, int cant_existencia, decimal precio_unitario, decimal precio_mayorista)
        {
            this.id_producto1 = id_producto;
            this.nombre_producto1 = nombre_producto;
            this.cant_existencia1 = cant_existencia;
            this.precio_unitario1 = precio_unitario;
            this.precio_mayorista1 = precio_mayorista;
        }

        public int id_producto1 { get => id_producto; set => id_producto = value; }
        public string nombre_producto1 { get => nombre_producto; set => nombre_producto = value; }
        public int cant_existencia1 { get => cant_existencia; set => cant_existencia = value; }
        public decimal precio_unitario1 { get => precio_unitario; set => precio_unitario = value; }
        public decimal precio_mayorista1 { get => precio_mayorista; set => precio_mayorista = value; }
    }
}
