using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    public class Movimiento
    {
        string codMovimiento;

        public string CodMovimiento
        {
            get { return codMovimiento; }
            set { codMovimiento = value; }
        }
        string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        string monto;

        public string Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        int estado;

        string codCaja;

        public string CodCaja
        {
            get { return codCaja; }
            set { codCaja = value; }
        }
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Movimiento()
        {
            codMovimiento = "";
            tipo = "";
            fecha = "";
            descripcion = "";
            monto = "";
            codCaja = "";
        }

        public Movimiento(string tip, string mon, string des, string fec, string codC)
        {
            tipo = tip;
            monto = mon;
            descripcion = des;
            fecha=fec;
            codCaja = codC;
        }


    }
}
