using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalDesarrolloSoftware.ProyectoFinal;

namespace WebProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public partial class Ciudad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se ejecuta cada que se carga la página, tanto la primera vez que va al servidor, como
            //todas las siguientes
            //El PostBack es un proceso que sejecuta cuando la página se cargó la primera vez y requiere 
            //de una nueva conexión al servidor
            //Hay un objeto del servidor: Page, que tiene la propiedad isPostBack
            //Es un booleano que cuando está en false, es la primera que se invoca la página
            //Cuando es true, se ha invocado más de una vez
            if (!Page.IsPostBack)
            {
                //Es la primera vez que se carga la página, se invoca el método de llenar combo
                LlenarComboDepartamento();
                LlenarGridDepartamento();
            }
        }

        private void LlenarComboDepartamento()
        {
            //Se crea el objeto de país
            clsDepartamento oDepartamento = new clsDepartamento();
            oDepartamento.cboDepartamento = cboDepartamento;
            if (!oDepartamento.LlenarCombo())
            {
                lblError.Text = oDepartamento.Error;
            }
            oDepartamento = null;
        }
        private void LlenarGridDepartamento()
        {
            //Se crea el objeto de departamento
            clsCiudad oCiudad = new clsCiudad();
            oCiudad.grdCiudad = grdCiudad;
            if (!oCiudad.LlenarGrid())
            {
                lblError.Text = oCiudad.Error;
            }
            oCiudad = null;
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string Nombre;
            Int32 CodigoDepartamento;
            bool Activo;

            Nombre = txtNombre.Text;
            CodigoDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);
            Activo = chkActivo.Checked;

            clsCiudad oCiudad = new clsCiudad();
            oCiudad.Nombre = Nombre;
            oCiudad.Departamento = CodigoDepartamento;
            oCiudad.Activo = Activo;

            if (oCiudad.Insertar())
            {
                lblError.Text = "CIUDAD REGISTRADA CON EXITO";
                LlenarGridDepartamento();
            }
            else
            {
                lblError.Text = oCiudad.Error;
            }
            oCiudad = null;

            txtCodigo.Text = "";

            txtNombre.Text = "";

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Nombre;
            Int32 CodigoDepartamento, CodigoCiudad;
            bool Activo;

            CodigoCiudad = Convert.ToInt32(txtCodigo.Text);
            Nombre = txtNombre.Text;
            CodigoDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);
            Activo = chkActivo.Checked;

            clsCiudad oCiudad = new clsCiudad();
            oCiudad.Codigo = CodigoCiudad;
            oCiudad.Nombre = Nombre;
            oCiudad.Departamento = CodigoDepartamento;
            oCiudad.Activo = Activo;

            if (oCiudad.Actualizar())
            {
                lblError.Text = "CIUDAD ACTUALIZADA CON EXITO";
                LlenarGridDepartamento();
            }
            else
            {
                lblError.Text = oCiudad.Error;
            }

            oCiudad = null;

            txtCodigo.Text = "";

            txtNombre.Text = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 CodigoCiudad;

            CodigoCiudad = Convert.ToInt32(txtCodigo.Text);

            clsCiudad oCiudad = new clsCiudad();
            oCiudad.Codigo = CodigoCiudad;

            if (oCiudad.Eliminar())
            {
                lblError.Text = "CIUDAD ELIMINADA CON EXITO";
                LlenarGridDepartamento();
            }
            else
            {
                lblError.Text = oCiudad.Error;
            }

            oCiudad = null;

            txtCodigo.Text = "";

            txtNombre.Text = "";
        }
                      
        protected void grdCiudad_SelectedIndexChanged1(object sender, EventArgs e)
        {

            txtCodigo.Text = grdCiudad.SelectedRow.Cells[3].Text;
            txtNombre.Text = grdCiudad.SelectedRow.Cells[4].Text;
            cboDepartamento.SelectedValue = grdCiudad.SelectedRow.Cells[1].Text;
            CheckBox chkGrid = (CheckBox)(grdCiudad.SelectedRow.Cells[5].Controls[0]);
            chkActivo.Checked = chkGrid.Checked;
            chkGrid = null;
            lblError.Text = "";

        }
    }
}