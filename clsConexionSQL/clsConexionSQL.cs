using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; // Retornar de system de windows el nombre de la maquina
using System.Data.SqlClient;    // accesos a la BD (incluir, modificar, consultar y eliminar (IMEC))

namespace Modelo
{
    public class clsConexionSQL
    {
        //Area de declaracion de todas las variables
        #region Atributos
        private string codigo;
        private string clave;
        private string perfil;

        private string baseDatos;
        private SqlConnection conexion; //Guardar la cadena de conexión del usuario con la BD
        private SqlCommand comando; // permite ejecutar IMEC


        #endregion

        //Establecemos el método inicial
        #region Costructor
        public clsConexionSQL()
        {
            this.codigo = "";
            this.clave = "";
            this.perfil = "";
            this.baseDatos = "BDEstudiantes";
            
        }
        #endregion

        //Propiedades de lectura y escritura
        #region GetySet

        public void setCodigo(String codigo){
            this.codigo = codigo.Trim();
        }

        public string getCodigo(){
            return this.codigo;
        }

        public void setClave(string clave){
            this.clave = clave.Trim();        
        }

        public string getClave(){
            return this.clave;
        }

        public void setPerfil(string perfil){
            this.perfil = perfil.Trim();
        }

        public string getPerfil(){
            return this.perfil;
        }

        #endregion


        //Métodos para la conección de la base de datos
        #region Metodos

        //este método permitirá ejecutar los selects
        public  SqlDataReader mSeleccionar(string strSentencia, clsConexionSQL cone){

            try{

                if (mConectar(cone)){

                    comando = new SqlCommand(strSentencia,conexion);
                    comando.CommandType = System.Data.CommandType.Text;
                    
                    //El executeReader ejecuta solo select
                    return comando.ExecuteReader();
                }
                else               
                    return null;
                
            }
            catch {
                return null;
            }
        }//Fin del metodo mSeleccionar

        //Este método permitirá ejecutar los insert, update y delete
        public Boolean mEjecutar(string strSentencia, clsConexionSQL cone)
        {
            try
            {
                if (mConectar(cone))
                {
                    comando = new SqlCommand(strSentencia, conexion);
                    comando.ExecuteNonQuery();//ejecutar cualquier tipo de consulta
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        //Este método nos permite abrir y conectarnos a la BD
        public Boolean mConectar(clsConexionSQL cone)
        {
            try
            {
                conexion = new SqlConnection();
                conexion.ConnectionString="user id='"+cone.getCodigo()+"';password='"+cone.getClave()+"'; Data Source='"+mNomServidor()+"'; Initial Catalog='"+this.baseDatos+"'";
                conexion.Open();
                return true;

            }catch{
                return false;
            }

        }//Fin del método


        //Este método obtiene el nombre de la máquina de windows
        public string mNomServidor()
        {
            return Dns.GetHostName();
        }
        #endregion




    }
}
