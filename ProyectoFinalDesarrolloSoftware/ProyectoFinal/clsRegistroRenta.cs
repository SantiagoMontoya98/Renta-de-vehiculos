using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsRegistroRenta
    {

        #region Constructor

        public clsRegistroRenta()
        {
        
        
        
        }
        
        #endregion
        #region Propiedades/Atributos

        public Int32 codigo { get; set; }

        public string cedulaCliente { get; set; }

        public string placaVehiculo { get; set; }

        public Int32 IDSede { get; set; }

        public Int32 IDPoliza { get; set; }

        public Int32 IDCargoEmpleado { get; set; }

        public DateTime fechaInicial { get; set; }

        public DateTime fechaFinal { get; set; }

        public Int32 numeroDias { get; set; }

        public Int32 precio { get; set; }

        public GridView grdRegistroRenta { get; set; }

        private string SQL;

        public string error { get; set; }

        #endregion
        #region Metodos

        public bool Insertar()               
        {

            SQL = "INSERT INTO tblRenta (CedulaCliente, PlacaVehiculo, IDCargoEmpleado, IDSede, " +
                       "IDPoliza, FechaInicial, FechaFinal, NumeroDias, Precio) " +
                       "VALUES (@CedulaCliente, @PlacaVehiculo, @IDCargoEmpleado, @IDSede, @IDPoliza, " +
                       "@FechaInicial, @FechaFinal, @NumeroDias, @Precio)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@CedulaCliente", cedulaCliente);

            oConexion.AgregarParametro("@PlacaVehiculo", placaVehiculo);

            oConexion.AgregarParametro("@IDCargoEmpleado", IDCargoEmpleado);

            oConexion.AgregarParametro("@IDSede", IDSede);

            oConexion.AgregarParametro("@IDPoliza", IDPoliza);

            oConexion.AgregarParametro("@FechaInicial", fechaInicial);

            oConexion.AgregarParametro("@FechaFinal", fechaFinal);

            oConexion.AgregarParametro("@NumeroDias", numeroDias);

            oConexion.AgregarParametro("@Precio", precio);

            if (oConexion.EjecutarSentencia())
            {

                oConexion = null;

                return true;

            }
            else
            {

                error = oConexion.Error;

                oConexion = null;

                return false;

            }

        }

        public bool Actualizar()
        {

            SQL = "UPDATE tblRenta " +
                       "SET CedulaCliente=@CedulaCliente, " +
                       "IDCargoEmpleado=@IDCargoEmpleado, IDPoliza=@IDPoliza, " +
                       "FechaInicial=@FechaInicial, FechaFinal=@FechaFinal, NumeroDias=@NumeroDias, Precio=@Precio " +
                       "WHERE Codigo=@Codigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@Codigo", codigo);

            oConexion.AgregarParametro("@CedulaCliente", cedulaCliente);            

            oConexion.AgregarParametro("@IDCargoEmpleado", IDCargoEmpleado);            

            oConexion.AgregarParametro("@IDPoliza", IDPoliza);

            oConexion.AgregarParametro("@FechaInicial", fechaInicial);

            oConexion.AgregarParametro("@FechaFinal", fechaFinal);

            oConexion.AgregarParametro("@NumeroDias", numeroDias);

            oConexion.AgregarParametro("@Precio", precio);

            if (oConexion.EjecutarSentencia())
            {

                oConexion = null;

                return true;

            }
            else
            {

                error = oConexion.Error;

                oConexion = null;

                return false;

            }            

        }

        public bool Eliminar()
        {

            SQL = "DELETE FROM tblRenta WHERE Codigo=@Codigo";                     
                       
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@Codigo", codigo);
                        
            if (oConexion.EjecutarSentencia())
            {

                oConexion = null;

                return true;

            }
            else
            {

                error = oConexion.Error;

                oConexion = null;

                return false;

            }

        }

        public bool LlenarGrid()
        {

            SQL = "SELECT dbo.tblCliente.Cedula AS [CEDULA CLIENTE], dbo.tblCliente.Nombres + ' ' + " +
                       "dbo.tblCliente.Apellidos AS [NOMBRE CLIENTE], dbo.tblVehiculo.Descripcion AS VEHICULO, " +
                       "dbo.tblRenta.FechaInicial AS [FECHA INICIAL], dbo.tblRenta.FechaFinal AS[FECHA FINAL], " +
                       "dbo.tblRenta.NumeroDias AS[NUMERO DIAS], dbo.tblEmpleado.Nombres + ' ' + "+
                       "dbo.tblEmpleado.Apellidos AS[NOMBRE EMPLEADO], dbo.tblSede.Nombre AS[NOMBRE SEDE], " +
                       "dbo.tblPoliza.Nombre AS[TIPO POLIZA], dbo.tblRenta.Precio AS[PRECIO RENTA], " +
                       "dbo.tblRenta.Codigo AS[CODIGO RENTA], dbo.tblCargoEmpleado.Codigo " +
                       "AS[CODIGO CARGO EMPLEADO], dbo.tblRenta.IDPoliza AS[CODIGO POLIZA] " +
                       "FROM dbo.tblCliente INNER JOIN " + 
                       "dbo.tblRenta ON dbo.tblCliente.Cedula = dbo.tblRenta.CedulaCliente INNER JOIN " +
                       "dbo.tblVehiculo ON dbo.tblRenta.PlacaVehiculo = dbo.tblVehiculo.Placa INNER JOIN " +
                       "dbo.tblCargoEmpleado ON dbo.tblRenta.IDCargoEmpleado = dbo.tblCargoEmpleado.Codigo " +
                       "INNER JOIN dbo.tblEmpleado ON dbo.tblCargoEmpleado.CedulaEmpleado = " +
                       "dbo.tblEmpleado.Cedula INNER JOIN dbo.tblSede ON dbo.tblRenta.IDSede = " +
                       "dbo.tblSede.Codigo AND dbo.tblVehiculo.IDSede = dbo.tblSede.Codigo AND " +
                       "dbo.tblCargoEmpleado.IDSede = dbo.tblSede.Codigo INNER JOIN  " +
                       "dbo.tblPoliza ON dbo.tblRenta.IDPoliza = dbo.tblPoliza.Codigo";

            clsGrid oGrid = new clsGrid();

            oGrid.SQL = SQL;

            oGrid.NombreTabla = "TablaVehiculos";

            oGrid.gridGenerico = grdRegistroRenta;

            if (oGrid.LlenarGridWeb())
            {

                grdRegistroRenta = oGrid.gridGenerico;

                oGrid = null;

                return true;

            }
            else
            {

                error = oGrid.Error;

                oGrid = null;

                return false;

            }

        }

        public bool ConsultarPrecio()
        {

            SQL = "SELECT        Precio " +
                       "FROM dbo.tblRenta " +
                       "WHERE(CedulaCliente = @cedulaCliente) AND(PlacaVehiculo = @placaVehiculo)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@cedulaCliente", cedulaCliente);

            oConexion.AgregarParametro("@placaVehiculo", placaVehiculo);

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

                    precio = 0;

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
