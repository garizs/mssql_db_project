using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hdd_db
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        SqlCommand SqlCommand1;
        SqlDataAdapter ADP1;
        DataTable DT1;
        SqlCommand SqlCommand2;
        SqlDataAdapter ADP2;
        DataTable DT2;
        SqlCommand SqlCommand3;
        SqlDataAdapter ADP3;
        DataTable DT3;
        SqlCommand SqlCommand4;
        SqlDataAdapter ADP4;
        DataTable DT4;
        SqlCommand SqlCommand5;
        SqlDataAdapter ADP5;
        DataTable DT5;
        double max = 0, max_id = 0;
        private void SearchForm_Load(object sender, EventArgs e)
        {
            hdd_db.openDB();
            dataGridView1.AutoSizeColumnsMode=
                dataGridView2.AutoSizeColumnsMode=
                dataGridView3.AutoSizeColumnsMode=
                dataGridView4.AutoSizeColumnsMode=
                dataGridView5.AutoSizeColumnsMode
                = DataGridViewAutoSizeColumnsMode.Fill;
            SqlCommand1 = new SqlCommand("SELECT * FROM db_hdds.brand", hdd_db.SqlCon);
            SqlCommand2 = new SqlCommand("SELECT * FROM db_hdds.form_factor", hdd_db.SqlCon);
            SqlCommand3 = new SqlCommand("SELECT * FROM db_hdds.interface", hdd_db.SqlCon);
            SqlCommand4 = new SqlCommand("SELECT * FROM db_hdds.speed", hdd_db.SqlCon);
            SqlCommand5 = new SqlCommand("SELECT * FROM db_hdds.volume", hdd_db.SqlCon);
            ADP1 = new SqlDataAdapter(SqlCommand1);
            DT1 = new DataTable();
            ADP1.Fill(DT1);
            dataGridView1.DataSource = DT1;
            ADP2 = new SqlDataAdapter(SqlCommand2);
            DT2 = new DataTable();
            ADP2.Fill(DT2);
            dataGridView2.DataSource = DT2;
            ADP3 = new SqlDataAdapter(SqlCommand3);
            DT3 = new DataTable();
            ADP3.Fill(DT3);
            dataGridView3.DataSource = DT3;
            ADP4 = new SqlDataAdapter(SqlCommand4);
            DT4 = new DataTable();
            ADP4.Fill(DT4);
            dataGridView4.DataSource = DT4;
            ADP5 = new SqlDataAdapter(SqlCommand5);
            DT5 = new DataTable();
            ADP5.Fill(DT5);
            dataGridView5.DataSource = DT5;
            for (int i = 0; i <= dataGridView4.Rows.Count - 1; i++)
                for (int j = 1; j <= dataGridView4.ColumnCount - 1; j++)
                    if (dataGridView4.Rows[i].Cells[j].Value != null && Convert.ToDouble(dataGridView4.Rows[i].Cells[j].Value) > max)
                    {
                        max = Convert.ToDouble(dataGridView4.Rows[i].Cells[j].Value);
                        max_id = Convert.ToDouble(dataGridView4.Rows[i].Cells[0].Value);
                    }
            for (int i = 0; i <= dataGridView5.Rows.Count - 1; i++)
                for (int j = 1; j <= dataGridView5.ColumnCount - 1; j++)
                    if (dataGridView5.Rows[i].Cells[j].Value != null && Convert.ToDouble(dataGridView5.Rows[i].Cells[j].Value) > max)
                    {
                        max = Convert.ToDouble(dataGridView5.Rows[i].Cells[j].Value);
                        max_id = Convert.ToDouble(dataGridView5.Rows[i].Cells[0].Value);
                    }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = textBox3.Enabled = false;
            if(string.IsNullOrEmpty(textBox1.Text))
                textBox2.Enabled = textBox3.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            if (string.IsNullOrEmpty(textBox2.Text))
                textBox1.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            if (string.IsNullOrEmpty(textBox3.Text))
                textBox1.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox3.Text))
            {
                SqlCommand1 = new SqlCommand("SELECT * FROM db_hdds.brand GROUP BY brand_id, name_brand HAVING name_brand = " + "'" + textBox1.Text + "'", hdd_db.SqlCon);
                SqlCommand2 = new SqlCommand("SELECT * FROM db_hdds.form_factor GROUP BY form_id, form_factor HAVING form_factor =" + "'" + textBox1.Text + "'", hdd_db.SqlCon);
                SqlCommand3 = new SqlCommand("SELECT * FROM db_hdds.interface GROUP BY interface_id, interface HAVING interface =" + "'" + textBox1.Text + "'", hdd_db.SqlCon);
                SqlCommand4 = new SqlCommand("SELECT * FROM db_hdds.speed GROUP BY speed_id, speed HAVING speed =" + "'" + textBox1.Text + "'", hdd_db.SqlCon);
                SqlCommand5 = new SqlCommand("SELECT * FROM db_hdds.volume GROUP BY volume_id, volume HAVING volume =" + "'" + textBox1.Text + "'", hdd_db.SqlCon);
                ADP1 = new SqlDataAdapter(SqlCommand1);
                DT1 = new DataTable();
                ADP1.Fill(DT1);
                dataGridView1.DataSource = DT1;
                ADP2 = new SqlDataAdapter(SqlCommand2);
                DT2 = new DataTable();
                ADP2.Fill(DT2);
                dataGridView2.DataSource = DT2;
                ADP3 = new SqlDataAdapter(SqlCommand3);
                DT3 = new DataTable();
                ADP3.Fill(DT3);
                dataGridView3.DataSource = DT3;
                ADP4 = new SqlDataAdapter(SqlCommand4);
                DT4 = new DataTable();
                ADP4.Fill(DT4);
                dataGridView4.DataSource = DT4;
                ADP5 = new SqlDataAdapter(SqlCommand5);
                DT5 = new DataTable();
                ADP5.Fill(DT5);
                dataGridView5.DataSource = DT5;
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                if (double.TryParse(textBox3.Text, out double d) && double.TryParse(textBox2.Text, out d))
                {
                    label10.Visible = label11.Visible = label12.Visible = true;
                    SqlCommand1 = new SqlCommand("SELECT * FROM db_hdds.speed WHERE speed < " + Convert.ToDouble(textBox3.Text)
                    + " and speed > " + Convert.ToDouble(textBox2.Text), hdd_db.SqlCon);
                    ADP1 = new SqlDataAdapter(SqlCommand1);
                    DT1 = new DataTable();
                    ADP1.Fill(DT4);
                    dataGridView4.DataSource = DT1;
                    SqlCommand2 = new SqlCommand("SELECT * FROM db_hdds.volume WHERE volume < " + Convert.ToDouble(textBox3.Text)
                    + " and volume > " + Convert.ToDouble(textBox2.Text), hdd_db.SqlCon);
                    ADP2 = new SqlDataAdapter(SqlCommand2);
                    DT2 = new DataTable();
                    ADP2.Fill(DT2);
                    dataGridView5.DataSource = DT2;
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            label10.Visible = label11.Visible = label12.Visible = false;
            SqlCommand1 = new SqlCommand("SELECT * FROM db_hdds.brand", hdd_db.SqlCon);
            SqlCommand2 = new SqlCommand("SELECT * FROM db_hdds.form_factor", hdd_db.SqlCon);
            SqlCommand3 = new SqlCommand("SELECT * FROM db_hdds.interface", hdd_db.SqlCon);
            SqlCommand4 = new SqlCommand("SELECT * FROM db_hdds.speed", hdd_db.SqlCon);
            SqlCommand5 = new SqlCommand("SELECT * FROM db_hdds.volume", hdd_db.SqlCon);
            ADP1 = new SqlDataAdapter(SqlCommand1);
            DT1 = new DataTable();
            ADP1.Fill(DT1);
            dataGridView1.DataSource = DT1;
            ADP2 = new SqlDataAdapter(SqlCommand2);
            DT2 = new DataTable();
            ADP2.Fill(DT2);
            dataGridView2.DataSource = DT2;
            ADP3 = new SqlDataAdapter(SqlCommand3);
            DT3 = new DataTable();
            ADP3.Fill(DT3);
            dataGridView3.DataSource = DT3;
            ADP4 = new SqlDataAdapter(SqlCommand4);
            DT4 = new DataTable();
            ADP4.Fill(DT4);
            dataGridView4.DataSource = DT4;
            ADP5 = new SqlDataAdapter(SqlCommand5);
            DT5 = new DataTable();
            ADP5.Fill(DT5);
            dataGridView5.DataSource = DT5;
        }

        private void btnSearchMax_Click(object sender, EventArgs e)
        {
            SqlCommand1 = new SqlCommand("SELECT * from db_hdds.brand where brand_id = " + max_id + " and name_brand = " + max, hdd_db.SqlCon);
            SqlCommand2 = new SqlCommand("SELECT * from db_hdds.form_factor where form_id = " + max_id + " and form_factor = " + max, hdd_db.SqlCon);
            SqlCommand3 = new SqlCommand("SELECT * from db_hdds.interface where interface_id = " + max_id + " and interface = " + max, hdd_db.SqlCon);
            SqlCommand4 = new SqlCommand("SELECT * from db_hdds.speed where speed_id = " + max_id + " and speed = " + max, hdd_db.SqlCon);
            SqlCommand5 = new SqlCommand("SELECT * from db_hdds.volume where volume_id = " + max_id + " and volume = " + max, hdd_db.SqlCon);
            ADP1 = new SqlDataAdapter(SqlCommand1);
            DT1 = new DataTable();
            ADP1.Fill(DT1);
            dataGridView1.DataSource = DT1;
            ADP2 = new SqlDataAdapter(SqlCommand2);
            DT2 = new DataTable();
            ADP2.Fill(DT2);
            dataGridView2.DataSource = DT2;
            ADP3 = new SqlDataAdapter(SqlCommand3);
            DT3 = new DataTable();
            ADP3.Fill(DT3);
            dataGridView3.DataSource = DT3;
            ADP4 = new SqlDataAdapter(SqlCommand4);
            DT4 = new DataTable();
            ADP4.Fill(DT4);
            dataGridView4.DataSource = DT4;
            ADP5 = new SqlDataAdapter(SqlCommand5);
            DT5 = new DataTable();
            ADP5.Fill(DT5);
            dataGridView5.DataSource = DT5;
        }
    }
}
