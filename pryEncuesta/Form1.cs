using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryEncuesta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TABLA tabla = new TABLA();
        List<string> tabs = new List<string>();
        

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql1 = "Select * from Localidades";
            string sql2 = "Select * from Profesiones";
            string sql3 = "Select * from Encuestas";
            DataTable dt = tabla.GetData(sql1);
            DataTable dt2 = tabla.GetData(sql2);
            DataTable dt3 = tabla.GetData(sql3);

            foreach (DataRow fila in dt.Rows)
            {
                string nombreloc = fila["nombre"].ToString();
                Int32 CodLocalidad = Convert.ToInt32(fila["localidad"]);

                //RowIndex para agregar los datos en el ultimo foreach
                int rowIndex = dataGridView1.Rows.Add(nombreloc);

                    
                
                
                
                foreach (DataRow fila2 in dt2.Rows)
                {
                    DataGridViewTextBoxColumn columnaTexto = new DataGridViewTextBoxColumn();

                    string nombreprof = fila2["nombre"].ToString();
                    Int32 CodProfesion = Convert.ToInt32(fila2["profesion"]);
                    columnaTexto.Tag = Convert.ToInt32(CodProfesion);

                    columnaTexto.HeaderText = nombreprof; // Puedes configurar el encabezado de la columna
                    columnaTexto.Name = nombreprof; // Dales un nombre único a las columnas si lo deseas

                    // Agregar la columna al DataGridView
                    if (!tabs.Contains(nombreprof))
                    {

                        dataGridView1.Columns.Add(columnaTexto);
                        

                        //Agrega la marca para el if
                        tabs.Add(nombreprof);


                    }
                    foreach (DataRow fila3 in dt3.Rows)
                    {
                        Int32 profesion = Convert.ToInt32(fila3["profesion"]);
                        Int32 localidad = Convert.ToInt32(fila3["localidad"]);
                        
                        

                        if (profesion == CodProfesion && localidad == CodLocalidad)
                        {


                            // Encuentra la columna correspondiente a la profesión
                            DataGridViewColumn columnaProfesion = dataGridView1.Columns[nombreprof];


                            

                            // Asigna el valor deseado a la celda de la columna y fila correspondiente
                            dataGridView1.Rows[rowIndex].Cells[columnaProfesion.Index].Value = fila3["cantidad"];

                            
                        }



                    }

                }
            }
            
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Comprueba si la celda actual está vacía
            if (e.Value == null)
            {
                // Si la celda está vacía, establece el valor como "0"
                e.Value = "0";
                // Indica que ya hemos formateado la celda, para que no entre en un bucle infinito
                e.FormattingApplied = true;
            }

            //Para que no se agregue una fila en blanco
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
