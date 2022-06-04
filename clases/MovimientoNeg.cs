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
    public class MovimientoNeg
    {
        MovimientoDat objMovDat;
        CajaDat objCajaDat;

        public MovimientoNeg()
        {
            objMovDat = new MovimientoDat();
            objCajaDat = new CajaDat();
        }

        public void RegistrarMovimiento(Movimiento objMov, Caja objCaja)
        {
            bool verificar;
            //verificar que exista una Caja, ERROR=45
            Caja objCajaT2 = new Caja();
            objCajaT2.CodCaja = objMov.CodCaja;
            verificar = !objCajaDat.SelectCaja(objCajaT2);
            if (verificar)
            {
                objMov.Estado = 45;
                return;
            }

            //Verificar monto sea numérico, ERROR =3
            double nMonto = 0.0;
            try
            {
                nMonto = double.Parse(objMov.Monto);
            }
            catch
            {
                //si entra aquí, significa que cantidad no es un valor numérico, por lo tanto no se registrará CotiDetalle.
                objMov.Estado = 3;
                return;
            }
            //Verificar monto sea mayor a cero, ERROR =2
            verificar = double.Parse(objMov.Monto)>0.0;
            if (!verificar)
            {
                objMov.Estado = 2;
                return;
            }

            //verificar descripcion no sea nulo, ERROR =4
            verificar = objMov.Descripcion.Equals("");
            if (verificar)
            {
                objMov.Estado = 4;
                return;
            }
                
            

            //De no haber ningún error, hace lo siguiente:
            objMov.Monto = "" + nMonto;
            double actualSaldo = double.Parse(objCajaT2.SaldoTotal);
            double nuevoSaldo = 0.0;

            if (objMov.Tipo.Equals("0")){
                objMov.Tipo = "Ingreso";
                nuevoSaldo = actualSaldo + double.Parse(objMov.Monto);
                objCaja.SaldoTotal = nuevoSaldo + "";
            }
                
            else
                if (objMov.Tipo.Equals("1")) {
                    objMov.Tipo = "Egreso";
                    nuevoSaldo = actualSaldo - double.Parse(objMov.Monto);
                    objCaja.SaldoTotal = nuevoSaldo + "";
                   }

            verificar = nuevoSaldo >= 0;
            if (!verificar)
            {
                objMov.Estado = 11;
                return;
            }

            //Insertar un movimiento
            objMovDat.InsertMovimiento(objMov);        
            objCajaDat.UpdateCaja(objCaja); //se actualiza la caja
            objMov.Estado = 99;

        }

        public void ActualizarMovimiento(Movimiento objMov, Caja objCaja)
        {
            bool verificar;
            //verificar que el movimiento exista, ERROR = 0
            Movimiento objMovT = new Movimiento();
            objMovT.CodMovimiento = objMov.CodMovimiento;
            verificar = objMovDat.SelectMovimiento(objMovT);
            if(!verificar)
            {
                objMov.Estado = 1;
                return;
            }
            //verificar que la caja exista, ERROR = 45
            Caja objCajaT2 = new Caja();
            objCajaT2.CodCaja = objCaja.CodCaja;
            verificar = !objCajaDat.SelectCaja(objCajaT2);
            if (verificar)
            {
                objMov.Estado = 45;
            }

            //Verificar monto sea mayor a cero, ERROR =2;
            verificar = double.Parse(objMov.Monto) > 0.0;
            if (!verificar)
            {
                objMov.Estado = 2;
                return;
            }

            //Verificar monto sea numérico, ERROR =3
            double nMonto = 0.0;
            try
            {
                nMonto = double.Parse(objMov.Monto);
            }
            catch
            {
                //si entra aquí, significa que cantidad no es un valor numérico, por lo tanto no se registrará CotiDetalle.
                objMov.Estado = 3;
                return;
            }

            //verificar descripcion no sea nulo
            verificar = objMov.Descripcion.Equals("");
            if(verificar)
            {
                objMov.Estado = 4;
                return;
            }

            //De no haber ningún error, hace lo siguiente:
            objMov.Monto = "" + nMonto;
             //actualiza el movimiento

            double actualSaldo = double.Parse(objCajaT2.SaldoTotal);
            double nuevoSaldo = 0.0;
            switch (objMov.Tipo)
            {
                case "Ingreso":
                    {
                        nuevoSaldo = actualSaldo - double.Parse(objMovT.Monto)+ double.Parse(objMov.Monto);
                        objCaja.SaldoTotal = nuevoSaldo + "";
                    } break;
                case "Egreso":
                    {
                        nuevoSaldo = actualSaldo + double.Parse(objMovT.Monto) - double.Parse(objMov.Monto);
                        objCaja.SaldoTotal = nuevoSaldo + "";
                    } break;
            }
            verificar = nuevoSaldo >= 0;
            if (!verificar)
            {
                objMov.Estado = 11;
                return;
            }

            objMovDat.UpdateMovimiento(objMov);
            objCaja.SaldoTotal = ""+nuevoSaldo;
            objCajaDat.UpdateCaja(objCaja);
            objMov.Estado = 99;
        }

        public void EliminarMovimiento(Movimiento objMov, Caja objCaja)
        {
            bool verificar;
            //Verficar que el movimiento exista
            Movimiento objMovT = new Movimiento();
            objMovT.CodMovimiento = objMov.CodMovimiento;
            verificar = objMovDat.SelectMovimiento(objMovT);
            if(!verificar)
            {
                objMov.Estado = 0;
                return;
            }

            //verificar que la caja exista, ERROR = 1
            Caja objCajaT2 = new Caja();
            objCajaT2.CodCaja = objCaja.CodCaja;
            verificar = !objCajaDat.SelectCaja(objCajaT2);
            if (verificar)
            {
                objMov.Estado = 1;
            }

            //De no haber ningún error, hace lo siguiente:
            double actualSaldo = double.Parse(objCajaT2.SaldoTotal);
            double nuevoSaldo = 0.0;
            switch (objMov.Tipo)
            {
                case "Ingreso":
                    {
                        nuevoSaldo = actualSaldo - double.Parse(objMov.Monto);
                        objCaja.SaldoTotal = nuevoSaldo + "";
                    } break;
                case "Egreso":
                    {
                        nuevoSaldo = actualSaldo + double.Parse(objMov.Monto);
                        objCaja.SaldoTotal = nuevoSaldo + "";
                    } break;
            }

            verificar = nuevoSaldo >= 0;
            if (!verificar)
            {
                objMov.Estado = 12;
                return;
            }

            objCajaDat.UpdateCaja(objCaja);//actualiza la cabecera
            objMovDat.DeleteMovimiento(objMov);//elimina el movimiento
            objMov.Estado = 99;//OK
        }

        //Muestra 1 movimiento
        public bool LeerMovimiento(Movimiento objMov)
        {
            return objMovDat.SelectMovimiento(objMov);
        }

        //Muestra todos los ingresos por fecha
        public DataTable LeerIngresos(Movimiento objMov)
        {
            return objMovDat.SelectMovimientoIngresosPorFecha(objMov);
        }
        //Muestra todos los egresos por fecha
        public DataTable LeerEgresos(Movimiento objMov)
        {
            return objMovDat.SelectMovimientoEgresosPorFecha(objMov);
        }

        //Muestra todos los ingresos y egresos por fecha
        public DataTable LeerIngresosEgresos(Movimiento objMov)
        {
            return objMovDat.SelectMovimientosPorFecha(objMov);
        }

        //Muestra todos los ingresos y egreso por mes
        public DataTable LeerIngresosEgresosMes(string fec)
        {
            return objMovDat.SelectMovimientosPorMes(fec);
        }

        public DataTable LeerIngresosMes(string fec)
        {
            return objMovDat.SelectMovimientoIngresosPorMes(fec);
        }

        public DataTable LeerEgresosMes(string fec)
        {
            return objMovDat.SelectMovimientoEgresosPorMes(fec);
        }
    }
}
