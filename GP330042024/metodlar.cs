using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//

namespace GP330042024
{
    internal class metodlar
    {
        SqlConnection bag = new SqlConnection("server=orkinos\\orkinos;initial catalog=hastanerandevu;integrated security=true");
        public void lbyukle(ListBox lb, string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lb.DataSource = dt;
            lb.DisplayMember = dt.Columns[1].ColumnName;
            lb.ValueMember = dt.Columns[0].ColumnName; 
        }
        public void dgvyukle(DataGridView dgv)
        {
            string sql = "select r.randevuno, r.hasta,r.tc,r.tarih,d.doktor, s.saatler from randevular r,doktorlar d, saatler s where d.doktorno=r.doktorno and r.saatno=s.saatno";
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns[1].HeaderText = "HASTA ADI";
            dgv.Columns[2].HeaderText = "HASTA TC";
            dgv.Columns[3].HeaderText = "TARİH";
            dgv.Columns[4].HeaderText = "DOKTOR ADI";
            dgv.Columns[5].HeaderText = "SAAT";
            dgv.Columns[1].Width = 60;
            dgv.Columns[2].Width = 60;
            dgv.Columns[3].Width = 70;
        }
        public void randevuekle(string hasta,string tc,string doktorno,string tarih,string saatno)
        {

            string sql = "insert into randevular (hasta,tc,doktorno,tarih,saatno) values (@prmhasta,@prmtc,'"+doktorno+"','"+tarih+"','"+saatno+"')";
            SqlCommand komut = new SqlCommand(sql,bag);
            komut.Parameters.AddWithValue("@prmhasta", hasta);
            komut.Parameters.AddWithValue("@prmtc", tc);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Kaydedildi");
            
        }
        public void randevusil(int randevuno)
        {
            string sql = "delete from randevular where randevuno='"+randevuno+"'";
            SqlCommand komut=new SqlCommand(sql,bag);   
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("silindi");


        }
    }
}
