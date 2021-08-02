using System;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;
using libComunes.CapaDatos;


namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsDevolucion
    {
        #region Constructor
        public clsDevolucion()
        {
            
        }
        #endregion
        #region Propiedades/Atributos
        public Int32 Codigo { get; set; }
        public String CedulaCliente { get; set; }
        public String PlacaVehiculo { get; set; }
        public Int32 IDCargoEmpleado { get; set; }
        public Int32 IDSede { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Int32 KilometrajeFinalVehiculo { get; set; }

        public Int32 KilometrosRecorridos { get; set; }

        public GridView grdDevolucion { get; set; }

        private String SQL;
        public String Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarGrid()
        {
            //Instrucción SQL para llenar el grid
            SQL = "SELECT dbo.tblDevolucion.CedulaCliente AS [CEDULA CLIENTE], dbo.tblCliente.Nombres " +
                       "+ ' ' + dbo.tblCliente.Apellidos AS [NOMBRE CLIENTE], dbo.tblVehiculo.Descripcion AS VEHICULO, " +
                       "dbo.tblDevolucion.PlacaVehiculo AS[PLACA VEHICULO], dbo.tblDevolucion.FechaEntrega AS" +
                       "[FECHA ENTREGA], dbo.tblEmpleado.Nombres + ' ' + dbo.tblEmpleado.Apellidos AS" +
                       "[NOMBRE EMPLEADO], dbo.tblDevolucion.KilometrajeFinalVehiculo AS" +
                       "[KILOMETRAJE FINAL VEHICULO], dbo.tblDevolucion.KilometrosRecorridos AS" +
                       "[KILOMETROS RECORRIDOS POR EL CLIENTE], dbo.tblDevolucion.Codigo AS" +
                       "[CODIGO DEVOLUCION], dbo.tblCargoEmpleado.Codigo AS[CODIGO CARGO EMPLEADO]" +                       
                       "FROM dbo.tblCliente INNER JOIN " +
                       "dbo.tblDevolucion ON dbo.tblCliente.Cedula = dbo.tblDevolucion.CedulaCliente INNER JOIN " +
                       "dbo.tblVehiculo ON dbo.tblDevolucion.PlacaVehiculo = dbo.tblVehiculo.Placa INNER JOIN " +
                       "dbo.tblCargoEmpleado ON dbo.tblDevolucion.IDCargoEmpleado = " +
                       "dbo.tblCargoEmpleado.Codigo INNER JOIN " +
                       "dbo.tblEmpleado ON dbo.tblCargoEmpleado.CedulaEmpleado = dbo.tblEmpleado.Cedula";

            //instanciar la clase clsGrid
            clsGrid oGrid = new clsGrid();

            //pasar SQL con texto y valor para llenar el combo
            oGrid.SQL = SQL;
            oGrid.NombreTabla = "tablaGrid";
            oGrid.gridGenerico = grdDevolucion;

            //Invocación del metodo LlenarGrid
            if (oGrid.LlenarGridWeb())
            {
                grdDevolucion = oGrid.gridGenerico;
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

            SQL = "INSERT INTO tblDevolucion (CedulaCliente, PlacaVehiculo, IDCargoEmpleado, " +
                       "IDSede, FechaEntrega, KilometrajeFinalVehiculo, KilometrosRecorridos) " +
                       "VALUES(@CedulaCliente, @PlacaVehiculo, " +
                       "@IDCargoEmpleado, @IDSede, @FechaEntrega, @KilometrajeFinalVehiculo, " +
                       "@KilometrosRecorridos)";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;            
            oConexion.AgregarParametro("@CedulaCliente", CedulaCliente);
            oConexion.AgregarParametro("@PlacaVehiculo", PlacaVehiculo);
            oConexion.AgregarParametro("@IDCargoEmpleado", IDCargoEmpleado);
            oConexion.AgregarParametro("@IDSede", IDSede);
            oConexion.AgregarParametro("@FechaEntrega", FechaEntrega);
            oConexion.AgregarParametro("@KilometrajeFinalVehiculo", KilometrajeFinalVehiculo);
            oConexion.AgregarParametro("@KilometrosRecorridos", KilometrosRecorridos);

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

        public bool ActualizarKilometrajeVehiculo()
        {

            SQL = "UPDATE tblVehiculo SET KilometrajeInicial=@KilometrajeFinalVehiculo, " +
                "KilometrajeFinal=@KilometrajeFinalVehiculo " +
                "WHERE Placa=@PlacaVehiculo";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;            
            oConexion.AgregarParametro("@KilometrajeFinalVehiculo", KilometrajeFinalVehiculo);
            oConexion.AgregarParametro("@PlacaVehiculo", PlacaVehiculo);

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

            SQL = "UPDATE tblDevolucion " +
                    "SET        CedulaCliente = @CedulaCliente, " +
                                "PlacaVehiculo = @PlacaVehiculo, " +
                                "IDCargoEmpleado = @IDCargoEmpleado, " +
                                "IDSede = @IDSede, " +
                                "FechaEntrega = @FechaEntrega, " +
                                "KilometrajeFinalVehiculo = @KilometrajeFinalVehiculo," +
                                "KilometrosRecorridos=@KilometrosRecorridos " +
                    "WHERE      Codigo = @Codigo";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Codigo", Codigo);
            oConexion.AgregarParametro("@CedulaCliente", CedulaCliente);
            oConexion.AgregarParametro("@PlacaVehiculo", PlacaVehiculo);
            oConexion.AgregarParametro("@IDCargoEmpleado", IDCargoEmpleado);
            oConexion.AgregarParametro("@IDSede", IDSede);
            oConexion.AgregarParametro("@FechaEntrega", FechaEntrega);
            oConexion.AgregarParametro("@KilometrajeFinalVehiculo", KilometrajeFinalVehiculo);
            oConexion.AgregarParametro("@KilometrosRecorridos", KilometrosRecorridos);


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
        public bool Borrar()
        {

            SQL = "DELETE FROM  tblDevolucion " +
                  "WHERE  Codigo = @Codigo";

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
