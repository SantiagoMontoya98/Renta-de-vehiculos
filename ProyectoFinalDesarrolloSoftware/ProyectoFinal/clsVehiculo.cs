using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsVehiculo
    {

        #region Constructor

        public clsVehiculo()
        {
                       

        }

        #endregion
        #region Propiedades/Atributos

        public string placaVehiculo { get; set; }

        public string Descripcion { get; set; }

        public Int32 KilometrajeInicial { get; set; }

        public Int32 KilometrajeFinal { get; set; }

        public Int32 IDSede { get; set; }

        public Int32 IDMarca { get; set; }

        public Int32 IDGama { get; set; }

        public Int32 IDColor { get; set; }

        public Int32 IDTipoVehiculo { get; set; }

        public GridView grdVehiculo { get; set; }

        public Int32 precio { get; set; }         
        
        private string SQL;

        public string error { get; set; }

        #endregion
        #region Metodos

        public bool ConsultarPrecio() 
        {

            SQL = "SELECT Precio FROM tblVehiculo WHERE Placa=@placaVehiculo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

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

                    error = "No hay informacion para el vehiculo consultado " + placaVehiculo;

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

        public bool LlenarGrid()
        {
            //Instrucción SQL para llenar el grid
            SQL = "SELECT   Placa, Descripcion AS 'Vehiculo', KilometrajeInicial, KilometrajeFinal, " +
                       "tblMarca.Nombre AS 'Marca', tblGama.Nombre AS 'Gama', tblColor.Nombre AS 'Color', " +
                       "tblTipoVehiculo.Nombre AS 'Tipo Vehiculo', Precio AS 'Precio Por 1 Dia De Renta', " +
					   "tblSede.Nombre AS 'Nombre Sede', tblMarca.Codigo AS 'Codigo Marca', " +
					   "tblGama.Codigo AS 'Codigo Gama', tblColor.Codigo AS 'Codigo Color', " +
					   "tblTipoVehiculo.codigo AS 'Codigo Tipo Vehiculo' " +
                       "FROM tblMarca, tblGama, tblColor, tblTipoVehiculo, tblVehiculo, tblSede " +
                       "WHERE tblMarca.Codigo = tblVehiculo.IDMarca " +
                       "AND tblGama.Codigo = tblVehiculo.IDGama " +
                       "AND tblColor.Codigo = tblVehiculo.IDColor " +
                       "AND tblSede.Codigo = tblVehiculo.IDSede " +
                       "AND tblTipoVehiculo.Codigo = tblVehiculo.IDTipoVehiculo " +
                       "ORDER BY[Tipo Vehiculo]";

            //instanciar la clase clsCombo
            clsGrid oGrID = new clsGrid();

            //pasar SQL con texto y valor para llenar el combo
            oGrID.SQL = SQL;
            oGrID.NombreTabla = "tablaGrid";
            oGrID.gridGenerico = grdVehiculo;

            //Invocación del metodo LlenarCombo
            if (oGrID.LlenarGridWeb())
            {
                grdVehiculo = oGrID.gridGenerico;
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

        public bool Insertar()
        {

            SQL = "INSERT INTO tblVehiculo (Placa, Descripcion, KilometrajeInicial, KilometrajeFinal, IDSede, " +
                                            "IDMarca, IDGama, IDColor, Precio, IDTipoVehiculo) " +
                    "VALUES(@Placa, @Descripcion, @KilometrajeInicial, @KilometrajeFinal, @IDSede, " +
                    "@IDMarca, @IDGama, @IDColor, @Precio, @IDTipoVehiculo)";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Placa", placaVehiculo);
            oConexion.AgregarParametro("@Descripcion", Descripcion);
            oConexion.AgregarParametro("@KilometrajeInicial", KilometrajeInicial);
            oConexion.AgregarParametro("@KilometrajeFinal", KilometrajeFinal);
            oConexion.AgregarParametro("@IDSede", IDSede);
            oConexion.AgregarParametro("@IDMarca", IDMarca);
            oConexion.AgregarParametro("@IDGama", IDGama);
            oConexion.AgregarParametro("@IDColor", IDColor);
            oConexion.AgregarParametro("@Precio", precio);
            oConexion.AgregarParametro("@IDTipoVehiculo", IDTipoVehiculo);

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

            SQL = "UPDATE tblVehiculo " +
                    "SET     Descripcion=@Descripcion, " +
                                "KilometrajeInicial = @KilometrajeInicial, " +
                                "KilometrajeFinal = @KilometrajeFinal, " +
                                "IDMarca = @IDMarca, " +
                                "IDGama = @IDGama, " +
                                "IDColor = @IDColor, " +
                                "Precio = @Precio, " +
                                "IDTipoVehiculo = @IDTipoVehiculo " +
                    "WHERE      Placa = @Placa";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Placa", placaVehiculo);
            oConexion.AgregarParametro("@Descripcion", Descripcion);
            oConexion.AgregarParametro("@KilometrajeInicial", KilometrajeInicial);
            oConexion.AgregarParametro("@KilometrajeFinal", KilometrajeFinal);
            oConexion.AgregarParametro("@IDMarca", IDMarca);
            oConexion.AgregarParametro("@IDGama", IDGama);
            oConexion.AgregarParametro("@IDColor", IDColor);
            oConexion.AgregarParametro("@Precio", precio);
            oConexion.AgregarParametro("@IDTipoVehiculo", IDTipoVehiculo);


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
        public bool Borrar()
        {

            SQL = "DELETE FROM  tblVehiculo " +
                  "WHERE  Placa = @Placa";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Placa", placaVehiculo);

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

        public bool ConsultarKilometrajeInicial()
        {

            SQL = "SELECT KilometrajeInicial " +
                       "FROM tblVehiculo " +
                       "WHERE Placa=@PlacaVehiculo";

            clsConexion oConexion = new clsConexion();                        

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@PlacaVehiculo", placaVehiculo);

            if (oConexion.Consultar())
            {

                if (oConexion.Reader.HasRows)
                {

                    oConexion.Reader.Read();

                    KilometrajeInicial = oConexion.Reader.GetInt32(0);                                        

                    oConexion.CerrarConexion();

                    oConexion = null;

                    return true;

                }
                else
                {

                    error = "No hay sedes en la base de datos";

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
