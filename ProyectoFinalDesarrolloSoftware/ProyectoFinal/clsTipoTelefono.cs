using System;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsTipoTelefono
    {
        #region Constructor
        public clsTipoTelefono()
        {

        }
        #endregion

        #region Propiedades / Atributos
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public DropDownList cboTipoTelefono { get; set; }
        private string SQL;
        public string Error { get; private set; }


        #endregion

        #region Metodos
        public bool LlenarCombo()
        {
            SQL = "SELECT        Codigo AS Valor, Nombre AS Texto " +
                   "FROM         tblTipoTelefono " +
                   "ORDER BY     Texto; ";

            // Se crea la instancia de la clase 
            clsCombos oCombo = new clsCombos();
            // Se paasan los parametros: Nombre tabla, el combo generico, la instrucción SQL y el combo vacío
            oCombo.NombreTabla = "TablaCombo";
            oCombo.SQL = SQL;
            oCombo.cboGenericoWeb = cboTipoTelefono;  //Combo vacío
            oCombo.ColumnaTexto = "Texto";
            oCombo.ColumnaValor = "Valor";

            if (oCombo.LlenarComboWeb())
            {
                // Capturo combo de tipo telefono, libero memoria y retorno true
                cboTipoTelefono = oCombo.cboGenericoWeb;
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
