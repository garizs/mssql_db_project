using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hdd_db
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        SqlCommand SqlCommand;
        SqlDataAdapter ADP;
        DataTable DT;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnSave.Enabled = true;
            dataGridView1.DataSource = null;
            if (comboBox1.SelectedIndex == 0)
            { 
                SqlCommand = new SqlCommand("SELECT db_hdds.hdds.hdd_id, db_hdds.brand.*, db_hdds.form_factor.*, db_hdds.interface.*, db_hdds.speed.*, db_hdds.volume.*  " +
                    "FROM db_hdds.hdds " +
                    "INNER JOIN db_hdds.brand ON db_hdds.brand.brand_id = db_hdds.hdds.brand_id " +
                    "INNER JOIN db_hdds.form_factor ON db_hdds.form_factor.form_id = hdds.form_id " +
                    "INNER JOIN db_hdds.interface ON db_hdds.interface.interface_id = hdds.interface_id " +
                    "INNER JOIN db_hdds.speed ON db_hdds.speed.speed_id = hdds.speed_id " +
                    "INNER JOIN db_hdds.volume ON db_hdds.volume.volume_id = hdds.volume_id;", hdd_db.SqlCon);
                ADP = new SqlDataAdapter(SqlCommand);
                DT = new DataTable();
                ADP.Fill(DT);
                dataGridView1.DataSource = DT;
                hdd_db.closeDB();
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            if (comboBox1.SelectedIndex == 1)
            { 
                SqlCommand = new SqlCommand("SELECT db_hdds.brand.* FROM db_hdds.brand;", hdd_db.SqlCon);
                ADP = new SqlDataAdapter(SqlCommand);
                DT = new DataTable();
                ADP.Fill(DT);
                dataGridView1.DataSource = DT;
                hdd_db.closeDB();
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                SqlCommand = new SqlCommand("SELECT db_hdds.form_factor.* FROM db_hdds.form_factor;", hdd_db.SqlCon);
                ADP = new SqlDataAdapter(SqlCommand);
                DT = new DataTable();
                ADP.Fill(DT);
                dataGridView1.DataSource = DT;
                hdd_db.closeDB();
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                SqlCommand = new SqlCommand("SELECT db_hdds.speed.* FROM db_hdds.speed;", hdd_db.SqlCon);
                ADP = new SqlDataAdapter(SqlCommand);
                DT = new DataTable();
                ADP.Fill(DT);
                dataGridView1.DataSource = DT;
                hdd_db.closeDB();
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                SqlCommand = new SqlCommand("SELECT db_hdds.volume.* FROM db_hdds.volume;", hdd_db.SqlCon);
                ADP = new SqlDataAdapter(SqlCommand);
                DT = new DataTable();
                ADP.Fill(DT);
                dataGridView1.DataSource = DT;
                hdd_db.closeDB();
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                SqlCommand = new SqlCommand("SELECT db_hdds.interface.* FROM db_hdds.interface;", hdd_db.SqlCon);
                ADP = new SqlDataAdapter(SqlCommand);
                DT = new DataTable();
                ADP.Fill(DT);
                dataGridView1.DataSource = DT;
                hdd_db.closeDB();
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                SqlCommand = new SqlCommand("SELECT db_hdds.hdds.* FROM db_hdds.hdds;", hdd_db.SqlCon);
                ADP = new SqlDataAdapter(SqlCommand);
                DT = new DataTable();
                ADP.Fill(DT);
                dataGridView1.DataSource = DT;
                hdd_db.closeDB();
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ADP = new SqlDataAdapter(SqlCommand);
            DT = new DataTable();
            ADP.Fill(DT);
            dataGridView1.DataSource = DT;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            hdd_db.openDB();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (comboBox1.SelectedIndex == -1)
            {
                btnRefresh.Enabled = false;
                btnSave.Enabled = false;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            ADP.UpdateCommand = new SqlCommandBuilder(ADP).GetUpdateCommand();
            ADP.Update(DT);
            ADP = new SqlDataAdapter(SqlCommand);
            DT = new DataTable();
            ADP.Fill(DT);
            dataGridView1.DataSource = DT;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            hdd_db.closeDB();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form SearchForm = new SearchForm();
            SearchForm.ShowDialog();
        }
    }
}
