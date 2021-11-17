using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Movie_Rent_System
{
    public partial class DirectorSearch : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ZCM-233204433\SQLEXPRESS;Initial Catalog=movie_rental_wfa;Integrated Security=True");

        public DirectorSearch()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = $"SELECT * FROM Movies WHERE Director LIKE '{txt_DirectorSearch.Text}%' OR Director LIKE '%{txt_DirectorSearch.Text}'";
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = queryStr;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_MovieData.DataSource = table;
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred when performing the query");
                conn.Close();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
