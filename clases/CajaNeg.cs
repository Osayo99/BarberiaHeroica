using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberH.clases;
using BarberH.CRUDs;
using BarberH.conexion;
using System.Data;

namespace BarberH.clases
{
    public class CajaNeg
    {
        CajaDat objCajaDat;
        MovimientoDat objMovDat;

        public CajaNeg()
        {
            objCajaDat = new CajaDat();
            objMovDat = new MovimientoDat();
        }

        //ACTUALIZAR CAJA
        public void ActualizarCaja(Caja objCaja)
        {
            //actualiza solo si la informacion es correcta
            
            objCajaDat.UpdateCaja(objCaja);
            objCaja.Estado = 99;
        }

       

        public bool LeerUltimaCaja(Caja objCaja)
        {
            return objCajaDat.SelectUltimaCaja(objCaja);
        }
        
    }
}
