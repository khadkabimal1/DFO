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

namespace school_management_system.DFOForms
{
    public partial class BackupAndRestore : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader sdr;
        String sql = "";
        String ConnectionString = "";
        public BackupAndRestore()
        {
            //this.BackgroundImage = Properties.Resources.child_form_bg;
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionString = "Data Source =" + txtDataSource.Text + "; User Id=" + txtUserID.Text + "; Password=" + txtPassword.Text + "";
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                sql = "EXEC sp_databases";
                //sql = "SELECT * FROM sys.databases d WHERE d.databases_id>4";
                cmd = new SqlCommand(sql, conn);
                sdr = cmd.ExecuteReader();
                cmbDatabases.Items.Clear();
                while (sdr.Read())
                {
                    cmbDatabases.Items.Add(sdr[0].ToString());
                }
                sdr.Dispose();
                conn.Close();
                conn.Dispose();

                txtDataSource.Enabled = false;
                txtUserID.Enabled = false;
                txtPassword.Enabled = false;
                cmbDatabases.Enabled = true;
                BtnBackup.Enabled = true;
                btnRestore.Enabled = true;
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            txtDataSource.Enabled = true;
            txtUserID.Enabled = true;
            txtPassword.Enabled = true;
            cmbDatabases.Enabled = false;
            BtnBackup.Enabled = false;
            btnRestore.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        private void BackupAndRestore_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            cmbDatabases.Enabled = false;
            BtnBackup.Enabled = false;
            btnRestore.Enabled = false;
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                // we check whether the databases are existing or not.
                if (cmbDatabases.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Please Select A Database!");
                    //return from this function
                    return;
                }

                conn = new SqlConnection(ConnectionString);
                conn.Open();
                sql = "BACKUP DATABASE " + cmbDatabases.Text + " TO DISK = '" + txtBackupFileLoc.Text + "\\" + cmbDatabases.Text + "-" + DateTime.Now.Ticks.ToString() + ".bak'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Successfully Database Backup Completed.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackupFileLoc.Text = dlg.SelectedPath;
            }
        }

        private void btnDBFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(*.bak)|.bak|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRestoreFileLoc.Text = dlg.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDatabases.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Please Select a Database");
                    return;
                }
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                sql = "Alter Database " + cmbDatabases.Text + " Set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                sql += "Restore Database " + cmbDatabases.Text + " FROM Disk = '" + txtRestoreFileLoc.Text + "' WITH REPLACE;";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Successfully Restore Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void BackupAndRestore_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.Show();
        }
    }
}
