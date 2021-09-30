﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo5
{
    public partial class Form1 : Form
    {
        /*listado que permite tener varios elementos de la clase Persona*/
        private List<Persona> Personas = new List<Persona>();
        private int edit_indice = -1; //el índice para editar comienza en -1, esto significa que no hay ninguno seleccionado, esto servirá para el DataGridView.

        private void actualizarGrid()
        {
            dgvcontactos.DataSource = null;
            dgvcontactos.DataSource = Personas; /*los nombres de columna que veremos son los de las propiedades*/
        }
        
        
        private void limpiar()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txttelefono.Clear();
            txtcorreo.Clear();
        }
        
       
        public Form1()
        {
            InitializeComponent();
        }
        private void OrdenA()
        {
            dgvcontactos.Sort(dgvcontactos.Columns(txtnombre.Text), ListSortDirection.Ascending);
        }
        private void dgvcontactos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dgvcontactos.SelectedRows[0];
            int pos = dgvcontactos.Rows.IndexOf(seleccion);//almacena en cual fila estoy
            edit_indice = pos;//copio esa variable en índice editado

            Persona per = Personas[pos];/*esta variable de tipo persona, se carga con los valores que le pasa el listado*/

            txtnombre.Text = per.Nombre; //lo que tiene el atributo se lo doy al textbox
            txtapellido.Text = per.Apellido;
            txttelefono.Text = per.Telefono;
            txtcorreo.Text = per.Correo;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //creo un objeto de la clase persona y guardo a través de las propiedades
            Persona per = new Persona();
            per.Nombre = txtnombre.Text;
            per.Apellido = txtapellido.Text;
            per.Telefono = txttelefono.Text;
            per.Correo = txtcorreo.Text;

            if (edit_indice > -1)//verifica si hay un índice seleccionado
            {
                Personas[edit_indice] = per;
                edit_indice = -1;
            }

            else
            {
                Personas.Add(per);/*al arreglo de Personas le agrego el objeto creado con todos los datos que recolecté*/
            }
            actualizarGrid();//llamamos al procedimiento que guarda en datagrid
            limpiar();//mandamos a llamar la función que limpia
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (edit_indice > -1)//verifica si hay un índice seleccionado
            {
                Personas.RemoveAt(edit_indice);
                edit_indice = -1; //resetea variable a -1
                limpiar();
                actualizarGrid();
            }
            else
            {
                MessageBox.Show("Debe dar doble click primero sobre contacto");
            }
        }

        private void btnenviardatos_Click(object sender, EventArgs e)
        {
            Form2 formulario = new Form2();//instancia de otro formulario
            formulario.PersonaRecibe = Personas; /*lista original Personas es enviada a la lista Persona Recibe que está en el formulario 2 y que puede ser invocada por medio de la instancia del segundo formulario */
            formulario.Show();//mostar el segundo formulario
        }

        private void btnordenar_Click(object sender, EventArgs e)
        {
           
        
        }


    }
}


    

       
