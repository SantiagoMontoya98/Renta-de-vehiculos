using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalDesarrolloSoftware.ProyectoFinal;

namespace WebProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public partial class ReservarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                ConsultarNombreSede();

                LlenarComboPoliza();               

                LlenarGridReserva();

            }


        }

        private void ConsultarNombreSede()
        {

            clsSede oSede = new clsSede();

            if (oSede.Consultar())
            {

                lblSedeVehiculo.Text = oSede.nombre;

                lblIDSede.Text = oSede.codigo.ToString();

            }
            else
            {

                lblError.Text = oSede.error;

            }

            oSede = null;

        }

        private void LlenarComboPoliza()
        {

            clsPoliza oPoliza = new clsPoliza();

            oPoliza.cboPoliza = cboPoliza;

            if (!oPoliza.LlenarCombo())
            {

                lblError.Text = oPoliza.error;

            }

            oPoliza = null;

        }
               
        private void LlenarGridReserva()
        {

            clsRegistroReserva oRegistroReserva = new clsRegistroReserva();

            oRegistroReserva.grdRegistroReserva = grdRegistroReserva;

            if (!oRegistroReserva.LlenarGrid())
            {

                lblError.Text = oRegistroReserva.error;

            }

            oRegistroReserva = null;

        }

        private void MostrarInformacionInvisible()
        {

            lblCodigo.Visible = true;

            lblCedulaCliente.Visible = true;

            lblFechaInicial.Visible = true;

            lblFechaFinal.Visible = true;

            lblSede.Visible = true;

            lblPoliza.Visible = true;            

            lblNumDias.Visible = true;

            lblNumeroDias.Visible = true;

            lblPrecio.Visible = true;

            lblPrecio2.Visible = true;

            lblError.Visible = true;

            dtpFechaInicial.Visible = true;

            dtpFechaFinal.Visible = true;

            txtCodigo.Visible = true;

            txtCedulaCliente.Visible = true;

            lblSedeVehiculo.Visible = true;

            cboPoliza.Visible = true;            

            btnConsultarPrecio.Visible = true;

            btnReservarVehiculo.Visible = true;

            btnActualizarReserva.Visible = false;

            btnEliminarReserva.Visible = false;

            lblNumeroDias.Text = "";

            lblPrecio.Text = "";

        }              

        private void CalcularPrecioReserva()
        {

            TimeSpan numDias;
            DateTime fechaInicial, fechaFinal;
            Int32 numeroDias, precioVehiculo, precioReserva, IDPoliza, precioPoliza;
            string placaVehiculo;

            placaVehiculo = lblPlacaVehiculo.Text;

            IDPoliza = Convert.ToInt32(cboPoliza.SelectedValue);

            clsVehiculo oVehiculo = new clsVehiculo();

            clsPoliza oPoliza = new clsPoliza();

            oVehiculo.placaVehiculo = placaVehiculo;

            oPoliza.codigo = IDPoliza;

            if (oVehiculo.ConsultarPrecio())
            {

                /*Reglas de negocio 
                 1) El precio de los vehiculos de gama baja es de 32mil 500 por 1 dia de reserva
                 2)El precio de los vehiculos de gama media es de 45mil por 1 dia de reserva
                 3)El precio del tipo de poliza sencilla es de 75000 por la reserva
                 4)El precio del tipo de poliza media es de 125000 por la reserva
                 5)El precio del tipo de poliza de crubimiento total es de 200000 para la reserva
                 */

                precioVehiculo = oVehiculo.precio / 2;

                if (oPoliza.ConsultarPrecio())
                {

                    precioPoliza = oPoliza.precio / 2;

                    fechaInicial = dtpFechaInicial.SelectedDate;

                    fechaFinal = dtpFechaFinal.SelectedDate;

                    numDias = fechaFinal - fechaInicial;

                    numeroDias = numDias.Days;

                    precioReserva = (numeroDias * precioVehiculo) + precioPoliza;

                    lblPrecioDB.Text = precioReserva.ToString();

                    lblNumeroDias.Text = numeroDias.ToString();

                    lblPrecio.Text = "$ " + precioReserva.ToString("#,###");                                        

                }
                else
                {

                    lblError.Text = oPoliza.error;

                }

            }
            else
            {

                lblError.Text = oVehiculo.error;

            }

            oVehiculo = null;

            oPoliza = null;

        }

        protected void btnConsultarPrecio_Click(object sender, EventArgs e)
        {

            CalcularPrecioReserva();

        }

        protected void ImagenCaptur_Click(object sender, ImageClickEventArgs e)
        {

            lblPlacaVehiculo.Text = "HGG547";

            MostrarInformacionInvisible();

            lblError.Text = "";

        }

        protected void ImagenEdge_Click(object sender, ImageClickEventArgs e)
        {

            lblPlacaVehiculo.Text = "JHK251";

            MostrarInformacionInvisible();

            lblError.Text = "";

        }

        protected void ImagenMazda3_Click(object sender, ImageClickEventArgs e)
        {

            lblPlacaVehiculo.Text = "KSH898";

            MostrarInformacionInvisible();

            lblError.Text = "";

        }

        protected void ImagenMazdaCX5_Click(object sender, ImageClickEventArgs e)
        {

            lblPlacaVehiculo.Text = "TUP222";

            MostrarInformacionInvisible();

            lblError.Text = "";

        }

        protected void ImagenSpark_Click(object sender, ImageClickEventArgs e)
        {

            lblPlacaVehiculo.Text = "NGB524";

            MostrarInformacionInvisible();

            lblError.Text = "";

        }

        protected void Imageni10_Click(object sender, ImageClickEventArgs e)
        {

            lblPlacaVehiculo.Text = "KVZ114";

            MostrarInformacionInvisible();

            lblError.Text = "";

        }

        protected void ImagenSandero_Click(object sender, ImageClickEventArgs e)
        {

            lblPlacaVehiculo.Text = "LYP247";

            MostrarInformacionInvisible();

            lblError.Text = "";

        }

        protected void ImagenTwingo_Click(object sender, ImageClickEventArgs e)
        {

            lblPlacaVehiculo.Text = "OAQ540";

            MostrarInformacionInvisible();

            lblError.Text = "";

        }                            

        protected void btnReservarVehiculo_Click(object sender, EventArgs e)
        {

            string cedulaCliente, placaVehiculo;
            Int32 IDSede, IDPoliza;
            DateTime fechaInicial, fechaFinal;

            cedulaCliente = txtCedulaCliente.Text;

            placaVehiculo = lblPlacaVehiculo.Text;

            fechaInicial = dtpFechaInicial.SelectedDate;

            fechaFinal = dtpFechaFinal.SelectedDate;

            IDSede = Convert.ToInt32(lblIDSede.Text);

            IDPoliza = Convert.ToInt32(cboPoliza.SelectedValue);

            clsRegistroReserva oRegistroReserva = new clsRegistroReserva();

            oRegistroReserva.cedulaCliente = cedulaCliente;

            oRegistroReserva.placaVehiculo = placaVehiculo;

            oRegistroReserva.fechaInicial = fechaInicial;

            oRegistroReserva.fechaFinal = fechaFinal;

            oRegistroReserva.IDPoliza = IDPoliza;

            oRegistroReserva.IDSede = IDSede;

            oRegistroReserva.numeroDias = Convert.ToInt32(lblNumeroDias.Text);

            oRegistroReserva.precio = Convert.ToInt32(lblPrecioDB.Text);

            if (oRegistroReserva.Insertar())
            {

                lblError.Text = "RESERVA REGISTRADA CON EXITO";

                LlenarGridReserva();

            }
            else
            {

                lblError.Text = oRegistroReserva.error;

            }

            oRegistroReserva = null;

            txtCodigo.Text = "";

            txtCedulaCliente.Text = "";

        }

        protected void btnActualizarReserva_Click(object sender, EventArgs e)
        {

            Int32 codigo, numeroDias, precio, IDSede, IDPoliza;

            DateTime fechaInicial, fechaFinal;

            string cedulaCliente, placaVehiculo;

            codigo = Convert.ToInt32(txtCodigo.Text);

            cedulaCliente = txtCedulaCliente.Text;

            placaVehiculo = lblPlacaVehiculo.Text;

            fechaInicial = dtpFechaInicial.SelectedDate;

            fechaFinal = dtpFechaFinal.SelectedDate;

            IDSede = Convert.ToInt32(lblIDSede.Text);

            IDPoliza = Convert.ToInt32(cboPoliza.SelectedValue);

            CalcularPrecioReserva();

            numeroDias = Convert.ToInt32(lblNumeroDias.Text);

            precio = Convert.ToInt32(lblPrecioDB.Text);

            clsRegistroReserva oRegistroReserva = new clsRegistroReserva();

            oRegistroReserva.codigo = codigo;

            oRegistroReserva.cedulaCliente = cedulaCliente;

            oRegistroReserva.placaVehiculo = placaVehiculo;

            oRegistroReserva.fechaInicial = fechaInicial;

            oRegistroReserva.fechaFinal = fechaFinal;

            oRegistroReserva.IDSede = IDSede;

            oRegistroReserva.IDPoliza = IDPoliza;

            oRegistroReserva.numeroDias = numeroDias;

            oRegistroReserva.precio = precio;

            if (oRegistroReserva.Actualizar())
            {

                lblError.Text = "RESERVA ACTUALIZADA CON EXITO";

                LlenarGridReserva();

            }
            else
            {

                lblError.Text = oRegistroReserva.error;

            }

            oRegistroReserva = null;

            txtCodigo.Text = "";

            txtCedulaCliente.Text = "";

        }              

        protected void btnEliminarReserva_Click(object sender, EventArgs e)
        {

            Int32 codigo;

            codigo = Convert.ToInt32(txtCodigo.Text);

            clsRegistroReserva oRegistroReserva = new clsRegistroReserva();

            oRegistroReserva.codigo = codigo;

            if (oRegistroReserva.Eliminar())
            {

                lblError.Text = "RESERVA ELIMINADA CON EXITO";

                LlenarGridReserva();

            }
            else
            {

                lblError.Text = oRegistroReserva.error;

            }

            oRegistroReserva = null;

            txtCodigo.Text = "";

            txtCedulaCliente.Text = "";

            lblNumeroDias.Text = "";

            lblPrecio.Text = "";

        }

        protected void grdRegistroReserva_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 precio;

            MostrarInformacionInvisible();

            txtCodigo.Text = grdRegistroReserva.SelectedRow.Cells[10].Text;

            txtCedulaCliente.Text = grdRegistroReserva.SelectedRow.Cells[1].Text;

            lblSedeVehiculo.Text = grdRegistroReserva.SelectedRow.Cells[7].Text;

            cboPoliza.Text = grdRegistroReserva.SelectedRow.Cells[11].Text;

            lblNumeroDias.Text = grdRegistroReserva.SelectedRow.Cells[6].Text;

            precio = Convert.ToInt32(grdRegistroReserva.SelectedRow.Cells[9].Text);

            lblPrecio.Text = "$ " + precio.ToString("#,###");

            lblError.Text = "";

            btnConsultarPrecio.Visible = true;
            
            btnReservarVehiculo.Visible = false;

            btnActualizarReserva.Visible = true;

            btnEliminarReserva.Visible = true;

        }
    }
}