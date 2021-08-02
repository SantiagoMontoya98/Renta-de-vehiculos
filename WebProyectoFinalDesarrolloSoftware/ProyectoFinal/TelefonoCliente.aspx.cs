using System;
using System.Web.UI;
using ProyectoFinalDesarrolloSoftware.ProyectoFinal;

namespace WebProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public partial class TelefonoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Los parametros de la pagina se capturan en el Load, con el objeto Request
            // Cuando lo parametros son de tipo QueryString se capturan con esa propiedad

            string Cedula, Nombre;

            Cedula = Request.QueryString["Cedula"];
            Nombre = Request.QueryString["NombreCliente"];


            // Enviamos los parametros a los respectivos Label
            lblCedula.Text = Cedula;
            lblNombre.Text = Nombre;


            if (!Page.IsPostBack)
            {
                LlenarComboTipoTelefono();
                LlenarGridTelefono();
            }


        }

        private void LlenarComboTipoTelefono()
        {
            clsTipoTelefono oTipoTelefono = new clsTipoTelefono();
            oTipoTelefono.cboTipoTelefono = cboTelefono;  // aqui no es necesario que se llame igual

            if (!oTipoTelefono.LlenarCombo())
            {
                lblError.Text = oTipoTelefono.Error;
            }
            oTipoTelefono = null;

        }

        private void LlenarGridTelefono()
        {
            // se crea el objeto de cliente para pasarle el grid de telefono
            clsCliente oCliente = new clsCliente();
            oCliente.grdTelefono = grdTelefono;
            oCliente.Cedula = lblCedula.Text;
            if (!oCliente.LlenarGridTelefono())
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string NumeroTelefono, Cedula;
            Int32 TipoTelefono;

            NumeroTelefono = txtNumeroTelefono.Text;
            Cedula = lblCedula.Text;
            TipoTelefono = Convert.ToInt32(cboTelefono.SelectedValue);

            clsCliente oCliente = new clsCliente();
            oCliente.NumeroTelefono = NumeroTelefono;
            oCliente.Cedula = Cedula;
            oCliente.TipoTelefono = TipoTelefono;

            if (oCliente.InsertarTelefono())
            {
                lblError.Text = "TELEFONO INGRESADO CON EXITO";
                LlenarGridTelefono();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;


        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string NumeroTelefono, Cedula;
            Int32 TipoTelefono, CodigoTelefono;

            NumeroTelefono = txtNumeroTelefono.Text;
            Cedula = lblCedula.Text;
            TipoTelefono = Convert.ToInt32(cboTelefono.SelectedValue);
            CodigoTelefono = Convert.ToInt32(txtCodigoTelefono.Text);

            clsCliente oCliente = new clsCliente();
            oCliente.NumeroTelefono = NumeroTelefono;
            oCliente.Cedula = Cedula;
            oCliente.TipoTelefono = TipoTelefono;
            oCliente.CodigoTelefono = CodigoTelefono;

            if (oCliente.ActualizarTelefono())
            {
                lblError.Text = "TELEFONO ACTUALIZADO CON EXITO";
                LlenarGridTelefono();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 CodigoTelefono;

            CodigoTelefono = Convert.ToInt32(txtCodigoTelefono.Text);

            clsCliente oCliente = new clsCliente();
            oCliente.CodigoTelefono = CodigoTelefono;

            if (oCliente.EliminarTelefono())
            {
                lblError.Text = "TELEFONO ELIMINADO CON EXITO";
                LlenarGridTelefono();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }
               
        protected void grdTelefono_SelectedIndexChanged1(object sender, EventArgs e)
        {

            cboTelefono.SelectedValue = grdTelefono.SelectedRow.Cells[1].Text;
            txtCodigoTelefono.Text = grdTelefono.SelectedRow.Cells[3].Text;
            txtNumeroTelefono.Text = grdTelefono.SelectedRow.Cells[4].Text;
            lblError.Text = "";
        }
    }
}