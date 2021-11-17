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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ZCM-233204433\SQLEXPRESS;Initial Catalog=movie_rental_wfa;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieMaint movieMaint = new MovieMaint();
            movieMaint.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMaint userMaint = new UserMaint();
            userMaint.ShowDialog();
        }

        private void rentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalMaint rentalMaint = new RentalMaint();
            rentalMaint.ShowDialog();
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieSearch movieSearch = new MovieSearch();
            movieSearch.ShowDialog();
        }

        private void directorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectorSearch directorSearch = new DirectorSearch();
            directorSearch.ShowDialog();
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenreSearch genreSearch = new GenreSearch();
            genreSearch.ShowDialog();
        }

        private void listOfUsersToolStripMenuItem_Click(object sender, EventArgs e)
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
                dgv_Reports.DataSource = table;
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred when performing the query");
                conn.Close();
            }
        }

        private void listOfMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = "SELECT * FROM Movies";
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = queryStr;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_Reports.DataSource = table;
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred when performing the query");
                conn.Close();
            }
        }

        private void allAvailableMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = "SELECT * FROM Movies WHERE InStock = 1";
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = queryStr;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_Reports.DataSource = table;
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred when performing the query");
                conn.Close();
            }
        }

        private void allRentedMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = "SELECT RentalID, Title, FirstName + ' ' + LastName AS Renter, DateOUT, DateIN, InStock FROM Rentals " +
                    "INNER JOIN Movies ON Movies.MovieID = Rentals.MovieID INNER JOIN Users ON Users.UserID = Rentals.UserID WHERE InStock = 0";
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = queryStr;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_Reports.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when performing the query");
                conn.Close();
            }
        }
    }
}
