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
    public partial class MovieMaint : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ZCM-233204433\SQLEXPRESS;Initial Catalog=movie_rental_wfa;Integrated Security=True");
        int selectedMovieID;

        public MovieMaint()
        {
            InitializeComponent();
        }

        private void ShowData()
        {
            try
            {
                string queryStr = "SELECT * FROM movies";
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

        private void MovieMaint_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dgv_MovieData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedMovieID = Convert.ToInt16(dgv_MovieData.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_Title.Text = dgv_MovieData.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Director.Text = dgv_MovieData.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Actors.Text = dgv_MovieData.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Genre.Text = dgv_MovieData.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (dgv_MovieData.Rows[e.RowIndex].Cells[5].Value.ToString() == "True")
            {
                ckb_Premiere.Checked = true;
            }
            else if (dgv_MovieData.Rows[e.RowIndex].Cells[5].Value.ToString() == "False")
            {
                ckb_Premiere.Checked = false;
            }
            if (dgv_MovieData.Rows[e.RowIndex].Cells[6].Value.ToString() == "True")
            {
                ckb_Available.Checked = true;
            }
            else if (dgv_MovieData.Rows[e.RowIndex].Cells[6].Value.ToString() == "False")
            {
                ckb_Available.Checked = false;
            }
            btn_Insert.Text = "Insert";
            btn_Update.Enabled = true;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to save changes to this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    int premiere = 0, available = 0;
                    if (ckb_Premiere.Checked)
                    {
                        premiere = 1;
                    }
                    else if (ckb_Premiere.Checked == false)
                    {
                        premiere = 0;
                    }
                    if (ckb_Available.Checked)
                    {
                        available = 1;
                    }
                    else if (ckb_Available.Checked == false)
                    {
                        available = 0;
                    }
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = string.Format($"UPDATE movies SET Title = '{txt_Title.Text}', Director = '{txt_Director.Text}', Actors = '{txt_Actors.Text}', " +
                        $"Genre = '{txt_Genre.Text}', Premiere = '{premiere}', InStock = '{available}' WHERE MovieID = {selectedMovieID}");
                    comm.ExecuteNonQuery();
                    conn.Close();
                    ShowData();
                }
                catch (SqlException)
                {
                    MessageBox.Show("An error occurred when performing the query");
                    conn.Close();
                }

            }
        }

        private void clearData()
        {
            txt_Title.Text = "";
            txt_Director.Text = "";
            txt_Actors.Text = "";
            txt_Genre.Text = "";
            ckb_Premiere.Checked = false;
            ckb_Available.Checked = false;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (btn_Insert.Text == "Insert")
            {
                clearData();
                btn_Insert.Text = "Save";
                btn_Update.Enabled = false;
            }
            else if (btn_Insert.Text == "Save")
            {
                if (txt_Title.Text != "" && txt_Director.Text != "" && txt_Actors.Text != "" && txt_Genre.Text != "")
                {
                    int premiere = 0, available = 0;
                    if (ckb_Premiere.Checked)
                    {
                        premiere = 1;
                    }
                    else if (ckb_Premiere.Checked == false)
                    {
                        premiere = 0;
                    }
                    if (ckb_Available.Checked)
                    {
                        available = 1;
                    }
                    else if (ckb_Available.Checked == false)
                    {
                        available = 0;
                    }

                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = string.Format($"INSERT INTO movies VALUES ('{txt_Title.Text}', '{txt_Director.Text}', '{txt_Actors.Text}', " +
                        $"'{txt_Genre.Text}', '{premiere}', '{available}')");
                    comm.ExecuteNonQuery();
                    conn.Close();
                    ShowData();
                    btn_Insert.Text = "Insert";
                    btn_Update.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Fields cannot be blank.");
                    conn.Close();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clearData();
            btn_Insert.Text = "Insert";
            btn_Update.Enabled = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = String.Format($"DELETE FROM Movies WHERE MovieID = {selectedMovieID}");
                    comm.ExecuteNonQuery();
                    conn.Close();
                    ShowData();
                }
                catch (SqlException)
                {
                    MessageBox.Show("An error occurred when performing the query");
                    conn.Close();
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
