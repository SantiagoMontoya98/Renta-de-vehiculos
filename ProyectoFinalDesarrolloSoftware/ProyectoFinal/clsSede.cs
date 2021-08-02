using System;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;


namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsSede
    {

        #region Constructor

        public clsSede()
        {

        }

        #endregion

        #region Propiedades/Atributos    
        
        public Int32 codigo { get; set; }
                
        public string nombre { get; set; }

        public DropDownList cboSede { get; set; }

        private string SQL;

        public string error { get; set; }

        #endregion

        #region Metodos

        public bool Consultar()
        {

            SQL = "SELECT Nombre, Codigo " +
                       "FROM dbo.tblSede";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;            

            if (oConexion.Consultar())
            {

                if (oConexion.Reader.HasRows)
                {

                    oConexion.Reader.Read();

                    nombre = oConexion.Reader.GetString(0);

                    codigo = oConexion.Reader.GetInt32(1);

                    oConexion.CerrarConexion();

                    oConexion = null;

                    return true;

                }
                else
                {

                    error = "No hay sedes en la base de datos" ;

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
