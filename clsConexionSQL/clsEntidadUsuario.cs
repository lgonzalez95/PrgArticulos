﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
  public class clsEntidadUsuario
    {

        //Region de los atributos

        #region Atributos
        private string codigo;
        private string clave;
        private string perfil;
        private int estado;
        #endregion


        #region Propiedades

        //Métodos set 
        public void setCodigo(string codigo)
        {
            this.codigo = codigo.Trim();
        }
        public void setClave(string clave)
        {
            this.clave = clave.Trim();
        }
        public void setPerfil(string perfil)
        {
            this.perfil = perfil.Trim();
        }
        public void setEstado(int estado)
        {
            this.estado = estado;
        }

        //Métodos get
        public string getCodigo()
        {
            return this.codigo;
        }     
        public string getClave()
        {
            return this.clave;
        }
        public string getPerfil()
        {
            return this.perfil;
        }
        public int getEstado()
        {
            return this.estado;
        }
        #endregion

        #region constructor
        public clsEntidadUsuario()
        {
            this.codigo = "";
            this.clave = "";
            this.perfil = "";
            this.estado = 0;
        }
        #endregion

    }
}//Fin de la clase
