using System;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace ProyectoFinalDesarrolloSoftware.ProyectoFinal

{
    public class clsDepartamento
    {
        //Verificar que exista la referencia a System.Web, de lo contrario crear la referencia
        //Se encuentra en "Ensamblados"
        //Se agregan los using: System.Web.UI.WebControls, para los objetos gráficos
        //y using:  libComunes.CapaDatos   --> CRUD
        //          libComunes.CapaObjetos --> Combos y Grids
        #region Constructor
        public clsDepartamento()
        {

        }
        #endregion
        #region Propiedades/Atributos
        
        private string SQL;
        public DropDownList cboDepartamento { get; set; }
        public string Error { get; private set; }

        #endregion
        #region Metodos
        public bool LlenarCombo()
        {
            //Crear la instrucción SQL
            SQL =   "SELECT		Codigo AS Valor, Nombre AS Texto " +
                    "FROM       tblDepartamento " +
                    "WHERE      Activo = 1 " +
                    "ORDER BY   Nombre ";

            //Se crea una instancia del objeto clsCombo
            clsCombos oCombo = new clsCombos();

            //Se le pasan las propiedades
            oCombo.SQL = SQL;

            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboDepartamento;

            //Adicionalmente, hay que pasar el nombre de la tabla que se llenará en el dataset y los nombres
            //de las columnas de texto y valor que se utilizarán para llenar el combo
            oCombo.NombreTabla = "tblCombo";
            oCombo.ColumnaTexto = "Texto";
            oCombo.ColumnaValor = "Valor";

            //Invocar el método de llenar combo y leer el combo lleno
            if (oCombo.LlenarComboWeb())
            {
                //Lee el combo lleno, libera memoria y retorna true
                cboDepartamento = oCombo.cboGenericoWeb;
                oCombo = null;
                return true;
            }
            else
            {
                //Lee el error, se libera memoria y retorna false
                Error = oCombo.Error;
                oCombo = null;
                return false;
            }
        }



        #endregion
    }
}
