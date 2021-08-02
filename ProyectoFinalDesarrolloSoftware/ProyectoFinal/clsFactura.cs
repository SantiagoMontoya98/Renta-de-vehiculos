using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsFactura
    {

        #region Constructor

        public clsFactura()
        {

        }

        #endregion

        #region Propiedades/Atributos    

        public Int32 numeroFactura { get; set; }

        public string cedulaCliente { get; set; }

        public string placaVehiculo { get; set; }

        public Int32 IDCargoEmpleado { get; set; }

        private string SQL;

        public GridView grdFactura { get; set; }

        public string error { get; set; }

        #endregion

        #region Metodos

        public bool ConsultarNumeroFactura()
        {

            SQL = "SELECT isnull(MAX(NumeroFactura),0)+1 as NumeroFactura " +
                       "FROM tblFactura";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            if (oConexion.Consultar())
            {

                if (oConexion.Reader.HasRows)
                {

                    oConexion.Reader.Read();

                    numeroFactura = oConexion.Reader.GetInt32(0);                    

                    oConexion.CerrarConexion();

                    oConexion = null;

                    return true;

                }
                else
                {

                    error = "No pudo generar el numero de la factura";

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

        public bool GrabarFactura()
        {
            //Grabar en la tabla tblDetalleFactura
            //Grabar en la tabla tblFactura                      

                SQL = "INSERT INTO tblFactura (NumeroFactura, CedulaCliente, PlacaVehiculo, Fecha, IDCargoEmpleado) " +
                      "VALUES (@NumeroFactura, @CedulaCliente, @PlacaVehiculo, @Fecha, @IDCargoEmpleado)";

                //Se crea la conexión a la BD
                clsConexion oConexion = new clsConexion();

                //Se pasa el SQL
                oConexion.SQL = SQL;
                //Se definen los parámetros de la consulta
                oConexion.AgregarParametro("@NumeroFactura", numeroFactura);
                oConexion.AgregarParametro("@CedulaCliente", cedulaCliente);
                oConexion.AgregarParametro("@PlacaVehiculo", placaVehiculo);
                oConexion.AgregarParametro("@Fecha", DateTime.Now);
                oConexion.AgregarParametro("@IDCargoEmpleado", IDCargoEmpleado);

                if (oConexion.EjecutarSentencia())
                {
                    //La sentencia ejecutó correctamente, se debe liberar memoria y retornar true
                    oConexion = null;
                    return true;
                }
                else
                {
                    //Hubo un error, se debe leer de la clase conexión,liberar memoria y retornar false
                    error = oConexion.Error;
                    oConexion = null;
                    return false;
                }
                            
        }




        public bool EliminarFactura()
        {
            //Actualiza en la tabla tblDetalleFactura
            SQL = "DELETE FROM       tblFactura " +
                    "WHERE        NumeroFactura= @NumeroFactura";

            //Se crea la conexión a la BD
            clsConexion oConexion = new clsConexion();

            //Se pasa el SQL
            oConexion.SQL = SQL;
            //Se definen los parámetros de la consulta
            oConexion.AgregarParametro("@NumeroFactura", numeroFactura);

            if (oConexion.EjecutarSentencia())
            {
                
                //La sentencia ejecutó correctamente, se debe liberar memoria y retornar true
                oConexion = null;
                return true;
            }
            else
            {
                //Hubo un error, se debe leer de la clase conexión,liberar memoria y retornar false
                error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }





        public bool ActualizarFactura()
        {
            //Actualiza en la tabla tblDetalleFactura
            SQL = "UPDATE       tblFactura " +
                    "SET          CedulaCliente=@CedulaCliente, " +
                                 "PlacaVehiculo=@PlacaVehiculo " +
                                 "Fecha = @Fecha " +
                                 "IDCargoEmpleado=@IDCargoEmpleado, " +
                    "WHERE        NumeroFactura=@NumeroFactura";

            //Se crea la conexión a la BD
            clsConexion oConexion = new clsConexion();

            //Se pasa el SQL
            oConexion.SQL = SQL;
            //Se definen los parámetros de la consulta
            oConexion.AgregarParametro("@CedulaCliente", cedulaCliente);
            oConexion.AgregarParametro("@PlacaVehiculo", placaVehiculo);
            oConexion.AgregarParametro("@Fecha", DateTime.Now);
            oConexion.AgregarParametro("@NumeroFactura", numeroFactura);

            if (oConexion.EjecutarSentencia())
            {
                
                //La sentencia ejecutó correctamente, se debe liberar memoria y retornar true
                oConexion = null;
                return true;
            }
            else
            {
                //Hubo un error, se debe leer de la clase conexión,liberar memoria y retornar false
                error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }

        public bool LlenarGrid()
        {
            //Instrucción SQL para llenar el grid
            SQL = "";

            //instanciar la clase clsCombo
            clsGrid oGrID = new clsGrid();

            //pasar SQL con texto y valor para llenar el combo
            oGrID.SQL = SQL;
            oGrID.NombreTabla = "tablaGrid";
            oGrID.gridGenerico = grdFactura;

            //Invocación del metodo LlenarCombo
            if (oGrID.LlenarGridWeb())
            {
                grdFactura = oGrID.gridGenerico;
                oGrID = null;
                return true;
            }
            else
            {
                error = oGrID.Error;
                oGrID = null;
                return false;

            }


        }



        #endregion


    }
}
