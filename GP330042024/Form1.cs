using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GP330042024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mtd.dgvyukle(dataGridView1);
            string sql = "select * from poller";
            mtd.lbyukle(listBox1,sql);
        }
            metodlar mtd =new metodlar();//instance/newlemek

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenpol = listBox1.SelectedValue.ToString(); 
            string sql = "select * from doktorlar where polno='"+secilenpol+"'";
            mtd.lbyukle(listBox2,sql);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {   string doktorno=listBox2.SelectedValue.ToString();
            string tarih=dateTimePicker1.Value.ToShortDateString();//
            string sql = "select * from saatler where saatno not in (select saatno from randevular where doktorno='"+doktorno+"' and tarih='"+tarih+"')";
            mtd.lbyukle(listBox3,sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hasta = textBox1.Text;
            string tc = textBox2.Text;
            string doktorno = listBox2.SelectedValue.ToString();
            string tarih=dateTimePicker1.Value.ToShortDateString();
            string saatno = listBox3.SelectedValue.ToString();
            mtd.randevuekle(hasta,tc,doktorno,tarih,saatno);
            mtd.dgvyukle(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int randevuno = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Eminmisiniz, "+randevuno+" nolu randevu silinecek","Siliniyor",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                mtd.randevusil(randevuno);
                mtd.dgvyukle(dataGridView1);
            }          
            
        }
    }
}
