using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace school_management_system.DFOForms
{
    public partial class Illakaentry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public Illakaentry()
        {
            InitializeComponent();
        }

        private void Illakaentry_Load(object sender, EventArgs e)
        {
            AutocompleteVDC_MP();

        }
        private void AutocompleteVDC_MP()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();


                //string ct = "select distinct RTRIM(VDC_MP_Name) from tbl_VDV_MPInfo ";

                string ct = "select distinct  RTRIM( VDC_MP_Name ) from tbl_VDC_MPInfo ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbNameOfVDC_MP.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            txtArea.Text = "";
            txtLocation.Text = "";
            txtIllakaName.Text = "";
            txtNoOfVDC_MP. Text = "";
            cmbNameOfVDC_MP. Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtSiteName.Text = "";
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
        }
        private void func()
        {

            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='book Entry' and User_Registration.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {

                lbls.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lbls.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIllakaName. Text == "")
                {
                    MessageBox.Show("Please Enter Name Of ILLAKA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIllakaName.Focus();
                    return;
                }
                //if (txtArea.Text== "")
                //{
                //    MessageBox.Show("Please Enter Area", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtArea.Focus();
                //    return;
                //}
                //if (txtLocation.Text == "")
                //{
                //    MessageBox.Show("Please Enter Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtLocation.Focus();
                //    return;
                //}
                //if (txtNoOfCF.Text == "")
                //{
                //    MessageBox.Show("Please Enter C.F", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtNoOfCF.Focus();
                //    return;
                //}
                //if (txtNoOfLF.Text == "")
                //{
                //    MessageBox.Show("Please Enter LF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtNoOfLF.Focus();
                //    return;
                //}
                //if (txtNoOfRF.Text == "")
                //{
                //    MessageBox.Show("Please Enter RF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtNoOfRF.Focus();
                //    return;
                //}
                //if (txtNoOfPF.Text == "")
                //{
                //    MessageBox.Show("Please Enter PF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtNoOfPF.Focus();
                //    return;
                //}

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into tbl_IllakaInfo(IllakaName,Location,Area,NoOfVDC_MP,VDC_MP_Name,Latitude,Longitude,SiteName) VALUES (@IllakaName,@Location,@Area,@NoOfVDC_MP,@VDC_MP_Name,@Latitude,@Longitude,@SiteName)";

                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@IllakaName",txtIllakaName. Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@NoOfVDC_MP", txtNoOfVDC_MP.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbNameOfVDC_MP.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@SiteName", txtSiteName.Text);

                cmd.ExecuteNonQuery();

                st1 = lblUser.Text;
                st2 = "ILLAKA  is added  having Name='" + txtIllakaName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;


                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update tbl_IllakaInfo Set IllakaName=@IllakaName, Location=@Location,Area=@Area,NoOfVDC_MP=@NoOfVDC_MP,VDC_MP_Name=@VDC_MP_Name,Latitude=@Latitude,Longitude=@Longitude,SiteName=@SiteName where IId='" + txtID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@IllakaName",txtIllakaName. Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@NoOfVDC_MP",txtNoOfVDC_MP. Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbNameOfVDC_MP.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@SiteName",txtSiteName.Text);

                con = new SqlConnection(cs.DBcon);
                con.Open();

                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "ILLAKA Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the Illaka ='" +txtIllakaName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                btnUpdate_record.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
            txtIllakaName. Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_records();

        }
        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;
               
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from tbl_IllakaInfo where IId='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Illaka is deleted IllakaName='" + txtIllakaName.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //GetData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            ILLAKA_ViewRecords frm = new ILLAKA_ViewRecords();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            frm.set.Text = "ILLAKA View Records";
            frm.Show();
        }

        private void Illakaentry_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();

        }

    }
}
