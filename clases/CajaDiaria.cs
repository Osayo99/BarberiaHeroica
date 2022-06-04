using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    class CajaDiaria
    {
        private int id_caja;
        private float caja_inicial;
        private float caja_final;
        private string fecha;

        //public CajaDiaria(int id_caja, float caja_inicial, float caja_final, string fecha)
        //{
        //    this.id_caja = id_caja;
        //    this.caja_inicial = caja_inicial;
        //    this.caja_final = caja_final;
        //    this.fecha = fecha;
        //}

        public int Id_caja { get => id_caja; set => id_caja = value; }
        public float Caja_inicial { get => caja_inicial; set => caja_inicial = value; }
        public float Caja_final { get => caja_final; set => caja_final = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
