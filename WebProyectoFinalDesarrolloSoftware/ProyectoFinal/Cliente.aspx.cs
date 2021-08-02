using System;
using System.Web.UI;
using ProyectoFinalDesarrolloSoftware.ProyectoFinal;

namespace WebProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se ejecuta cuando se carga la página
            //Hace un proceso de PostBack: Que es el proceso después de que se carga la primera vez
            //la página
            //Hay un objeto que se llama: Page, y tiene una propiedad que se llama isPostBack
            //Cuando isPostBack está en false, se ejecuta por primera vez el código de la página
            //cuando es true, ya se ha cargado más de una vez
            //if (Page.IsPostBack == false)   ---- si no es PostBack

            if (!Page.IsPostBack)
            {
                //Es la primera vez que se carga la página, y se debe invocar el método para llenar el Grid
                LlenarGridCliente();
                LlenarComboCategoriaPase();

            }
        }

        private void LlenarGridCliente()
        {
            // Se crea la instancia del objeto producto
            clsCliente OCliente = new clsCliente();

            // Se le pasa el grid vacío
            OCliente.grdCliente = grdCliente;

            //Se invoca el metodo llenar grid
            if (!OCliente.LlenarGrid())
            {
                lblError.Text = OCliente.Error;
            }

            OCliente = null;
        }


        private void LlenarComboCategoriaPase()
        {
            // Se crea la instancia del objeto producto
            clsCategoriaPase oCategoria = new clsCategoriaPase();

            // Se le pasa el grid vacío
            oCategoria.cboCategoriaPase = cboCategoriaPase;

            //Se invoca el metodo llenar grid
            if (!oCategoria.LlenarCombo())
            {
                lblError.Text = oCategoria.Error;
            }

            oCategoria = null;
        }


        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string Cedula, Nombres, Apellidos, NumeroPase;
            Int32 Edad, CategoriaPase;


            Cedula = txtCedula.Text;
            Nombres = txtNombres.Text;
            Apellidos = txtApellidos.Text;
            Edad = Convert.ToInt32(txtEdad.Text);
            NumeroPase = txtNumeroPase.Text;
            CategoriaPase = Convert.ToInt32(cboCategoriaPase.SelectedValue);

            clsCliente oCliente = new clsCliente();
            oCliente.Cedula = Cedula;
            oCliente.Nombres = Nombres;
            oCliente.Apellidos = Apellidos;
            oCliente.Edad = Edad;
            oCliente.NumeroPase = NumeroPase;
            oCliente.CategoriaPase = CategoriaPase;

            if (oCliente.Insertar())
            {
                LimpiarCajas();
                lblError.Text = "CLIENTE REGISTRADO CON EXITO";
                LlenarGridCliente();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Cedula, Nombres, Apellidos, NumeroPase;
            Int32 Edad, CategoriaPase;


            Cedula = txtCedula.Text;
            Nombres = txtNombres.Text;
            Apellidos = txtApellidos.Text;
            Edad = Convert.ToInt32(txtEdad.Text);
            NumeroPase = txtNumeroPase.Text;
            CategoriaPase = Convert.ToInt32(cboCategoriaPase.SelectedValue);

            clsCliente oCliente = new clsCliente();
            oCliente.Cedula = Cedula;
            oCliente.Nombres = Nombres;
            oCliente.Apellidos = Apellidos;
            oCliente.Edad = Edad;
            oCliente.NumeroPase = NumeroPase;
            oCliente.CategoriaPase = CategoriaPase;

            if (oCliente.Actualizar())
            {

                LimpiarCajas();
                lblError.Text = "CLIENTE ACTUALIZADO CON EXITO";
                LlenarGridCliente();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string Cedula;
            Cedula = txtCedula.Text;

            clsCliente oCliente = new clsCliente();
            oCliente.Cedula = Cedula;

            if (oCliente.Eliminar())
            {

                LimpiarCajas();

                lblError.Text = "CLIENTE ELIMINADO CON EXITO";              

                LlenarGridCliente();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }

        protected void btnCosultar_Click(object sender, EventArgs e)
        {
            string Cedula;
            Cedula = txtCedula.Text;

            clsCliente oCliente = new clsCliente();
            oCliente.Cedula = Cedula;

            if (oCliente.Consultar())
            {
                txtNombres.Text = oCliente.Nombres;
                txtApellidos.Text = oCliente.Apellidos;
                txtEdad.Text = oCliente.Edad.ToString();
                txtNumeroPase.Text = oCliente.NumeroPase;
                cboCategoriaPase.SelectedValue = oCliente.CategoriaPase.ToString();

                lblError.Text = "CONSULTA REALIZADA CON EXITO";
            }
            else
            {
                lblError.Text = oCliente.Error;

                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtEdad.Text = "";
                txtNumeroPase.Text = "";

            }
            oCliente = null;
        }

        private void LimpiarCajas()
        {

            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtNumeroPase.Text = "";
            lblError.Text = "";

        }

        protected void btnLimpiarCajas_Click(object sender, EventArgs e)
        {

            LimpiarCajas();            

        }
       
        protected void grdCliente_SelectedIndexChanged1(object sender, EventArgs e)
        {

            //Para generar la edicion del grid, se activa la ventana de eventos especiales en el grid
            // Se elige editar columnas
            //Se agrega un boton de comando de tipo select
            //Se da doble click sobre el grid para crear el evento SelectedIndexChanged
            //Se capturan los campos del grid

            string Cedula, Nombre;

            Cedula = grdCliente.SelectedRow.Cells[1].Text;
            Nombre = grdCliente.SelectedRow.Cells[2].Text;


            // Se invoca la pagina para la gestion de los telefonos, pasandole los datos del cliente
            // Los datos se pasan como parametros de tipo QueryString
            // La pagina se llama con el Nombre la pagina
            // Los parametros se pasan con el Nombre del parametro y el valor que deben tomar

            // Para llamar paginas se utiliza el objeto Response con el metodo Redirect,
            // y entre parentesis va el Nombre de la pagina

            // Navegación simple Response.Redirect("TelefonoCliente.aspx");
            // Navegación Completa Response.Redirect("TelefonoCliente.aspx?Cedula" + Cedula);

            Response.Redirect("TelefonoCliente.aspx?Cedula=" + Cedula + "&NombreCliente=" + Nombre);



        }
    }
}