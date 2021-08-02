using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsEmpleado
    {

        #region Constructor

        public clsEmpleado()
        {

        }

        #endregion

        #region Propiedades/Atributos               

        public DropDownList cboEmpleado { get; set; }

        private string SQL;

        public string error { get; set; }

        #endregion

        #region Metodos

        public bool LlenarCombo()
        {

            SQL = "SELECT dbo.tblCargoEmpleado.Codigo AS Valor, " +
                       "dbo.tblEmpleado.Nombres + ' ' + dbo.tblEmpleado.Apellidos AS Texto " +
                       "FROM dbo.tblCargo INNER JOIN " +
                       "dbo.tblCargoEmpleado ON dbo.tblCargo.Codigo = dbo.tblCargoEmpleado.IDCargo INNER JOIN " +
                       "dbo.tblEmpleado ON dbo.tblCargoEmpleado.CedulaEmpleado = dbo.tblEmpleado.Cedula " +
                       "WHERE dbo.tblCargo.Codigo = 2";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboEmpleado;            

            oCombo.NombreTabla = "TablaMarca";

            oCombo.ColumnaValor = "Valor";

            oCombo.ColumnaTexto = "Texto";

            if (oCombo.LlenarComboWeb())
            {

                cboEmpleado = oCombo.cboGenericoWeb;

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

        #endregion

    }
}
