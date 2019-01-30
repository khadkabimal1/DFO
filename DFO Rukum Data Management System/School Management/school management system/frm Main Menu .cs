using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using school_management_system.DFOForms;
namespace school_management_system
{
    public partial class frm_Main_Menu : Form
    {
        
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataReader rdr;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frm_Main_Menu()
        {
            InitializeComponent();
        }

         private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

         

        private void registrationToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmUserRegistrations frm = new frmUserRegistrations();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.Show();
        }

        private void loginDetailsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
       
            frmLoginDetails frm = new frmLoginDetails();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

       

        private void logsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
           
            frmlogs frm = new frmlogs();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

       

        private void logoutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            st1 = User.Text;
            st2 = "Successfully logged out";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
            frm.UserID.Text = "";
            frm.Password.Text = "";
            frm.ProgressBar1.Visible = false;
            frm.UserID.Focus();
        }

       

        private void databaseRecoveryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;
                _with1.Filter = ("DB Backup File|*.bak;");
                _with1.FilterIndex = 4;
                //Clear the file name
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    timer1.Enabled = true;
                    SqlConnection.ClearAllPools();
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string cb = "USE Master ALTER DATABASE [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] SET Single_User WITH Rollback Immediate Restore database [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] FROM disk='" + openFileDialog1.FileName + "' WITH REPLACE ALTER DATABASE [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] SET Multi_User ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    st1 = User.Text;
                    st2 = "Successfully restore the database";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void databaseBackupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BackupAndRestore frm = new BackupAndRestore();
            frm.Show();


            try
            {
            //    Cursor = Cursors.WaitCursor;
            //    timer1.Enabled = true;
            //    if ((!System.IO.Directory.Exists("C:\\DBBackup")))
            //    {
            //        System.IO.Directory.CreateDirectory("C:\\DBBackup");
            //    }
            //    string destdir = "C:\\DBBackup\\ERPS_DB " + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".bak";
            //    con = new SqlConnection(cs.DBcon);
            //    con.Open();
            //    string cb = "backup database [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_DB.mdf] to disk='" + destdir + "'with init,stats=10";
            //    cmd = new SqlCommand(cb);
            //    cmd.Connection = con;
            //    //cmd.ExecuteReader();
            //    con.Close();
            //    st1 = User.Text;
            //    st2 = "Successfully backup the database";
            //    cf.LogFunc(st1, System.DateTime.Now, st2);
            //    MessageBox.Show("Successfully performed", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void calculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void taskManagerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void wordpadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        
  
     

       private void menuStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            st1 = User.Text;
            st2 = "Successfully logged out";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
            frm.UserID.Text = "";
            frm.Password.Text = "";
            frm.ProgressBar1.Visible = false;
            frm.UserID.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           // toolStripStatusLabel4.Text = System.DateTime.Now.ToString();
            Time.Text = DateTime.Now.ToString();
            timer2.Start();
        }

       

        private void logsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmlogs frm = new frmlogs();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.Show();
       
        }

       
        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUserRegistrations frm = new frmUserRegistrations();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.Show();
        }

       

        

        private void databaseBackupToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                BackupAndRestore frm = new BackupAndRestore();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void databaseRecoveryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;
                _with1.Filter = ("DB Backup File|*.bak;");
                _with1.FilterIndex = 4;
                //Clear the file name
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    timer1.Enabled = true;
                    SqlConnection.ClearAllPools();
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string cb = "USE Master ALTER DATABASE [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] SET Single_User WITH Rollback Immediate Restore database [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] FROM disk='" + openFileDialog1.FileName + "' WITH REPLACE ALTER DATABASE [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] SET Multi_User ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    st1 = User.Text;
                    st2 = "Successfully restore the database";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
             st1 = User.Text;
             st2 = "Successfully logged out";
             cf.LogFunc(st1, System.DateTime.Now, st2);
             this.Hide();
             frmLogin frm = new frmLogin();
             frm.Show();
             frm.UserID.Text = "";
             frm.Password.Text = "";
             frm.ProgressBar1.Visible = false;
             frm.cmbUsertype.Focus();
        
        }

        private void frm_Main_Menu_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();


           // //student entry
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Student Entry' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lblview6.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lblview6.Text == "True")
           // {
           //     studentToolStripMenuItem3.Enabled = true;
           // }
            
           // else
           // {
           //     studentToolStripMenuItem3.Enabled = true;
           // }
           
           // if (frm.lblview6.Text == "True")
           //   //  studentToolStripMenuItem2.Enabled = true;
     
           //// else
           //    // studentToolStripMenuItem2.Enabled = true;


           // //Employee entry
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Employee Entry' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lblview7.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lblview7.Text == "True")
           // {
           //     profileEntryToolStripMenuItem.Enabled = true;
           // }

           // else
           // {
           //     profileEntryToolStripMenuItem.Enabled = false;
           // }

           // if (frm.lblview7.Text == "True")
           //     employeeToolStripMenuItem3.Enabled = true;

           // else
           //     employeeToolStripMenuItem3.Enabled = false;


           // //Employee entry
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Help and About' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lblview8.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lblview8.Text == "True")
           // {
           //     toolStripMenuItem9.Enabled = true;
           // }

           // else
           // {
           //     toolStripMenuItem9.Enabled = true;
           // }

           // if (frm.lblview8.Text == "True")
           //     toolStripMenuItem10.Enabled = true;

           // else
           //     toolStripMenuItem10.Enabled = true;
           // if (frm.lblview8.Text == "True")
           //     helpToolStripMenuItem1.Enabled = true;

           // else
           //     helpToolStripMenuItem1.Enabled = true;

           // //student record
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Student Records' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //    frm.lb1.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb1.Text == "True")
           // {
           //     //studentsToolStripMenuItem1.Enabled = true;
           // }
           // else
           //     // studentsToolStripMenuItem1.Enabled = true;

           //     //Hostellers
           //     con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Hostelers Records' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb2.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb2.Text == "True")
           // {
           //    // hostelersToolStripMenuItem3.Enabled = true;
           // }
           // else
           //     //hostelersToolStripMenuItem3.Enabled = true;


           // //Bus holder
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Bus Holders Records' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb3.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           
           // //Employees record
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Employee Records' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb4.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb4.Text == "True")
           // {
           //     //employeesToolStripMenuItem.Enabled = true;
           // }
           // else
           //     //employeesToolStripMenuItem.Enabled = true;

           // //salary payment
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='salary Payment Records' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb7.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb7.Text == "True")
           //     toolStripMenuItem6.Enabled = true;
           // else
           //     toolStripMenuItem6.Enabled = true;

           // //class Fee Payment
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='class Fee payment Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb6.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb6.Text == "True")
           //     claToolStripMenuItem.Enabled = true;
           // else
           //     claToolStripMenuItem.Enabled = true;

           // //bus Fee Payment
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='bus Fee payment Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb8.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb8.Text == "True")
           //     busFeePaymentToolStripMenuItem5.Enabled = true;
           // else
           //     busFeePaymentToolStripMenuItem5.Enabled = true;



           // //scholarship Fee Payment
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Scholarship payment Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb17.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb17.Text == "True")
           //     scholarshipPaymentToolStripMenuItem3.Enabled = true;
           // else
           //     scholarshipPaymentToolStripMenuItem3.Enabled = true;



           // //hostel Fee Payment
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='hostel Fee payment Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb9.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb9.Text == "True")
           //     hostelFeePaymentToolStripMenuItem4.Enabled = true;
           // else
           //     hostelFeePaymentToolStripMenuItem4.Enabled = true;



           // //books
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Books Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb10.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb10.Text == "True")
           //     BookstoolStripMenuItem6.Enabled = true;
           // else
           //     BookstoolStripMenuItem6.Enabled = true;



           // //student book issue 
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Student Books issue Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb11.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb11.Text == "True")
           //     bookIssueStudentToolStripMenuItem.Enabled = true;
           // else
           //     bookIssueStudentToolStripMenuItem.Enabled = true;

           // //staff book issue 
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Staff Books issue Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb12.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb12.Text == "True")
           //     bookIssueStaffToolStripMenuItem.Enabled = true;
           // else
           //     bookIssueStaffToolStripMenuItem.Enabled = true;


           // //student book Return
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Book Return Student' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb13.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb13.Text == "True")
           //     bookReturnStudentToolStripMenuItem.Enabled = true;
           // else
           //     bookReturnStudentToolStripMenuItem.Enabled = true;

           // //staff book return 
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Book Return Staff' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb14.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb14.Text == "True")
           //     bookReturnToolStripMenuItem1.Enabled = true;
           // else
           //     bookReturnToolStripMenuItem1.Enabled = true;


           // //subject 
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Subject Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb15.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb15.Text == "True")
           //     subjectRecordsToolStripMenuItem.Enabled = true;
           // else
           //     subjectRecordsToolStripMenuItem.Enabled = true;

           // //marks 
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='marks Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb16.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb16.Text == "True")
           //     marksRecordToolStripMenuItem.Enabled = true;
           // else
           //     marksRecordToolStripMenuItem.Enabled = true;


           // //event
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Events Record' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lb18.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lb18.Text == "True")
           //     eventRecordsToolStripMenuItem1.Enabled = true;
           // else
           //     eventRecordsToolStripMenuItem1.Enabled = true;


           // //  Bus Holders Report

           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Bus Holders Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R1.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R1.Text == "True")
           //     busHoldersToolStripMenuItem4.Enabled = true;
           // else
           //     busHoldersToolStripMenuItem4.Enabled = true;


           // //Hostelers Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Hostelers Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R2.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R1.Text == "True")
           //     hostelersToolStripMenuItem4.Enabled = true;
           // else
           //     hostelersToolStripMenuItem4.Enabled = true;

           // //Class Fee Payment Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Class Fee Payment Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R3.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R3.Text == "True")
           //     classFeePaymentToolStripMenuItem.Enabled = true;
           // else
           //     classFeePaymentToolStripMenuItem.Enabled = true;


           // //salary Payment Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='salary Payment Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R4.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R4.Text == "True")
           //     salaryPaymentToolStripMenuItem3.Enabled = true;
           // else
           //     salaryPaymentToolStripMenuItem3.Enabled = true;


           // //Bus Fee Payment Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Bus Fee Payment Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R5.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R5.Text == "True")
           //     busFeePaymentReportToolStripMenuItem.Enabled = true;
           // else
           //     busFeePaymentReportToolStripMenuItem.Enabled = true;

           // //Hostel Fee Payment Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Hostel Fee Payment Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R6.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R6.Text == "True")
           //     toolStripMenuItem7.Enabled = true;
           // else
           //     toolStripMenuItem7.Enabled = true;

           // //Scholarship Payment Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Scholarship Payment Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R7.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R7.Text == "True")
           //     toolStripMenuItem8.Enabled = true;
           // else
           //     toolStripMenuItem8.Enabled = true;

           // //Student Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Student Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R8.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R8.Text == "True")
           //     studentReportToolStripMenuItem.Enabled = true;
           // else
           //     studentReportToolStripMenuItem.Enabled = true;
           // //Employee Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Employee Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R9.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R9.Text == "True")
           //     employeeReportToolStripMenuItem.Enabled = true;
           // else
           //     employeeReportToolStripMenuItem.Enabled = true;


           // //Student marks Report
           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Student marks Report' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.R10.Text = rdr[0].ToString().Trim();

           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.R10.Text == "True")
           //     studentMarksReportToolStripMenuItem.Enabled = true;
           // else
           //     studentMarksReportToolStripMenuItem.Enabled = true;

           // //all master entry  
            
  

           // con = new SqlConnection(cs.DBcon);

           // con.Open();
           // cmd = con.CreateCommand();

           // cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='All Master Entry' and User_Registration.UserID='" + User.Text + "' ";
           // rdr = cmd.ExecuteReader();

           // if (rdr.Read())
           // {
           //     frm.lblView.Text = rdr[0].ToString().Trim();
         
           // }
           // if ((rdr != null))
           // {
           //     rdr.Close();
           // }
           // if (con.State == ConnectionState.Open)
           // {
           //     con.Close();
           // }

           // if (frm.lblView.Text == "True")
           //     masterEntryToolStripMenuItem.Enabled = true;
           // else
           //     masterEntryToolStripMenuItem.Enabled = true;

//user settings

            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='User Setting' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.View1.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.View1.Text == "True")
                loginDetailsToolStripMenuItem1.Enabled = true;
            else
                loginDetailsToolStripMenuItem1.Enabled = true;

            if (frm.View1.Text == "True")
                logToolStripMenuItem.Enabled = true;
            else
                logToolStripMenuItem.Enabled = true;
//Records

            //con = new SqlConnection(cs.DBcon);

            //con.Open();
            //cmd = con.CreateCommand();

            //cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='All Records' and User_Registration.UserID='" + User.Text + "' ";
            //rdr = cmd.ExecuteReader();

            //if (rdr.Read())
            //{
            //    frm.View2.Text = rdr[0].ToString().Trim();

            //}
            //if ((rdr != null))
            //{
            //    rdr.Close();
            //}
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}

            //if (frm.View2.Text == "True")
            //    recordsToolStripMenuItem.Enabled = true;
            //else
            //    recordsToolStripMenuItem.Enabled = true;

//reports
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='All Reports' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
               frm.View3.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.View3.Text == "True")
                reportsToolStripMenuItem.Enabled = true;
            else
                reportsToolStripMenuItem.Enabled = true;

//Backup and Recovery

            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Backup & Recovery' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.view4.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.view4.Text == "True")
                databaseBackupToolStripMenuItem1.Enabled = true;
            else
                databaseBackupToolStripMenuItem1.Enabled = true;


            if (frm.view4.Text == "True")
                databaseRecoveryToolStripMenuItem1.Enabled = true;
            else
                databaseRecoveryToolStripMenuItem1.Enabled = true;


            if (frm.view4.Text == "True")
                databaseBackupToolStripMenuItem2.Enabled = true;
            else
                databaseBackupToolStripMenuItem2.Enabled = true;


            if (frm.view4.Text == "True")
                databaseRecoveryToolStripMenuItem2.Enabled = true;
            else
                databaseRecoveryToolStripMenuItem2.Enabled = true;

// transactions

            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='All Transactions' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.view6.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.view6.Text == "True")
                //transactionToolStripMenuItem1.Enabled = true;
            //else
               // transactionToolStripMenuItem1.Enabled = true;


            if (frm.view6.Text == "True")
                salaryPaymentToolStripMenuItem2.Enabled = true;
            else
                salaryPaymentToolStripMenuItem2.Enabled = true;


            if (frm.view6.Text == "True")
                feePaymentToolStripMenuItem3.Enabled = true;
            else
                feePaymentToolStripMenuItem3.Enabled = true;


            if (frm.view6.Text == "True")
                hostelFeePaymentToolStripMenuItem5.Enabled = true;
            else
                hostelFeePaymentToolStripMenuItem5.Enabled = true;
           
            
            if (frm.view6.Text == "True")
                busFeePaymentToolStripMenuItem3.Enabled = true;
            else
                busFeePaymentToolStripMenuItem3.Enabled = true;

            if (frm.view6.Text == "True")
                scholarshipPaymentToolStripMenuItem4.Enabled = true;
            else
                scholarshipPaymentToolStripMenuItem4.Enabled = true;
//logs

            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Logs' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.view7.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.view7.Text == "True")
                logsToolStripMenuItem2.Enabled = true;
            else
                logsToolStripMenuItem2.Enabled = true;


            if (frm.view7.Text == "True")
                logsToolStripMenuItem3.Enabled = true;
            else
                logsToolStripMenuItem3.Enabled = true;


        }

       

     
       

        
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           Contact_Me frm = new Contact_Me();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
         
            Contact_Me frm = new Contact_Me();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

      
      

        private void logsToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            frmlogs frm = new frmlogs();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void userGrants_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUserGrants frm = new frmUserGrants();
            frm.lblUserType.Text = UserType.Text;
            frm.lblUser.Text = User.Text;
            frm.Show();
        }

       
        private void databaseBackUpAstorendRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BackupAndRestore frm = new BackupAndRestore();
            frm.Show();
        }

      

        private void fiscalYearEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory.FiscalYearEntry frm = new Inventory.FiscalYearEntry();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

      

        private void vDCMPEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.VDC_MunicipalityEntry frm = new DFOForms.VDC_MunicipalityEntry();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='VDC/MP Entry' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;
            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();

           }

        private void illakaEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.Illakaentry frm = new DFOForms.Illakaentry();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Illaka Entry' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;
            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void cpmmunityForestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.CommunityForest frm = new DFOForms.CommunityForest();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Community Forest Entry' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;
            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();

        }

        private void leisureForestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.LeisureForest frm = new DFOForms.LeisureForest();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Community Forest Entry' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;
            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void religiousForestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.ReligiousForest frm = new DFOForms.ReligiousForest();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Community Forest Entry' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;
            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void privateForestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.PrivateForest frm = new DFOForms.PrivateForest();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Community Forest Entry' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;
            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void districtInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.frmDistrict frm = new DFOForms.frmDistrict();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Community Forest Entry' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate. Enabled = true;
            else
                frm.btnUpdate.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void cFUserGroupConstitutionAndActionPlanDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.C frm = new DFOForms.C();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='C.F User Group Constitution and Action Plan Details' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;
              
            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFO_Crystal_reports.CFUsrGrpConstitutionActionPlanDetail_Report frm = new DFO_Crystal_reports.CFUsrGrpConstitutionActionPlanDetail_Report();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void समदयकबनउपभकतसमहकबधनसमवनदववरणToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.CF_Forest_UserGroup_Constitution_Details frm = new DFOForms.CF_Forest_UserGroup_Constitution_Details();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='C.F User Group Constitution  Details' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;

            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void ईलकबनकरयलयतथगबसअनसरसमदयकबनउपभकतसमहहरकववरणToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails frm = new DFOForms.IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;

            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void समदयकबनउपभकतसमहहरककरययजनसमबनधववरणToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOForms.CF_UsrGrp_ActionPlanDetails frm = new DFOForms.CF_UsrGrp_ActionPlanDetails();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(viewRecord)  from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='CFUsrGrp Action Plan Details' and User_Registration.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = true;

            if (frm.lblview.Text == "True")
                frm.btnUpdate_record.Enabled = true;

            else
                frm.btnUpdate_record.Enabled = true;
            this.Hide();
            frm.Show();
        }

        private void समदयकबनउपभकतसमहकबधनसमवनदववरणToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOCrystaRreports.CF_UsrGrp_ActPlnDtlsCrystalReports frm= new DFOCrystaRreports.CF_UsrGrp_ActPlnDtlsCrystalReports();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void ईलकबनकरयलयतथगबसअनसरसमदयकबनउपभकतसमहहरकववरणToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOCrystaRreports.IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetailCrystalReport frm = new DFOCrystaRreports.IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetailCrystalReport();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void समदयकबनउपभकतसमहहरककरययजनसमबनधववरणToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DFOCrystaRreports.CF_UsrGrp_APDtlReport frm = new DFOCrystaRreports.CF_UsrGrp_APDtlReport();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChangePasswords frm = new frmChangePasswords();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();

        }

        private void passwordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPasswordRecovery frm = new frmPasswordRecovery();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

       
     
        }
        }
    
        
    

