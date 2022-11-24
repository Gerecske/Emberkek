using Emberkek.Properties;
using Microsoft.Data.SqlClient;

namespace Emberkek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            using SqlConnection conn = new(Resources.ConnectionString);
            conn.Open();

            SqlDataReader reader = new SqlCommand("SELECT * FROM emberek;", conn).ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader[1];
                bool gender = reader.GetBoolean(2);
                string genderr = "Nõ";
                if (gender == true)
                {
                    genderr = "Férfi";
                }
                var date = reader.GetDateTime(3).ToLongDateString();

                dataGridView1.Rows.Add(id, name, genderr, date);
            }
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "Férfi")
            {
                radioButton_N.Checked = false;
                radioButton_F.Checked = true;
            }
            else
            {
                radioButton_N.Checked = true;
                radioButton_F.Checked = false;
            }

            dateTimePicker = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
        }
    }
}