using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsRegistroReserva
    {

        #region Constructor

        public clsRegistroReserva()
        {



        }

        #endregion
        #region Propiedades/Atributos

        public Int32 codigo { get; set; }

        public string cedulaCliente { get; set; }

        public string placaVehiculo { get; set; }

        public Int32 IDSede { get; set; }

        public Int32 IDPoliza { get; set; }

        public DateTime fechaInicial { get; set; }

        public DateTime fechaFinal { get; set; }

        public Int32 numeroDias { get; set; }

        public Int32 precio { get; set; }

        public GridView grdRegistroReserva { get; set; }

        private string SQL;

        public string error { get; set; }

        #endregion
        #region Metodos

        public bool Insertar()
        {

            SQL = "INSERT INTO tblReserva (CedulaCliente, PlacaVehiculo, IDSede, " +
                       "IDPoliza, FechaInicial, FechaFinal, NumeroDias, Precio) " +
                       "VALUES (@CedulaCliente, @PlacaVehiculo, @IDSede, @IDPoliza, " +
                       "@FechaInicial, @FechaFinal, @NumeroDias, @Precio)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@CedulaCliente", cedulaCliente);

            oConexion.AgregarParametro("@PlacaVehiculo", placaVehiculo);            

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

            SQL = "UPDATE tblReserva " +
                       "SET CedulaCliente=@CedulaCliente, " +
                       "IDPoliza=@IDPoliza, FechaInicial=@FechaInicial, " +
                       "FechaFinal=@FechaFinal, NumeroDias=@NumeroDias, Precio=@Precio " +
                       "WHERE Codigo=@Codigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@Codigo", codigo);

            oConexion.AgregarParametro("@CedulaCliente", cedulaCliente);                    
                       
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

            SQL = "DELETE FROM tblReserva WHERE Codigo=@Codigo";

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
                       "dbo.tblCliente.Apellidos AS[NOMBRE CLIENTE], dbo.tblVehiculo.Descripcion AS VEHICULO, " +
                       "dbo.tblReserva.FechaInicial AS[FECHA INICIAL], dbo.tblReserva.FechaFinal AS[FECHA FINAL], " +
                       "dbo.tblReserva.NumeroDias AS[NUMERO DIAS], dbo.tblSede.Nombre AS[NOMBRE SEDE], " +
                       "dbo.tblPoliza.Nombre AS[TIPO POLIZA], dbo.tblReserva.Precio AS[PRECIO RESERVA], " +
                       "dbo.tblReserva.Codigo AS[CODIGO RESERVA], dbo.tblReserva.IDPoliza AS[CODIGO POLIZA] " +
                       "FROM dbo.tblCliente INNER JOIN " +
                       "dbo.tblReserva ON dbo.tblCliente.Cedula = dbo.tblReserva.CedulaCliente INNER JOIN " +
                       "dbo.tblVehiculo ON dbo.tblReserva.PlacaVehiculo = dbo.tblVehiculo.Placa INNER JOIN " +
                       "dbo.tblSede ON dbo.tblReserva.IDSede = dbo.tblSede.Codigo AND dbo.tblVehiculo.IDSede " +
                       "= dbo.tblSede.Codigo " +
                       "INNER JOIN dbo.tblPoliza ON dbo.tblReserva.IDPoliza = dbo.tblPoliza.Codigo ";
                       

            clsGrid oGrid = new clsGrid();

            oGrid.SQL = SQL;

            oGrid.NombreTabla = "TablaVehiculos";

            oGrid.gridGenerico = grdRegistroReserva;

            if (oGrid.LlenarGridWeb())
            {

                grdRegistroReserva = oGrid.gridGenerico;

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
                       "FROM dbo.tblReserva " +
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
