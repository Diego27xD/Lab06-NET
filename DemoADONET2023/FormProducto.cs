using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidad;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DemoADONET2023
{
    public partial class FormProducto : Form
    {
        BProducto negocio = new BProducto();
        public FormProducto()
        {
            InitializeComponent();
             
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dataProducto.Columns.Add(btnEditar);
            dataProducto.DataSource = negocio.ListarTodo(txtNombre.Text);


        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();

                
                negocio.Insertar(new Entidad.Producto
                {
                    Nombre = textNombre.Text,
                    Precio = Convert.ToDecimal(textPrecio.Text),
                    Estado = cbEstado.Checked
                }) ;
                textNombre.Text = "";
                textPrecio.Text = "";
                cbEstado.Checked = false;
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

            }
        }

        private void dataProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataProducto.Columns.Contains("Editar") && e.RowIndex >= 0)
            {
                int id = (int) dataProducto.Rows[e.RowIndex].Cells["IdProducto"].Value;
                string nombre = dataProducto.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                decimal precio = Convert.ToDecimal(dataProducto.Rows[e.RowIndex].Cells["Precio"].Value);
                bool estado = Convert.ToBoolean(dataProducto.Rows[e.RowIndex].Cells["Estado"].Value);
                idProd.Text = id.ToString();
                textNombre.Text = nombre;
                textPrecio.Text = precio.ToString();
                cbEstado.Checked = estado;
                btnEliminar.Enabled = true;
                if(!cbEstado.Checked) btnEliminar.Enabled = false;
                
            }

            btnInsertar.Enabled = false;
            btnUpdate.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idProd.Text);
            negocio.Actualizar(id, new Entidad.Producto
            {
                Nombre = textNombre.Text,
                Precio = Convert.ToDecimal(textPrecio.Text),
                Estado = cbEstado.Checked
            });
            
            idProd.Text = "";
            textNombre.Text = "";
            textPrecio.Text = "";
            btnInsertar.Enabled = true;
            btnUpdate.Enabled = false;
            cbEstado.Checked = false;
            MessageBox.Show("Actualizacion exitosa");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idProd.Text);
            negocio.Delete(id, false);
            idProd.Text = "";
            textNombre.Text = "";
            textPrecio.Text = "";
            btnInsertar.Enabled = true;
            btnUpdate.Enabled = false;
            cbEstado.Checked = false;
            MessageBox.Show("Estado actualizado");
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dataProducto.Columns.Add(btnEditar);
            dataProducto.DataSource = negocio.Listar();
        }
    }
}
