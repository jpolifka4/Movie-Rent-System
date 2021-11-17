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
    public partial class UserMaint : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ZCM-233204433\SQLEXPRESS;Initial Catalog=movie_rental_wfa;Integrated Security=True");
        int selectedUserID;

        public UserMaint()
        {
            InitializeComponent();
        }

        private void ShowData()
        {
            try
            {
                string queryStr = "SELECT * FROM Users";
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
            selectedUserID = Convert.ToInt16(dgv_MovieData.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_FName.Text = dgv_MovieData.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_LName.Text = dgv_MovieData.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Address.Text = dgv_MovieData.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Phone.Text = dgv_MovieData.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_Email.Text = dgv_MovieData.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_Zip.Text = dgv_MovieData.Rows[e.RowIndex].Cells[6].Value.ToString();
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
                    try
                    {
                        Convert.ToInt64(txt_Phone.Text);
                        Convert.ToInt32(txt_Zip.Text);

                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();
                        comm.CommandText = string.Format($"UPDATE Users SET FirstName = '{txt_FName.Text}', LastName = '{txt_LName.Text}', Address = '{txt_Address.Text}', " +
                            $"PhoneNumber = '{txt_Phone.Text}', Email = '{txt_Email.Text}', ZipCode = '{txt_Zip.Text}' WHERE UserID = {selectedUserID}");
                        comm.ExecuteNonQuery();
                        conn.Close();
                        ShowData();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Phone number and Zip code must be numbers.");
                        conn.Close();
                    }
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
            txt_FName.Text = "";
            txt_LName.Text = "";
            txt_Address.Text = "";
            txt_Phone.Text = "";
            txt_Email.Text = "";
            txt_Zip.Text = "";
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
                if (txt_FName.Text != "" && txt_LName.Text != "" && txt_Address.Text != "" && txt_Phone.Text != "" && txt_Email.Text != "" && txt_Zip.Text != "")
                {
                    try
                    {
                        Convert.ToInt64(txt_Phone.Text);
                        Convert.ToInt32(txt_Zip.Text);

                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();
                        comm.CommandText = string.Format($"INSERT INTO Users VALUES ('{txt_FName.Text}', '{txt_LName.Text}', '{txt_Address.Text}', " +
                            $"'{txt_Phone.Text}', '{txt_Email.Text}', '{txt_Zip.Text}')");
                        comm.ExecuteNonQuery();
                        conn.Close();
                        ShowData();
                        btn_Insert.Text = "Insert";
                        btn_Update.Enabled = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Phone number and Zip code must be numbers.");
                        conn.Close();
                    }
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
                    comm.CommandText = String.Format($"DELETE FROM Users WHERE UserID = {selectedUserID}");
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
