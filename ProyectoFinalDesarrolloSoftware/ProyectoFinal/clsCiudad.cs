using System;
using System.Web.UI.WebControls;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsCiudad
    {
        #region Constructor
        public clsCiudad()
        {

        }
        #endregion
        #region Propieades/Atributos
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public Int32 Departamento { get; set; }
        public GridView grdCiudad { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarGrid()
        {
            //Se define el SQL
            SQL =  "SELECT       dbo.tblDepartamento.Codigo AS [COD DEP], dbo.tblDepartamento.Nombre AS DEPARTAMENTO, " +
                                "dbo.tblCiudad.Codigo AS [COD CIU], dbo.tblCiudad.Nombre AS CIUDAD, dbo.tblCiudad.Activo AS ACTIVO " +
                   "FROM         dbo.tblCiudad INNER JOIN " +
                                "dbo.tblDepartamento ON dbo.tblCiudad.CodigoDepartamento = dbo.tblDepartamento.Codigo " +
                   "ORDER BY    DEPARTAMENTO, CIUDAD ";

            //Se crea la instancia del grid
            clsGrid oGrid = new clsGrid();

            //Se pasan los parámetros del grid
            oGrid.SQL = SQL;

            //se pasa el nombre de la tabla
            oGrid.NombreTabla = "TablaGrid";

            //Se pasa el grid vacío
            oGrid.gridGenerico = grdCiudad;
            if (oGrid.LlenarGridWeb())
            {
                //Se lee el grid lleno
                grdCiudad = oGrid.gridGenerico;
                oGrid = null;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                oGrid = null;
                return false;
            }
        }
        public bool Insertar()
        {
            SQL = "INSERT INTO tblCiudad (Nombre, Activo, CodigoDepartamento) " +
                  "VALUES (@Nombre, @Activo, @Departamento)";
            
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Nombre", Nombre);
            oConexion.AgregarParametro("@Activo", Activo);
            oConexion.AgregarParametro("@Departamento", Departamento);

            if (oConexion.EjecutarSentencia())
            {
                oConexion = null;
                return true;
            }
            else
            {
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }
        public bool Actualizar()
        {
            SQL = "UPDATE       tblCiudad " +
                  "SET          Nombre = @Nombre, " +
                               "Activo = @Activo, " +
                               "CodigoDepartamento = @Departamento " +
                  "WHERE        Codigo = @Codigo ";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Codigo", Codigo);
            oConexion.AgregarParametro("@Nombre", Nombre);
            oConexion.AgregarParametro("@Activo", Activo);
            oConexion.AgregarParametro("@Departamento", Departamento);

            if (oConexion.EjecutarSentencia())
            {
                oConexion = null;
                return true;
            }
            else
            {
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }
        public bool Eliminar()
        {
            SQL = "DELETE FROM      tblCiudad " +
                  "WHERE            Codigo = @Codigo";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Codigo", Codigo);

            if (oConexion.EjecutarSentencia())
            {
                oConexion = null;
                return true;
            }
            else
            {
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }
        #endregion
    }
}
