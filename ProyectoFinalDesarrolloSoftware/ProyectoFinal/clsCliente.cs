using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;


namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public class clsCliente
    {
        #region Constructor
         public clsCliente()
        {
            
        }
        #endregion

        #region Propiedades / Atributos

        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Int32 Edad { get; set; }
        public string NumeroPase { get; set; }
        public GridView grdCliente { get; set; }
        public GridView grdTelefono { get; set; }
        public string NumeroTelefono { get; set; }
        public Int32 CodigoTelefono { get; set; }
        public Int32 TipoTelefono { get; set; }
        public Int32 CategoriaPase { get; set; }

        private string SQL;
        public string Error { get; private set; }


        #endregion

        #region Metodos
        public bool LlenarGrid()
        {
            SQL = "SELECT   dbo.tblCliente.Cedula AS CEDULA, " +
                                        "dbo.tblCliente.Nombres + ' ' + dbo.tblCliente.Apellidos AS[NOMBRE COMPLETO], " +
                                        "dbo.tblCliente.Edad AS EDAD, " +
                                        "dbo.tblCliente.NumeroPase AS[NRO LICENCIA], " +
                                        "dbo.tblPase.Codigo AS[COD PASE], " +
                                        "dbo.tblPase.Categoria AS[CAT PASE], " +
                                        "COUNT(dbo.tblTelefonoCliente.Codigo) AS TELEFONOS " +
                  "FROM          dbo.tblCliente LEFT OUTER JOIN dbo.tblTelefonoCliente " +
                                        "ON dbo.tblCliente.Cedula = dbo.tblTelefonoCliente.CedulaCliente INNER JOIN " +
                                        "dbo.tblPase ON dbo.tblCliente.IDPase = dbo.tblPase.Codigo " +
                  "GROUP BY  dbo.tblCliente.Cedula, dbo.tblCliente.Nombres + ' ' + dbo.tblCliente.Apellidos, " +
                                       "dbo.tblCliente.Edad, dbo.tblCliente.NumeroPase, dbo.tblPase.Codigo, dbo.tblPase.Categoria " +
                  "ORDER BY [NOMBRE COMPLETO]";

            // Se crea la instancia de la clase grid
            clsGrid oGrid = new clsGrid();
            // Se paasan los parametros: Nombres tabla, el grid generico, la instrucción SQL y el grid vacío
            oGrid.NombreTabla = "TablaGrid";
            oGrid.SQL = SQL;
            oGrid.gridGenerico = grdCliente;  //Grid vacío

            if (oGrid.LlenarGridWeb())
            {
                // Capturo grid de cliente, libero memoria y retorno true
                grdCliente = oGrid.gridGenerico;
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

        public bool LlenarGridTelefono()
        {
            SQL = "SELECT          dbo.tblTipoTelefono.Codigo AS [CODIGO TIPO], " +
                                  "dbo.tblTipoTelefono.Nombre AS [TIPO TELEFONO], " +
                                  "dbo.tblTelefonoCliente.Codigo AS [CODIGO TELEFONO], " +
                                  "dbo.tblTelefonoCliente.Numero AS TELÉFONO " +
                   "FROM           dbo.tblTelefonoCliente INNER JOIN dbo.tblTipoTelefono " +
                                  "ON dbo.tblTelefonoCliente.IDTipoTelefono = dbo.tblTipoTelefono.Codigo " +
                   "WHERE          dbo.tblTelefonoCliente.CedulaCliente = @pr_Cedula " +

                   "ORDER BY[TIPO TELEFONO], TELÉFONO";

            // Se crea la instancia de la clase grid
            clsGrid oGrid = new clsGrid();

            // Como el grid de telefono recibe un parametro, este se debe pasar a la consulta
            oGrid.AgregarParametro("@pr_Cedula", Cedula);
            // Se paasan los parametros: Nombres tabla, el grid generico, la instrucción SQL y el grid vacío
            oGrid.NombreTabla = "TablaGrid";
            oGrid.SQL = SQL;
            oGrid.gridGenerico = grdTelefono;  //Grid vacío

            if (oGrid.LlenarGridWeb())
            {
                // Capturo grid de cliente, libero memoria y retorno true
                grdTelefono = oGrid.gridGenerico;
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
            if (Validar())
            {
                // Sí valida el primer paso es crear la instruccón SQL
                // Para grabar se utiliza la instrucción INSERT INTO TABLA ( Campo1, Campo2, Campo3) VALUES (Valo1, Valor2, Valor3...)
                // Creamos una consulta parametrizada, donde los valores seran parametros
                // los parametros se definen iniciando con el caracter "@" y el Nombres que lo vaya a definir

                SQL = "INSERT INTO tblCliente(Cedula, Nombres, Apellidos, Edad, " +
                                              "NumeroPase, IDPase ) " +
                      "VALUES (@Cedula, @Nombres, @Apellidos, @Edad, @NumeroPase, @CategoriaPase)";

                // Se deben definir los valores de los parametros
                // Se debe crear el objeto de la clase conexión
                // Y le pasamos el parametro SQL

                clsConexion oConexion = new clsConexion();
                oConexion.SQL = SQL;

                //En la clase conexion hay un metodo que permite agregar parametros
                //Usamos el objeto conexión para agregarlos
                oConexion.AgregarParametro("@Cedula", Cedula);
                oConexion.AgregarParametro("@Nombres", Nombres);
                oConexion.AgregarParametro("@Apellidos", Apellidos);
                oConexion.AgregarParametro("@Edad", Edad);
                oConexion.AgregarParametro("@NumeroPase", NumeroPase);
                oConexion.AgregarParametro("@CategoriaPase", CategoriaPase);

                //Invocar el metodo publico para ejecutar la instruccion de accion: Ejecutar sentencia
                if (oConexion.EjecutarSentencia())
                {
                    // Se ejecuto correctamente, se libera memoria y se retorna true
                    oConexion = null;
                    return true;
                }
                else
                {
                    // Hubo un error, se debe capturar el error, liberar memoria y retornar false
                    Error = oConexion.Error;
                    oConexion = null;
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public bool Actualizar()
        {
            if (Validar())
            {
                // Sí valida el primer paso es crear la instruccón SQL
                // Para actualizar se utiliza la instrucción UPDATE TABLA SET ( Campo1= Valo1, Campo2= Valor2 , Campo3= Valor3... ) WHERE CampoX= ValorX
                // Creamos una consulta parametrizada, donde los valores seran parametros
                // los parametros se definen iniciando con el caracter "@" y el Nombres que lo vaya a definir
                SQL = " UPDATE  tblCliente " +
                      " SET     Nombres = @Nombres, " +
                                "Apellidos = @Apellidos, " +
                                "Edad = @Edad, " +
                                "NumeroPase = @NumeroPase, " +
                                "IDPase = @CategoriaPase  " +
                      " WHERE   Cedula = @Cedula ";


                // Se deben definir los valores de los parametros
                // Se debe crear el objeto de la clase conexión
                // Y le pasamos el parametro SQL

                clsConexion oConexion = new clsConexion();
                oConexion.SQL = SQL;

                //En la clase conexion hay un metodo que permite agregar parametros
                //Usamos el objeto conexión para agregarlos

                oConexion.AgregarParametro("@Cedula", Cedula);
                oConexion.AgregarParametro("@Nombres", Nombres);
                oConexion.AgregarParametro("@Apellidos", Apellidos);
                oConexion.AgregarParametro("@Edad", Edad);
                oConexion.AgregarParametro("@NumeroPase", NumeroPase);
                oConexion.AgregarParametro("@CategoriaPase ", CategoriaPase);

                //Invocar el metodo publico para ejecutar la instruccion de accion: Ejecutar sentencia
                if (oConexion.EjecutarSentencia())
                {
                    // Se ejecuto correctamente, se libera memoria y se retorna true
                    oConexion = null;
                    return true;
                }
                else
                {
                    // Hubo un error, se debe capturar el error, liberar memoria y retornar false
                    Error = oConexion.Error;
                    oConexion = null;
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public bool Eliminar()
        {
            // Se valida el codigo
            if (string.IsNullOrEmpty(Cedula))
            {
                Error = "No definió un número de Cedula valido";
                return false;
            }

            // Sí valida el primer paso es crear la instruccón SQL
            // Para actualizar se utiliza la instrucción DELETE FROM TABLA WHERE CampoX= ValorX
            // Creamos una consulta parametrizada, donde los valores seran parametros
            // los parametros se definen iniciando con el caracter "@" y el Nombres que lo vaya a definir
            SQL = "DELETE FROM  tblCliente " +
                      " WHERE       Cedula = @Cedula ";


                // Se deben definir los valores de los parametros
                // Se debe crear el objeto de la clase conexión
                // Y le pasamos el parametro SQL

                clsConexion oConexion = new clsConexion();
                oConexion.SQL = SQL;

                //En la clase conexion hay un metodo que permite agregar parametros
                //Usamos el objeto conexión para agregarlos

                oConexion.AgregarParametro("@Cedula", Cedula);

                //Invocar el metodo publico para ejecutar la instruccion de accion: Ejecutar sentencia
                if (oConexion.EjecutarSentencia())
                {
                    // Se ejecuto correctamente, se libera memoria y se retorna true
                    oConexion = null;
                    return true;
                }
                else
                {
                    // Hubo un error, se debe capturar el error, liberar memoria y retornar false
                    Error = oConexion.Error;
                    oConexion = null;
                    return false;
                }

        }

        public bool Consultar()
        {
            // Se valida el codigo
            if (string.IsNullOrEmpty(Cedula))
            {
                Error = "No definió un número de Cedula valido";
                return false;
            }

            // Sí valida el primer paso es crear la instruccón SQL
            // Para actualizar se utiliza la instrucción SELECT Campo1, Campo2, Campo3 FROM TABLA WHERE CampoX= ValorX
            // Creamos una consulta parametrizada, donde los valores seran parametros
            // los parametros se definen iniciando con el caracter "@" y el Nombres que lo vaya a definir
            SQL = " SELECT         Nombres, Apellidos, Edad, " +
                                  "NumeroPase, IDPase " +
                  " FROM          tblCliente" +
                  " WHERE         Cedula = @Cedula ";


            // Se deben definir los valores de los parametros
            // Se debe crear el objeto de la clase conexión
            // Y le pasamos el parametro SQL

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;

            //En la clase conexion hay un metodo que permite agregar parametros
            //Usamos el objeto conexión para agregarlos

            oConexion.AgregarParametro("@Cedula", Cedula);

            //Invocar el metodo publico para ejecutar la instruccion de accion: Consultar
            if (oConexion.Consultar())
            {
                // Si la consulta tiene datos, leemos la información con la clase Reader y metodo .Read()
                if (oConexion.Reader.HasRows)
                {
                    // Hay datos, se invoca el metodo Read() y se leen los datos con los metodos get
                    oConexion.Reader.Read();
                    Nombres = oConexion.Reader.GetString(0);
                    Apellidos = oConexion.Reader.GetString(1);
                    Edad = oConexion.Reader.GetInt32(2);
                    NumeroPase = oConexion.Reader.GetString(3);
                    CategoriaPase = oConexion.Reader.GetInt32(4);
                    

                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No hay datos para mostrar
                    Error = "El cliente con número de Cedula " + Cedula + " no existe en la base de datos";
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                // Hubo un error, se captura el error, se cierra la conexión, libera memoria y retorna falso
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                oConexion = null;
                return false;
            }
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(Cedula))
            {
                Error = "No definió un numero de Cedula valido";
                return false;
            }

            if (string.IsNullOrEmpty(Nombres))
            {
                Error = "No definió el Nombres del cilente";
                return false;
            }

            if (string.IsNullOrEmpty(Apellidos))
            {
                Error = "No definió el primer apellido del cliente";
                return false;
            }

            if (Edad <= 0)
            {
                Error = "No definió una edad valida";
                return false;
            }

            if (string.IsNullOrEmpty(NumeroPase))
            {
                Error = "No definió el número de Licencia del cliente";
                return false;
            }

            return true;

        }

        public bool InsertarTelefono()
        {
            // Sí valida el primer paso es crear la instruccón SQL
            // Para grabar se utiliza la instrucción INSERT INTO TABLA ( Campo1, Campo2, Campo3) VALUES (Valo1, Valor2, Valor3...)
            // Creamos una consulta parametrizada, donde los valores seran parametros
            // los parametros se definen iniciando con el caracter "@" y el Nombres que lo vaya a definir

            SQL = "INSERT INTO tblTelefonoCliente(Numero, CedulaCliente,  " +
                                          "IDTipoTelefono ) " +
                  "VALUES (@NumeroTelefono, @Cedula, @TipoTelefono )";

            // Se deben definir los valores de los parametros
            // Se debe crear el objeto de la clase conexión
            // Y le pasamos el parametro SQL

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;

            //En la clase conexion hay un metodo que permite agregar parametros
            //Usamos el objeto conexión para agregarlos
            oConexion.AgregarParametro("@NumeroTelefono", NumeroTelefono);
            oConexion.AgregarParametro("@Cedula", Cedula);
            oConexion.AgregarParametro("@TipoTelefono", TipoTelefono);
            

            //Invocar el metodo publico para ejecutar la instruccion de accion: Ejecutar sentencia
            if (oConexion.EjecutarSentencia())
            {
                // Se ejecuto correctamente, se libera memoria y se retorna true
                oConexion = null;
                return true;
            }
            else
            {
                // Hubo un error, se debe capturar el error, liberar memoria y retornar false
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }

        public bool ActualizarTelefono()
        {
            // Para actualizar se utiliza la instrucción UPDATE TABLA SET ( Campo1= Valo1, Campo2= Valor2 , Campo3= Valor3... ) WHERE CampoX= ValorX
            // Creamos una consulta parametrizada, donde los valores seran parametros
            // los parametros se definen iniciando con el caracter "@" y el Nombres que lo vaya a definir
            SQL = "UPDATE     tblTelefonoCliente " +
                    "SET        Numero = @NumeroTelefono, " +
                                "IDTipoTelefono = @TipoTelefono " +
                    "WHERE      Codigo= @CodigoTelefono";


            // Se deben definir los valores de los parametros
            // Se debe crear el objeto de la clase conexión
            // Y le pasamos el parametro SQL

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;

            //En la clase conexion hay un metodo que permite agregar parametros
            //Usamos el objeto conexión para agregarlos
            oConexion.AgregarParametro("@NumeroTelefono", NumeroTelefono);
            oConexion.AgregarParametro("@TipoTelefono", TipoTelefono);
            oConexion.AgregarParametro("@CodigoTelefono", CodigoTelefono);



            //Invocar el metodo publico para ejecutar la instruccion de accion: Ejecutar sentencia
            if (oConexion.EjecutarSentencia())
            {
                // Se ejecuto correctamente, se libera memoria y se retorna true
                oConexion = null;
                return true;
            }
            else
            {
                // Hubo un error, se debe capturar el error, liberar memoria y retornar false
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }

        public bool EliminarTelefono()
        {
            // Para actualizar se utiliza la instrucción DELETE FROM TABLA WHERE CampoX= ValorX
            // Creamos una consulta parametrizada, donde los valores seran parametros
            // los parametros se definen iniciando con el caracter "@" y el Nombres que lo vaya a definir
            SQL = " DELETE FROM       tblTelefonoCliente " +
                     " WHERE          Codigo = @CodigoTelefono ";


            // Se deben definir los valores de los parametros
            // Se debe crear el objeto de la clase conexión
            // Y le pasamos el parametro SQL

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;

            //En la clase conexion hay un metodo que permite agregar parametros
            //Usamos el objeto conexión para agregarlos
            oConexion.AgregarParametro("@CodigoTelefono", CodigoTelefono);


            //Invocar el metodo publico para ejecutar la instruccion de accion: Ejecutar sentencia
            if (oConexion.EjecutarSentencia())
            {
                // Se ejecuto correctamente, se libera memoria y se retorna true
                oConexion = null;
                return true;
            }
            else
            {
                // Hubo un error, se debe capturar el error, liberar memoria y retornar false
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }
        #endregion
    }
}
