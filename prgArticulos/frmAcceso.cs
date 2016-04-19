using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Llamado de las referencias propias del proyecto
using System.Data.SqlClient;
using Modelo;
using Controlador;


namespace prgArticulos
{
    public partial class frmAcceso : Form
    {
        #region
        clsConexionSQL conexion;
        clsEntidadUsuario pEntidadUsuario;
        clsUsuario usuario;
        SqlDataReader dtrUsuario; //Retorno de las tuplas
        int contador = 0;              
        #endregion

        //Inicializamos los atributos que utilizaremos en toda la clase
        public frmAcceso()
        {
            conexion = new clsConexionSQL();
            pEntidadUsuario = new clsEntidadUsuario();
            usuario = new clsUsuario();
            InitializeComponent();
        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {//no borrar


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Acción para salir del sistema
            Application.Exit();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                //Focus traslada el cursor del mouse al espacio indicado
                this.txtClave.Focus();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (mValidarDatos() == true)
                {
                    this.btnIngresar.Enabled = true;
                }
                else
                {

                }
            }
        }//Fin del keyPress


        #region Metodos
        //Este método permite validar la existencia del usuario segun
        //el codigo y clave digitada
        public Boolean mValidarDatos()
        {
            if (contador <= 2)
            {
                //llenado de variables o atributos del servidor para conectarme a la BD
                conexion.setCodigo("admEstudiante");
                conexion.setClave("123");

                //llenado de los atributos de la clase EntidadUsuario
                pEntidadUsuario.setCodigo(this.txtUsuario.Text.Trim());
                pEntidadUsuario.setClave(this.txtClave.Text.Trim());

                //Consultamos si el usuario existe
                dtrUsuario = usuario.mConsultarUsuario(conexion, pEntidadUsuario);

                //Evaluamos si retorna tuplas o datos
                if (dtrUsuario != null)
                {
                    if (dtrUsuario.Read())
                    {

                        pEntidadUsuario.setPerfil(dtrUsuario.GetString(2));//Posicion 2 xq es donde se almacenan los perfiles en la BD
                        pEntidadUsuario.setEstado(dtrUsuario.GetInt32(3));
                        if (pEntidadUsuario.getEstado() == 0)
                        {
                            this.btnIngresar.Enabled = true;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("El usuario esta bloqueado", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Information);
                            return false;
                        }//Fin del pEntidadUsuario
                    }
                    else {
                        MessageBox.Show("El usuario no existe", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }//Fin del if del Read  
                }
                else {
                    MessageBox.Show("El usuario no existe", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }//Fin del if del null

            }
            else {
                MessageBox.Show("Usted dijito 3 veces su usuario de forma erronea","Usuario bloqueado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }//Fin del if del contador
        }//Fin del metodo mValidarDatos
        #endregion

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            mdiMenu menu = new mdiMenu(conexion);
            menu.Show();
        }
    }
}
