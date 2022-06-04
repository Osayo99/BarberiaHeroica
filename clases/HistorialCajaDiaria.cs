using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    class HistorialCajaDiaria
    {
        private int id;
        private float ingresototalporcorte;
        private float otros_ingresos;
        private float caja_inicial;
        private float total_ingresos;
        private float comision_general;
        private float descuentos;
        private float total_egresos;
        private float liquido;
        private float abonofondo_general;
        private float cierre_caja;
        private DateTime fecha;

        public HistorialCajaDiaria(/*int id,*/ float ingresototalporcorte, float otros_ingresos, float caja_inicial, float total_ingresos, float comision_general, float descuentos, float total_egresos, float liquido, float abonofondo_general, float cierre_caja, DateTime fecha)
        {
            //this.id = id;
            this.ingresototalporcorte = ingresototalporcorte;
            this.otros_ingresos = otros_ingresos;
            this.caja_inicial = caja_inicial;
            this.total_ingresos = total_ingresos;
            this.comision_general = comision_general;
            this.descuentos = descuentos;
            this.total_egresos = total_egresos;
            this.liquido = liquido;
            this.abonofondo_general = abonofondo_general;
            this.cierre_caja = cierre_caja;
            this.fecha = fecha;
        }

        public int Id { get => id; set => id = value; }
        public float Ingresototalporcorte { get => ingresototalporcorte; set => ingresototalporcorte = value; }
        public float Otros_ingresos { get => otros_ingresos; set => otros_ingresos = value; }
        public float Caja_inicial { get => caja_inicial; set => caja_inicial = value; }
        public float Total_ingresos { get => total_ingresos; set => total_ingresos = value; }
        public float Comision_general { get => comision_general; set => comision_general = value; }
        public float Descuentos { get => descuentos; set => descuentos = value; }
        public float Total_egresos { get => total_egresos; set => total_egresos = value; }
        public float Liquido { get => liquido; set => liquido = value; }
        public float Abonofondo_general { get => abonofondo_general; set => abonofondo_general = value; }
        public float Cierre_caja { get => cierre_caja; set => cierre_caja = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
