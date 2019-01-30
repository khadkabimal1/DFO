using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace school_management_system.DFOForms
{
    public partial class PrivateForest : Form
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
        public PrivateForest()
        {
            InitializeComponent();
        }


        private void AutocompleteCommunityForest()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string ct = "select distinct  RTRIM( VDC_MP_Name +' '+  +' '+ WardNo) from tbl_VDC_MPInfo ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbNameOfVDC.Items.Add(rdr[0]);
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
            txtPFName.Enabled = true;
            btnSave.Enabled = true;
        }

        private void func()
        {

            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Private Forest Entry' and User_Registration.UserID='" + lblUser.Text + "' ";
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

        private void Reset()
        {
            txtArea.Text = "";
            txtPFName.Text = "";
            txtOwnerName.Text = "";
            cmbNameOfVDC.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtNepaliDate.Text = "";
            txtNameOfSpeciesandNo.Text = "";
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
        }

        private void PrivateForest_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }

        private void PrivateForest_Load(object sender, EventArgs e)
        {
            AutocompleteCommunityForest();
        }

     


        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtOwnerName.Text == "")
                {
                    MessageBox.Show("Please Enter Name Of Forest Owner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOwnerName.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into tbl_PrivateForestInfo(PrivateForestName,VDC_MP_Name,Area,Latitude,Longitude,Vegegations,RegnDateEng,OwnerName) VALUES (@PrivateForestName,@VDC_MP_Name,@Area,@Latitude,@Longitude,@Vegegations,@RegnDateEng,@OwnerName)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@PrivateForestName", txtPFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbNameOfVDC.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);                
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@Vegegations",txtNameOfSpeciesandNo.Text);
                cmd.Parameters.AddWithValue("@RegnDateEng", txtNepaliDate.Text);
                cmd.Parameters.AddWithValue("@OwnerName", txtOwnerName.Text);
                cmd.ExecuteReader();

                st1 = lblUser.Text;
                st2 = "Private Forest is added  having Name='" + txtPFName.Text + "'";
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

     

        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;
              
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from tbl_PrivateForestInfo where PFId='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Private Forest is deleted PrivateForestName='" + txtPFName.Text + "'";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_records();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update tbl_PrivateForestInfo Set PrivateForestName=@PrivateForestName,VDC_MP_Name=@VDC_MP_Name, Area=@Area,Latitude=@Latitude,Longitude=@Longitude,Vegegations=@Vegegations,RegnDateEng=@RegnDateEng,OwnerName=@OwnerName where PFId='" + txtID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@PrivateForestName", txtPFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbNameOfVDC.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@Vegegations",txtNameOfSpeciesandNo. Text);
                cmd.Parameters.AddWithValue("@RegnDateEng", txtNepaliDate.Text);
                cmd.Parameters.AddWithValue("@OwnerName", txtOwnerName.Text);

                con = new SqlConnection(cs.DBcon);
                con.Open();

                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "Community Forest Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the Community Forest ='" + txtPFName.Text + "'";
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

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrivateForestRecord frm = new PrivateForestRecord();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            //frm.set.Text = "Community Forest View Records";
            frm.Show();
        }

     
    }
}
