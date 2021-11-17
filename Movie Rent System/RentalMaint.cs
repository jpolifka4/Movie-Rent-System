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
    public partial class RentalMaint : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ZCM-233204433\SQLEXPRESS;Initial Catalog=movie_rental_wfa;Integrated Security=True");
        int selectedRentalID;

        public RentalMaint()
        {
            InitializeComponent();
        }

        private void ShowData()
        {
            try
            {
                string queryStr = "SELECT RentalID, Title, (FirstName + ' ' + LastName) AS FullName, DateOUT, DateIN, Price FROM Rentals " +
                    "INNER JOIN Movies ON Movies.MovieID = Rentals.MovieID INNER JOIN Users ON Users.UserID = Rentals.UserID";
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = queryStr;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_MovieData.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void clearData()
        {
            cmb_Title.SelectedIndex = -1;
            cmb_Name.SelectedIndex = -1;
            dtp_dateOUT.Value = DateTime.Now;
            dtp_dateIN.Value = DateTime.Now;
            txt_Price.Text = "";
        }

        private void MovieMaint_Load(object sender, EventArgs e)
        {
            ShowData();
            getIDs();
        }

        private DataTable getTitles()
        {
            DataTable table = null;
            try
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Movies";
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                table = new DataTable();
                adapter.Fill(table);
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred when performing the query");
                conn.Close();
            }
            return table;
        }

        private DataTable getUsers()
        {
            DataTable table = null;
            try
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT UserID, (FirstName + ' ' + LastName) AS FullName FROM USers";
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                table = new DataTable();
                adapter.Fill(table);
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred when performing the query");
                conn.Close();
            }
            return table;
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
                if (cmb_Title.SelectedIndex != -1 && cmb_Name.SelectedIndex != -1 && txt_Price.Text != "")
                {
                    try
                    {
                        Convert.ToInt32(txt_Price.Text);

                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();
                        comm.CommandText = string.Format($"INSERT INTO Rentals VALUES ('{cmb_Name.SelectedValue.ToString()}', '{cmb_Title.SelectedValue.ToString()}', " +
                            $"'{dtp_dateOUT.Value.ToString()}', '{dtp_dateIN.Value.ToString()}', '{txt_Price.Text}')");
                        comm.ExecuteNonQuery();
                        conn.Close();
                        ShowData();
                        btn_Insert.Text = "Insert";
                        btn_Update.Enabled = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Price must be a number.");
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to save changes to this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    try
                    {
                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();
                        comm.CommandText = string.Format($"UPDATE Rentals SET UserID = '{cmb_Name.SelectedValue.ToString()}', MovieID = '{cmb_Title.SelectedValue.ToString()}', " +
                            $"DateOUT = '{dtp_dateOUT.Value.ToString()}', DateIN = '{dtp_dateIN.Value.ToString()}', Price = '{txt_Price.Text}' WHERE RentalID = {selectedRentalID}");
                        comm.ExecuteNonQuery();
                        conn.Close();
                        ShowData();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Price must be a number.");
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = String.Format($"DELETE FROM Rentals WHERE RentalID = {selectedRentalID}");
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

        private void getIDs()
        {
            cmb_Title.DataSource = getTitles();
            cmb_Title.DisplayMember = "Title";
            cmb_Title.ValueMember = "MovieID";
            cmb_Name.DataSource = getUsers();
            cmb_Name.DisplayMember = "FullName";
            cmb_Name.ValueMember = "UserID";
        }

        private void dgv_MovieData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedRentalID = Convert.ToInt16(dgv_MovieData.Rows[e.RowIndex].Cells[0].Value.ToString());
            cmb_Title.Text = dgv_MovieData.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmb_Name.Text = dgv_MovieData.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtp_dateOUT.Value = Convert.ToDateTime(dgv_MovieData.Rows[e.RowIndex].Cells[3].Value.ToString());
            dtp_dateIN.Value = Convert.ToDateTime(dgv_MovieData.Rows[e.RowIndex].Cells[4].Value.ToString());
            txt_Price.Text = dgv_MovieData.Rows[e.RowIndex].Cells[5].Value.ToString();
            btn_Insert.Text = "Insert";
            btn_Update.Enabled = true;
        }
    }
}
