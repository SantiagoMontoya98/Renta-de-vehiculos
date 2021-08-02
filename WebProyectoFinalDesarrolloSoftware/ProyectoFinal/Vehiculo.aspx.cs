using System;
using System.Web.UI;
using ProyectoFinalDesarrolloSoftware.ProyectoFinal;

namespace WebProyectoFinalDesarrolloSoftware.ProyectoFinal
{
    public partial class Vehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                LlenarComboMarca();
                LlenarComboGama();
                LlenarComboColor();
                LlenarComboTipoVehiculo();
                LlenarGridVehiculo();
                ConsultarNombreSede();
            }

        }

        private void LlenarComboMarca()
        {
            //se invoca la clase tipo software pasa el combo vacio y lo recibe lleno
            clsMarca oMarca = new clsMarca();
            oMarca.CboMarca = cboMarca;
            if (!oMarca.LlenarCombo())
            {
                //Si no se puede ejeutar se lee el error
                lblError.Text = oMarca.Error;
            }
            oMarca = null;
        }
        private void LlenarComboGama()
        {
            //se invoca la clase tipo software pasa el combo vacio y lo recibe lleno
            clsGama oGama = new clsGama();
            oGama.CboGama = cboGama;
            if (!oGama.LlenarCombo())
            {
                //Si no se puede ejeutar se lee el error
                lblError.Text = oGama.Error;
            }
            oGama = null;
        }
        private void LlenarComboColor()
        {
            //se invoca la clase tipo software pasa el combo vacio y lo recibe lleno
            clsColor oColor = new clsColor();
            oColor.CboColor = cboColor;
            if (!oColor.LlenarCombo())
            {
                //Si no se puede ejeutar se lee el error
                lblError.Text = oColor.Error;
            }
            oColor = null;
        }
        private void LlenarComboTipoVehiculo()
        {
            //se invoca la clase tipo software pasa el combo vacio y lo recibe lleno
            clsTipoVehiculo oTipoVehiculo = new clsTipoVehiculo();
            oTipoVehiculo.CboTipoVehiculo = cboTipoVehiculo;
            if (!oTipoVehiculo.LlenarCombo())
            {
                //Si no se puede ejeutar se lee el error
                lblError.Text = oTipoVehiculo.Error;
            }
            oTipoVehiculo = null;
        }
        private void LlenarGridVehiculo()
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.grdVehiculo = grdVehiculo;
            if (!oVehiculo.LlenarGrid())
            {
                lblError.Text = oVehiculo.error;
            }
            oVehiculo = null;

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

        private void VaciarCampos()
        {

            txtPlaca.Text = "";

            txtDescripcion.Text = "";

            txtKilometrajeInicial.Text = "";

            txtKilometrajeFinal.Text = "";

            txtPrecio.Text = "";

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Int32 KilometrajeInicial, KilometrajeFinal, IDSede, IDMarca, IDGama, IDColor, IDTipoVehiculo, precio;
            string Placa,Descripcion;

            Placa = txtPlaca.Text;
            Descripcion = txtDescripcion.Text;
            KilometrajeInicial = Convert.ToInt32(txtKilometrajeInicial.Text);
            KilometrajeFinal = Convert.ToInt32(txtKilometrajeFinal.Text);
            IDSede = Convert.ToInt32(lblIDSede.Text);
            IDMarca = Convert.ToInt32(cboMarca.SelectedValue);
            IDGama = Convert.ToInt32(cboGama.SelectedValue);
            IDColor = Convert.ToInt32(cboColor.SelectedValue);
            IDTipoVehiculo = Convert.ToInt32(cboTipoVehiculo.SelectedValue);
            precio = Convert.ToInt32(txtPrecio.Text);

            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.placaVehiculo = Placa;
            oVehiculo.Descripcion= Descripcion;
            oVehiculo.KilometrajeInicial = KilometrajeInicial;
            oVehiculo.KilometrajeFinal = KilometrajeFinal;
            oVehiculo.IDSede = IDSede;
            oVehiculo.IDMarca = IDMarca;
            oVehiculo.IDGama = IDGama;
            oVehiculo.IDColor = IDColor;
            oVehiculo.IDTipoVehiculo = IDTipoVehiculo;
            oVehiculo.precio = precio;

            if (oVehiculo.Insertar())
            {
                lblError.Text = "";
                LlenarGridVehiculo();
                lblError.Text = "VEHICULO REGISTRADO CON EXITO";
            }
            else
            {
                lblError.Text = oVehiculo.error;
            }
                       
            oVehiculo = null;

            VaciarCampos();

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string Placa;

            Placa = txtPlaca.Text;

            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.placaVehiculo = txtPlaca.Text;

            if (oVehiculo.Borrar())
            {
                lblError.Text = "";
                LlenarGridVehiculo();
                lblError.Text = "VEHICULO BORRADO CON EXITO";
            }
            else
            {
                lblError.Text = oVehiculo.error;
            }
            oVehiculo = null;

            VaciarCampos();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 KilometrajeInicial, KilometrajeFinal, IDMarca, IDGama, IDColor, IDTipoVehiculo, precio;
            string Placa,Descripcion;

            Placa = txtPlaca.Text;
            Descripcion = txtDescripcion.Text;
            KilometrajeInicial = Convert.ToInt32(txtKilometrajeInicial.Text);
            KilometrajeFinal = Convert.ToInt32(txtKilometrajeFinal.Text);
            IDMarca = Convert.ToInt32(cboMarca.SelectedValue);
            IDGama = Convert.ToInt32(cboGama.SelectedValue);
            IDColor = Convert.ToInt32(cboColor.SelectedValue);
            IDTipoVehiculo = Convert.ToInt32(cboTipoVehiculo.SelectedValue);
            precio = Convert.ToInt32(txtPrecio.Text);

            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.placaVehiculo = Placa;
            oVehiculo.Descripcion = Descripcion;
            oVehiculo.KilometrajeInicial = KilometrajeInicial;
            oVehiculo.KilometrajeFinal = KilometrajeFinal;
            oVehiculo.IDMarca = IDMarca;
            oVehiculo.IDGama = IDGama;
            oVehiculo.IDColor = IDColor;
            oVehiculo.IDTipoVehiculo = IDTipoVehiculo;
            oVehiculo.precio = precio;

            if (oVehiculo.Actualizar())
            {
                lblError.Text = "";
                LlenarGridVehiculo();
                lblError.Text = "VEHICULO ACTUALIZADO CON EXITO";
            }
            else
            {
                lblError.Text = oVehiculo.error;
            }

            oVehiculo = null;

            VaciarCampos();
        }

        protected void grdSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtPlaca.Text = grdVehiculo.SelectedRow.Cells[1].Text;
            txtDescripcion.Text = grdVehiculo.SelectedRow.Cells[2].Text;
            txtKilometrajeInicial.Text = grdVehiculo.SelectedRow.Cells[3].Text;
            txtKilometrajeFinal.Text = grdVehiculo.SelectedRow.Cells[4].Text;
            cboMarca.Text = grdVehiculo.SelectedRow.Cells[11].Text;
            cboGama.Text = grdVehiculo.SelectedRow.Cells[12].Text;
            cboColor.Text = grdVehiculo.SelectedRow.Cells[13].Text;
            cboTipoVehiculo.Text = grdVehiculo.SelectedRow.Cells[14].Text;
            txtPrecio.Text = grdVehiculo.SelectedRow.Cells[9].Text;
            lblError.Text = "";

        }

    }
}