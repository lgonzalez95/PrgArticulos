using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class clsUsuario
    {
        #region atributos
        //permite las sentencias del SQL Transact
        private string strSentencia;
        //Permite enviar la ejecución de la sentencia al modelo en la clase conexion
        clsConexionSQL conexion= new clsConexionSQL();
        #endregion

        #region
        public SqlDataReader mConsultarUsuario(Modelo.clsConexionSQL cone, Modelo.clsEntidadUsuario pEntidadUsuario)
        {
            strSentencia = "Select * from tbUsuarios where codigo=  '" + pEntidadUsuario.getCodigo() + "' and clave='" + pEntidadUsuario.getClave() + "' ";
            return conexion.mSeleccionar(strSentencia, cone);
        }
        #endregion;
    }
}
