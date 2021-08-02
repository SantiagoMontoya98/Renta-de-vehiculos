using System;
using libComunes.CapaObjetos;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsPoliza
    {

        #region Constructor

        public clsPoliza()
        {

        }

        #endregion

        #region Propiedades/Atributos

        public Int32 codigo { get; set; }

        public Int32  precio { get; set; }
        public DropDownList cboPoliza { get; set; }

        private string SQL;

        public string error { get; set; }

        #endregion

        #region Metodos

        public bool LlenarCombo()
        {

            SQL = "SELECT Codigo AS Valor, Nombre AS Texto " +
                       "FROM tblPoliza " +
                       "ORDER BY Texto";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboPoliza;

            oCombo.NombreTabla = "TablaMarca";

            oCombo.ColumnaValor = "Valor";

            oCombo.ColumnaTexto = "Texto";

            if (oCombo.LlenarComboWeb())
            {

                cboPoliza = oCombo.cboGenericoWeb;

                oCombo = null;

                return true;

            }
            else
            {

                error = oCombo.Error;

                oCombo = null;

                return false;

            }

        }

        public bool ConsultarPrecio()
        {

            SQL = "SELECT Precio FROM tblPoliza WHERE Codigo=@codigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@codigo", codigo);

            if (oConexion.Consultar())
            {

                if (oConexion.Reader.HasRows)
                {

                    oConexion.Reader.Read();

                    precio = oConexion.Reader.GetInt32(0);

                    oConexion.CerrarConexion();

                    oConexion = null;

                    return true;

                }
                else
                {

                    error = "La poliza consultada no existe " + codigo;

                    oConexion.CerrarConexion();

                    oConexion = null;

                    return false;

                }


            }
            else
            {

                error = oConexion.Error;

                oConexion = null;

                return false;

            }

        }

        #endregion

    }
}
