using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesForm
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // button: Clear
        private void button1_Click(object sender, EventArgs e)
        {
            // clears title and message textbox
            textBox1.Clear();
            textBox2.Clear();
        }
        // button: Add
        private void button2_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textBox1.Text, textBox2.Text);
            textBox1.Clear();
            textBox2.Clear();
        }
        // button: Delete

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index >= 0)
            {
                table.Rows[index].Delete();
            }
            textBox1.Clear();
            textBox2.Clear();

        }        
        // button: Read
        private void button4_Click(object sender, EventArgs e)
        {
            // find the user selected row
            int index = dataGridView1.CurrentCell.RowIndex;
            // as long as selected row is valid
            if (index >= 0)
            {
                // set title textbox to value in table in column "Title"
                textBox1.Text = table.Rows[index]["Title"].ToString();
                // set title textbox to value in table in column "Messages"
                textBox2.Text = table.Rows[index]["Message"].ToString();
            }
        }
        // Form1_Load is called when the program first runs
        private void Form1_Load(object sender, EventArgs e)
        {
            // initialize the message data table
            table = new DataTable();
            // create two columns in table,
            // one for title of notes and the other for content of notes
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Message", typeof(String));
            // connect grid to our DataTable table
            dataGridView1.DataSource = table;
            // dont display Message column, only title
            dataGridView1.Columns["Message"].Visible = false;
            // stretch title column out to cover entire box
            dataGridView1.Columns["Title"].Width = 237;
        }

        
    }
}
