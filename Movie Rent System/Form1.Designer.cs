
namespace Movie_Rent_System
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allAvailableMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allRentedMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_Reports = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reports)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintenanceToolStripMenuItem,
            this.searchByToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moviesToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.rentalsToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // moviesToolStripMenuItem
            // 
            this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
            this.moviesToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.moviesToolStripMenuItem.Text = "Movies";
            this.moviesToolStripMenuItem.Click += new System.EventHandler(this.moviesToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // rentalsToolStripMenuItem
            // 
            this.rentalsToolStripMenuItem.Name = "rentalsToolStripMenuItem";
            this.rentalsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.rentalsToolStripMenuItem.Text = "Rentals";
            this.rentalsToolStripMenuItem.Click += new System.EventHandler(this.rentalsToolStripMenuItem_Click);
            // 
            // searchByToolStripMenuItem
            // 
            this.searchByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleToolStripMenuItem,
            this.directorToolStripMenuItem,
            this.genreToolStripMenuItem});
            this.searchByToolStripMenuItem.Name = "searchByToolStripMenuItem";
            this.searchByToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.searchByToolStripMenuItem.Text = "Search By";
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.titleToolStripMenuItem.Text = "Title";
            this.titleToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripMenuItem_Click);
            // 
            // directorToolStripMenuItem
            // 
            this.directorToolStripMenuItem.Name = "directorToolStripMenuItem";
            this.directorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.directorToolStripMenuItem.Text = "Director";
            this.directorToolStripMenuItem.Click += new System.EventHandler(this.directorToolStripMenuItem_Click);
            // 
            // genreToolStripMenuItem
            // 
            this.genreToolStripMenuItem.Name = "genreToolStripMenuItem";
            this.genreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.genreToolStripMenuItem.Text = "Genre";
            this.genreToolStripMenuItem.Click += new System.EventHandler(this.genreToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfUsersToolStripMenuItem,
            this.listOfMoviesToolStripMenuItem,
            this.allAvailableMoviesToolStripMenuItem,
            this.allRentedMoviesToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // listOfUsersToolStripMenuItem
            // 
            this.listOfUsersToolStripMenuItem.Name = "listOfUsersToolStripMenuItem";
            this.listOfUsersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listOfUsersToolStripMenuItem.Text = "List of Users";
            this.listOfUsersToolStripMenuItem.Click += new System.EventHandler(this.listOfUsersToolStripMenuItem_Click);
            // 
            // listOfMoviesToolStripMenuItem
            // 
            this.listOfMoviesToolStripMenuItem.Name = "listOfMoviesToolStripMenuItem";
            this.listOfMoviesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listOfMoviesToolStripMenuItem.Text = "List of Movies";
            this.listOfMoviesToolStripMenuItem.Click += new System.EventHandler(this.listOfMoviesToolStripMenuItem_Click);
            // 
            // allAvailableMoviesToolStripMenuItem
            // 
            this.allAvailableMoviesToolStripMenuItem.Name = "allAvailableMoviesToolStripMenuItem";
            this.allAvailableMoviesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allAvailableMoviesToolStripMenuItem.Text = "All Available Movies";
            this.allAvailableMoviesToolStripMenuItem.Click += new System.EventHandler(this.allAvailableMoviesToolStripMenuItem_Click);
            // 
            // allRentedMoviesToolStripMenuItem
            // 
            this.allRentedMoviesToolStripMenuItem.Name = "allRentedMoviesToolStripMenuItem";
            this.allRentedMoviesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allRentedMoviesToolStripMenuItem.Text = "All Rented Movies";
            this.allRentedMoviesToolStripMenuItem.Click += new System.EventHandler(this.allRentedMoviesToolStripMenuItem_Click);
            // 
            // dgv_Reports
            // 
            this.dgv_Reports.AllowUserToAddRows = false;
            this.dgv_Reports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reports.Location = new System.Drawing.Point(44, 48);
            this.dgv_Reports.Name = "dgv_Reports";
            this.dgv_Reports.ReadOnly = true;
            this.dgv_Reports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Reports.Size = new System.Drawing.Size(743, 426);
            this.dgv_Reports.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 505);
            this.Controls.Add(this.dgv_Reports);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rentalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfMoviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allAvailableMoviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allRentedMoviesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_Reports;
    }
}

