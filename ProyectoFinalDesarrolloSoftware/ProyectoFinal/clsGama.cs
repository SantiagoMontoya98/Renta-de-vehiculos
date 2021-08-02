﻿using System;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsGama
    {
        //agregar la referencia System.Web
        //agregar la directiva: using System.Web.UI.WebControls;
        //agregar la referencia de libComunes
        //agregar la directiva: libcomunes.CapaDatos (para el crud)
        //agregar la directiva: libcomunes.CapaObjetos (para el el combo y el grid)
        #region Constructor
        public clsGama()
        {

        }
        #endregion

        #region Propiedades/Atributos
        
        public DropDownList CboGama { get; set; }

        private String SQL;

        public String Error { get; private set; }

        #endregion

        #region Metodos
        public bool LlenarCombo()
        {
            //Instrucción SQL para llenar el combo
            SQL = "SELECT       Codigo AS Valor, Nombre AS Texto " +
                    "FROM       tblGama " +
                    "ORDER BY   Texto";

            //instanciar la clase clsCombo
            clsCombos oCombo = new clsCombos();

            //pasar SQL con texto y valor para llenar el combo
            oCombo.cboGenericoWeb = CboGama; // como oCombo es del tipo de dato DropDownList
            oCombo.SQL = SQL;
            oCombo.NombreTabla = "tblCombo";
            oCombo.ColumnaTexto = "Texto";
            oCombo.ColumnaValor = "Valor";

            //Invocación del metodo LlenarCombo
            if (oCombo.LlenarComboWeb())
            {
                CboGama = oCombo.cboGenericoWeb;
                oCombo = null;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                oCombo = null;
                return false;

            }


        }

        #endregion
    }
}