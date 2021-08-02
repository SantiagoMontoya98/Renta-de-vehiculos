using System;
using System.Web.UI;
using ProyectoFinalDesarrolloSoftware.ProyectoFinal;

namespace WebProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public partial class Devolucion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //La primera vez que se carga la página se invoca el método para llenar el combo
                LlenarComboCargoEmpleado();
                LlenarGridDevolucion();
            }
        }
        private void LlenarComboCargoEmpleado()
        {
            //se invoca la clase tipo software pasa el combo vacio y lo recibe lleno
            clsEmpleado oCargoEmpleado = new clsEmpleado();
            oCargoEmpleado.cboEmpleado = cboCargoEmpleado;
            if (!oCargoEmpleado.LlenarCombo())
            {
                //Si no se puede ejeutar se lee el error
                lblError.Text = oCargoEmpleado.error;
            }
            oCargoEmpleado = null;
        }

        private void LlenarGridDevolucion()
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            oDevolucion.grdDevolucion = grdDevolucion;
            if (!oDevolucion.LlenarGrid())
            {
                lblError.Text = oDevolucion.Error;
            }
            oDevolucion = null;

        }               

        protected void btnInsertar_Click(object sender, EventArgs e) 
        { 
        Int32  IDCargoEmpleado, IDSede, KilometrajeInicialVehiculo, KilometrajeFinalVehiculo;
        Int32 KilometrosRecorridos;
        string CedulaCliente, PlacaVehiculo;
        DateTime FechaEntrega;
                        
            CedulaCliente = txtCedulaCliente.Text;
            PlacaVehiculo = txtPlacaVehiculo.Text;
            IDCargoEmpleado = Convert.ToInt32(cboCargoEmpleado.SelectedValue);
            IDSede = Convert.ToInt32(lblIDSede.Text);
            FechaEntrega = dtpFechaEntrega.SelectedDate;
            KilometrajeFinalVehiculo = Convert.ToInt32(txtKilometrajeFinalVehiculo.Text);

            clsDevolucion oDevolucion = new clsDevolucion();

            clsVehiculo oVehiculo = new clsVehiculo();
            
            oDevolucion.CedulaCliente = CedulaCliente;
            oDevolucion.PlacaVehiculo = PlacaVehiculo;
            oDevolucion.IDCargoEmpleado = IDCargoEmpleado;
            oDevolucion.IDSede = IDSede;
            oDevolucion.FechaEntrega = FechaEntrega;            
            oVehiculo.placaVehiculo = PlacaVehiculo;

            if (oVehiculo.ConsultarKilometrajeInicial()) 
            {

                lblKilometrosRecorridos.Text = "";

                KilometrajeInicialVehiculo = oVehiculo.KilometrajeInicial;

                KilometrosRecorridos = KilometrajeFinalVehiculo - KilometrajeInicialVehiculo;

                lblKilometrosRecorridos.Text = KilometrosRecorridos.ToString();              

                oDevolucion.KilometrajeFinalVehiculo = KilometrajeInicialVehiculo + KilometrosRecorridos;

                oDevolucion.KilometrosRecorridos = KilometrosRecorridos;

            }
            else
            {

                lblError.Text = oVehiculo.error;

            }            

            if (oDevolucion.Insertar())
            {

                if (oDevolucion.ActualizarKilometrajeVehiculo())
                {

                    lblError.Text = "";
                    LlenarGridDevolucion();
                    lblError.Text = "DEVOLUCION REGISTRADA CON EXITO";
                    

                }
                else
                {

                    lblError.Text = oDevolucion.Error;

                }
               
            }
            else
            {
                lblError.Text = oDevolucion.Error;
            }
                oDevolucion = null;

                oVehiculo = null;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);

             clsDevolucion oDevolucion = new clsDevolucion();
            oDevolucion.Codigo = Codigo;

             if (oDevolucion.Borrar())
             {
                lblError.Text = "";
                LlenarGridDevolucion();
                lblError.Text = "DEVOLUCION ELIMINADA CON EXITO";
                
            }
         else
         {
                lblError.Text = oDevolucion.Error;
         }
                oDevolucion = null;

     }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 Codigo, IDCargoEmpleado, IDSede, KilometrajeInicialVehiculo, KilometrajeFinalVehiculo;
            Int32 KilometrosRecorridos;
            string CedulaCliente, PlacaVehiculo;
            DateTime FechaEntrega;

            Codigo = Convert.ToInt32(txtCodigo.Text);
            CedulaCliente = txtCedulaCliente.Text;
            PlacaVehiculo = txtPlacaVehiculo.Text;
            IDCargoEmpleado = Convert.ToInt32(cboCargoEmpleado.SelectedValue);
            IDSede = Convert.ToInt32(lblIDSede.Text);
            FechaEntrega = dtpFechaEntrega.SelectedDate;
            KilometrajeFinalVehiculo = Convert.ToInt32(txtKilometrajeFinalVehiculo.Text);

            clsDevolucion oDevolucion = new clsDevolucion();

            clsVehiculo oVehiculo = new clsVehiculo();

            oDevolucion.Codigo = Codigo;
            oDevolucion.CedulaCliente = CedulaCliente;
            oDevolucion.PlacaVehiculo = PlacaVehiculo;
            oDevolucion.IDCargoEmpleado = IDCargoEmpleado;
            oDevolucion.IDSede = IDSede;
            oDevolucion.FechaEntrega = FechaEntrega;
            oVehiculo.placaVehiculo = PlacaVehiculo;

            if (oVehiculo.ConsultarKilometrajeInicial())
            {

                lblKilometrosRecorridos.Text = "";

                KilometrajeInicialVehiculo = oVehiculo.KilometrajeInicial;

                KilometrosRecorridos = KilometrajeFinalVehiculo - KilometrajeInicialVehiculo;

                lblKilometrosRecorridos.Text = KilometrosRecorridos.ToString();

                oDevolucion.KilometrajeFinalVehiculo = KilometrajeInicialVehiculo + KilometrosRecorridos;

                oDevolucion.KilometrosRecorridos = KilometrosRecorridos;

            }
            else
            {

                lblError.Text = oVehiculo.error;

            }

            if (oDevolucion.Actualizar())
            {

                if (oDevolucion.ActualizarKilometrajeVehiculo())
                {

                    lblError.Text = "";
                    LlenarGridDevolucion();
                    lblError.Text = "DEVOLUCION ACTUALIZADA CON EXITO";
                    

                }
                else
                {

                    lblError.Text = oDevolucion.Error;


                }
                
             }
             else
            {
                 lblError.Text = oDevolucion.Error;
            }
                oDevolucion = null;
        }

        protected void grdDevolucion_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtCodigo.Text = grdDevolucion.SelectedRow.Cells[9].Text;
            txtCedulaCliente.Text = grdDevolucion.SelectedRow.Cells[1].Text;
            txtPlacaVehiculo.Text = grdDevolucion.SelectedRow.Cells[4].Text;
            cboCargoEmpleado.SelectedValue = grdDevolucion.SelectedRow.Cells[10].Text;            
            txtKilometrajeFinalVehiculo.Text = grdDevolucion.SelectedRow.Cells[7].Text;
            lblKilometrosRecorridos.Text = grdDevolucion.SelectedRow.Cells[8].Text;
                        
        }

        protected void btnFactura_Click(object sender, EventArgs e)
        {

            string cedulaCliente, placaVehiculo, kilometrosRecorridos;           

            cedulaCliente = txtCedulaCliente.Text;

            placaVehiculo = txtPlacaVehiculo.Text;

            kilometrosRecorridos = lblKilometrosRecorridos.Text;

            Response.Redirect("Factura.aspx?cedulaCliente=" + cedulaCliente + "&placaVehiculo=" + placaVehiculo + "&kilometrosRecorridos=" + kilometrosRecorridos);


        }
    }
}