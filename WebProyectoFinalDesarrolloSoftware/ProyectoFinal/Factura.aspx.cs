using System;
using ProyectoFinalDesarrolloSoftware.ProyectoFinal;

namespace WebProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                LlenarComboEmpleado();

                GenerarNumeroFactura();

                
            }

            string cedulaCliente, placaVehiculo, kilometrosRecorridos;

            Int32 kilometros, precioKilometrosRecorridos;

            /*Regla de negocio el precio por cada kilometro recorrido es de mil pesos*/

            Int32 precioKilometro = 1000;

            cedulaCliente = Request.QueryString["cedulaCliente"];

            placaVehiculo = Request.QueryString["placaVehiculo"];

            kilometrosRecorridos = Request.QueryString["kilometrosRecorridos"];

            lblFecha.Text = DateTime.Now.ToString("yyyy/MM/dd");

            lblCedulaCliente.Text = cedulaCliente;

            lblPlacaVehiculo.Text = placaVehiculo;

            lblKilometrosRecorridos.Text = kilometrosRecorridos.ToString();

            kilometros = Convert.ToInt32(lblKilometrosRecorridos.Text);

            precioKilometrosRecorridos = kilometros * precioKilometro;

            lblPrecioKilometrosDB.Text = precioKilometrosRecorridos.ToString();

            lblPrecioKilometros.Text = "$ " + precioKilometrosRecorridos.ToString("#,###");

            lblPrecioRentaDB.Text = "0";

            lblPrecioRenta.Text = "$ 0";

            lblPrecioReserva.Text = "$ 0";

            lblPrecioReservaDB.Text = "0";

            ConsultarPrecioRenta();

            ConsultarPrecioReserva();

            ConsultarNombreCliente();

        }

        private void GenerarNumeroFactura()
        {

            clsFactura oFactura = new clsFactura();

            if (oFactura.ConsultarNumeroFactura())
            {

                lblNumeroFactura.Text = oFactura.numeroFactura.ToString();

            }
            else
            {

                lblError.Text = oFactura.error;

            }

            oFactura = null;

        }

        private void LlenarComboEmpleado()
        {

            clsEmpleado oEmpleado = new clsEmpleado();

            oEmpleado.cboEmpleado = cboEmpleado;

            if (!oEmpleado.LlenarCombo())
            {

                lblError.Text = oEmpleado.error;

            }

            oEmpleado = null;

        }

        private void ConsultarNombreCliente()
        {

            string cedulaCliente, nombreCliente;

            cedulaCliente = lblCedulaCliente.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.Cedula = cedulaCliente;

            if (oCliente.Consultar())
            {

                nombreCliente = oCliente.Nombres + " " + oCliente.Apellidos;

                lblNombreCliente.Text = nombreCliente;

            }


        }

        private void ConsultarPrecioRenta()
        {

            string cedulaCliente, placaVehiculo;

            Int32 precioRenta;

            cedulaCliente = lblCedulaCliente.Text;

            placaVehiculo = lblPlacaVehiculo.Text;

            clsRegistroRenta oRenta = new clsRegistroRenta();

            oRenta.cedulaCliente = cedulaCliente;

            oRenta.placaVehiculo = placaVehiculo;

            if (oRenta.ConsultarPrecio())
            {

                precioRenta = oRenta.precio;

                lblPrecioRentaDB.Text = precioRenta.ToString();

                lblPrecioRenta.Text = "$ " +precioRenta.ToString("#,###");

            }

        }

        private void ConsultarPrecioReserva()
        {

            string cedulaCliente, placaVehiculo;

            Int32 precioReserva;

            cedulaCliente = lblCedulaCliente.Text;

            placaVehiculo = lblPlacaVehiculo.Text;

            clsRegistroReserva oReserva = new clsRegistroReserva();

            oReserva.cedulaCliente = cedulaCliente;

            oReserva.placaVehiculo = placaVehiculo;

            if (oReserva.ConsultarPrecio())
            {

                precioReserva = oReserva.precio;

                lblPrecioReservaDB.Text = precioReserva.ToString();

                lblPrecioReserva.Text = "$ " + precioReserva.ToString("#,###");

            }

        }

        private void CalcularTotalPagar()
        {

            Int32 precioRenta, precioReserva, precioKilometros;

            precioRenta = Convert.ToInt32(lblPrecioRentaDB.Text);

            precioReserva = Convert.ToInt32(lblPrecioReservaDB.Text);

            precioKilometros = Convert.ToInt32(lblPrecioKilometrosDB.Text);

            lblTotalPagar.Text = "$ " +(precioRenta + precioReserva + precioKilometros).ToString("#,###");


        }

        protected void btnTotalPagar_Click(object sender, EventArgs e)
        {

            CalcularTotalPagar();

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

            Response.Redirect("Devolucion.aspx");

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {

            Int32 numeroFactura, IDCargoEmpleado;

            string cedulaCliente, placaVehiculo;

            numeroFactura = Convert.ToInt32(lblNumeroFactura.Text);

            cedulaCliente = lblCedulaCliente.Text;

            placaVehiculo = lblPlacaVehiculo.Text;

            IDCargoEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);

            clsFactura oFactura = new clsFactura();

            oFactura.numeroFactura = numeroFactura;

            oFactura.cedulaCliente = cedulaCliente;

            oFactura.placaVehiculo = placaVehiculo;

            oFactura.IDCargoEmpleado = IDCargoEmpleado;

            if (oFactura.GrabarFactura())
            {

                lblError.Text = "LA FACTURA SE REGISTRO CON EXITO";

            }
            else
            {

                lblError.Text = oFactura.error;

            }


        }
    }
}