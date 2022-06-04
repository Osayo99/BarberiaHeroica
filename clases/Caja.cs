using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    public class Caja
    {
        string codCaja;

        public string CodCaja
        {
            get { return codCaja; }
            set { codCaja = value; }
        }
        string saldoTotal;

        public string SaldoTotal
        {
            get { return saldoTotal; }
            set { saldoTotal = value; }
        }

        string nombreCaja;

        public string NombreCaja
        {
            get { return nombreCaja; }
            set { nombreCaja = value; }
        }

        string codUsuario;

        public string CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; }
        }


        int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Caja()
        {
            codCaja = "";
            saldoTotal = "";
            nombreCaja = "";
            codUsuario = "";

        }

        public Caja(string cod, string sald, string nom, string codUsu)
        {
            codCaja = cod;
            saldoTotal = sald;
            nombreCaja = nom;
            codUsuario = codUsu;

        }
        

    }
}
