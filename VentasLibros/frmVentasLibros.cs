using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace VentasLibros
{
    public partial class frmVentasLibros : Form
    {

        int precio = 0;
        public frmVentasLibros()
        {
            InitializeComponent();
        }
        private void FrmVentasLibros_Load(object sender, EventArgs e)
        {
            //Asignamos la fecha actual al label lblFecha
           
            lblFecha.Text = DateTime.Today.Date.ToString("d");
        }
        private void CboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Al cargar producto llenar el label PrecioUnitario

            if (cboProducto.SelectedItem != null) { 
            if (cboProducto.SelectedItem.ToString() == "Colección Escolar") precio = 240;
            if (cboProducto.SelectedItem.ToString() == "Colección PreUniversitaria") precio = 150;
            if (cboProducto.SelectedItem.ToString() == "Colección Profesional") precio = 350;

            lblPrecio.Text = precio.ToString();
        }
        }

        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Estas seguro?",
                                            "Venta",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //Limpiar campos y dejar el foco en el cboProducto

            
            cboProducto.Text=("Seleccione titulo");
            cboPago.Text=("Seleccione forma de pago");
            txtCantidad.Clear();
            lblPrecio.ResetText();
            cboProducto.Focus();
            
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            //Validamos entradas

            
            if (cboProducto.SelectedIndex == -1)
                MessageBox.Show("Debes seleccionar un libro");
            else
                if (!Information.IsNumeric(txtCantidad.Text))
                MessageBox.Show("Debes entrar una cantidad");
                else
                    if (cboPago.SelectedIndex == -1) MessageBox.Show("Debes entrar uan forma de pago.");
                    else
            {
                // Declaramos locales

                double descuento = 0;
                double recargo = 0;
                double precioFinal = 0;
                string pago = cboPago.Text;
                int cantidad = int.Parse(txtCantidad.Text);


                //Calcular nuevas variables

                if (pago == "Contado") descuento = (5.0 / 100) * precio;
                if (pago == "Tarjeta") recargo = (10.0 / 100) * precio;

                precioFinal = cantidad * (precio - descuento + recargo);

                //LLenamos el ListView

                ListViewItem fila = new ListViewItem(cboProducto.Text);
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString("0.00"));
                fila.SubItems.Add(pago);
                fila.SubItems.Add(descuento.ToString("0.00"));
                fila.SubItems.Add(recargo.ToString("0.00"));
                fila.SubItems.Add(precioFinal.ToString("0.00"));

                lvVentas.Items.Add(fila);
                cboPago.SelectedIndex = -1;
                cboProducto.SelectedIndex = -1;
                BtnCancelar_Click(sender, e);
                
            }

            
            
            


        }
    }
}
