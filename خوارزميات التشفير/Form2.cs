using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace خوارزميات_التشفير
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            textBox2.Text = Path.GetFileName(textBox1.Text);
            textBox3.Text = Path.GetExtension(textBox1.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.PasswordChar = '\0';
            }
            else
                textBox4.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Encript_File ef = new Encript_File(textBox4.Text);
                ef.encript(textBox1.Text);
                MessageBox.Show("تمت العمليه بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Encript_File ef = new Encript_File(textBox4.Text);
                ef.decript(textBox1.Text);
                MessageBox.Show("تم فك التشفير بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }
    }
}
