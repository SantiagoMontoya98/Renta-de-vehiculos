using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalDesarrolloSoftware.ProyectoFinal;

namespace WebProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public partial class RentarVehiculo : System.Web.UI.Page
    {
                             
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                ConsultarNombreSede();

                LlenarComboPoliza();

                LlenarComboEmpleado();

                LlenarGridRenta();

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

        private void LlenarGridRenta() 
        {

            clsRegistroRenta oRegistroRenta = new clsRegistroRenta();

            oRegistroRenta.grdRegistroRenta = grdRegistroRenta;

            if (!oRegistroRenta.LlenarGrid())
            {

                lblError.Text = oRegistroRenta.error;

            }

            oRegistroRenta = null;            

        }

        private void MostrarInformacionInvisible()
        {

            lblCodigo.Visible = true;

            lblCedulaCliente.Visible = true;

            lblFechaInicial.Visible = true;

            lblFechaFinal.Visible = true;

            lblSede.Visible = true;

            lblPoliza.Visible = true;

            lblEmpleado.Visible = true;

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

            cboEmpleado.Visible = true;

            btnConsultarPrecio.Visible = true;

            btnRentarVehiculo.Visible = true;

            btnActualizarRenta.Visible = false;

            btnEliminarRenta.Visible = false;

            lblNumeroDias.Text = "";

            lblPrecio.Text = "";

        }

        protected void btnRentarVehiculo_Click(object sender, EventArgs e)
        {

            string cedulaCliente, placaVehiculo;
            Int32 IDSede, IDPoliza, IDCargoEmpleado;
            DateTime fechaInicial, fechaFinal;

            cedulaCliente = txtCedulaCliente.Text;

            placaVehiculo = lblPlacaVehiculo.Text;

            fechaInicial = dtpFechaInicial.SelectedDate;

            fechaFinal = dtpFechaFinal.SelectedDate;

            IDSede = Convert.ToInt32(lblIDSede.Text);

            IDPoliza = Convert.ToInt32(cboPoliza.SelectedValue);

            IDCargoEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);

            clsRegistroRenta oRegistroRenta = new clsRegistroRenta();

            oRegistroRenta.cedulaCliente = cedulaCliente;

            oRegistroRenta.placaVehiculo = placaVehiculo;

            oRegistroRenta.fechaInicial = fechaInicial;

            oRegistroRenta.fechaFinal = fechaFinal;            

            oRegistroRenta.IDPoliza = IDPoliza;

            oRegistroRenta.IDSede = IDSede;

            oRegistroRenta.IDCargoEmpleado = IDCargoEmpleado;

            oRegistroRenta.numeroDias = Convert.ToInt32(lblNumeroDias.Text);

            oRegistroRenta.precio = Convert.ToInt32(lblPrecioDB.Text);
            
            if (oRegistroRenta.Insertar())
            {

                lblError.Text = "RENTA REGISTRADA CON EXITO";

                LlenarGridRenta();

            }
            else
            {

                lblError.Text = oRegistroRenta.error;

            }

            oRegistroRenta = null;

            txtCodigo.Text = "";

            txtCedulaCliente.Text = "";                       

        }

        private void CalcularPrecioRenta() 
        {

            TimeSpan numDias;
            DateTime fechaInicial, fechaFinal;
            Int32 numeroDias, precioVehiculo, precioRenta, IDPoliza, precioPoliza;
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
                 1) El precio de los vehiculos de gama baja es de 65mil por 1 dia de renta
                 2)El precio de los vehiculos de gama media es de 90mil por 1 dia de renta
                 3)El precio del tipo de poliza sencilla es de 150000 por la renta
                 4)El precio del tipo de poliza media es de 250000 por la renta
                 5)El precio del tipo de poliza de crubimiento total es de 400000 por la renta
                 */

                precioVehiculo = oVehiculo.precio;

                if (oPoliza.ConsultarPrecio())
                {

                    precioPoliza = oPoliza.precio;

                    fechaInicial = dtpFechaInicial.SelectedDate;

                    fechaFinal = dtpFechaFinal.SelectedDate;

                    numDias = fechaFinal - fechaInicial;

                    numeroDias = numDias.Days;

                    precioRenta = (numeroDias * precioVehiculo) + precioPoliza;

                    lblPrecioDB.Text = precioRenta.ToString();

                    lblNumeroDias.Text = numeroDias.ToString();

                    lblPrecio.Text = "$ " + precioRenta.ToString("#,###");                                        

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

            CalcularPrecioRenta();

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
               
        protected void grdRegistroRenta_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 precio;

            MostrarInformacionInvisible();

            txtCodigo.Text = grdRegistroRenta.SelectedRow.Cells[11].Text;

            txtCedulaCliente.Text = grdRegistroRenta.SelectedRow.Cells[1].Text;

            lblSedeVehiculo.Text = grdRegistroRenta.SelectedRow.Cells[8].Text;

            cboPoliza.Text = grdRegistroRenta.SelectedRow.Cells[13].Text;

            cboEmpleado.Text = grdRegistroRenta.SelectedRow.Cells[12].Text;
                        
            lblNumeroDias.Text = grdRegistroRenta.SelectedRow.Cells[6].Text;

            precio = Convert.ToInt32(grdRegistroRenta.SelectedRow.Cells[10].Text);

            lblPrecio.Text = "$ " +precio.ToString("#,###");

            lblError.Text = "";

            btnConsultarPrecio.Visible = true;

            btnRentarVehiculo.Visible = false;

            btnActualizarRenta.Visible = true;

            btnEliminarRenta.Visible = true;            

        }

        protected void btnActualizarRenta_Click(object sender, EventArgs e)
        {

            Int32 codigo, numeroDias, precio, IDSede, IDPoliza, IDCargoEmpleado;

            DateTime fechaInicial, fechaFinal;

            string cedulaCliente, placaVehiculo;

            codigo = Convert.ToInt32(txtCodigo.Text);

            cedulaCliente = txtCedulaCliente.Text;

            placaVehiculo = lblPlacaVehiculo.Text;

            fechaInicial = dtpFechaInicial.SelectedDate;

            fechaFinal = dtpFechaFinal.SelectedDate;

            IDSede = Convert.ToInt32(lblIDSede.Text);

            IDPoliza = Convert.ToInt32(cboPoliza.SelectedValue);

            IDCargoEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);

            CalcularPrecioRenta();

            numeroDias = Convert.ToInt32(lblNumeroDias.Text);

            precio = Convert.ToInt32(lblPrecioDB.Text);

            clsRegistroRenta oRegistroRenta = new clsRegistroRenta();

            oRegistroRenta.codigo = codigo;

            oRegistroRenta.cedulaCliente = cedulaCliente;

            oRegistroRenta.placaVehiculo = placaVehiculo;

            oRegistroRenta.fechaInicial = fechaInicial;

            oRegistroRenta.fechaFinal = fechaFinal;

            oRegistroRenta.IDSede = IDSede;

            oRegistroRenta.IDPoliza = IDPoliza;
            
            oRegistroRenta.IDCargoEmpleado = IDCargoEmpleado;

            oRegistroRenta.numeroDias = numeroDias;

            oRegistroRenta.precio = precio;

            if (oRegistroRenta.Actualizar())
            {

                lblError.Text = "RENTA ACTUALIZADA CON EXITO";

                LlenarGridRenta();

            }
            else
            {

                lblError.Text = oRegistroRenta.error;

            }

            oRegistroRenta = null;

            txtCodigo.Text = "";

            txtCedulaCliente.Text = "";

        }

        protected void btnEliminarRenta_Click(object sender, EventArgs e)
        {

            Int32 codigo;

            codigo = Convert.ToInt32(txtCodigo.Text);

            clsRegistroRenta oRegistroRenta = new clsRegistroRenta();

            oRegistroRenta.codigo = codigo;

            if (oRegistroRenta.Eliminar())
            {

                lblError.Text = "RENTA ELIMINADA CON EXITO";

                LlenarGridRenta();

            }
            else
            {

                lblError.Text = oRegistroRenta.error;

            }

            oRegistroRenta = null;

            txtCodigo.Text = "";

            txtCedulaCliente.Text = "";

            lblNumeroDias.Text = "";

            lblPrecio.Text = "";

        }
               
    }
}