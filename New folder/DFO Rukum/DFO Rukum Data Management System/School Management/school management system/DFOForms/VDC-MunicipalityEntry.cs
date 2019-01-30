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
    public partial class VDC_MunicipalityEntry : Form
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
        public VDC_MunicipalityEntry()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void Reset()
        {
            txtArea.Text = "";
            txtLocation.Text = "";
            txtNameOfVDCMunicipality.Text = "";
            txtNoOfCF.Text = "";
            txtNoOfLF.Text = "";
            txtNoOfPF.Text = "";
            txtNoOfRF.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtWardNo.Text = "";

            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
        }
        private void VDC_MunicipalityEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            VDC_MP_ViewRecords frm = new VDC_MP_ViewRecords();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            frm.set.Text = "VDC/MP View Records";
            frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
              try
                {
                    if ( txtNameOfVDCMunicipality.Text == "")
                    {
                        MessageBox.Show("Please Enter Name Of VDC/Municipality", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNameOfVDCMunicipality.Focus();
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

                string cb = "insert into tbl_VDC_MPInfo(VDC_MP_Name,Location,Area,NoOfCF,NoOfLF,NoOfRF,NoOfPF,Latitude,Longitude,WardNo) VALUES (@VDC_MP_Name,@Location,@Area,@NoOfCF,@NoOfLF,@NoOfRF,@NoOfPF,@Latitude,@Longitude,@WardNo)";

                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@VDC_MP_Name", txtNameOfVDCMunicipality.Text);
                cmd.Parameters.AddWithValue("@Location",txtLocation.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@NoOfCF", txtNoOfCF.Text);
                cmd.Parameters.AddWithValue("@NoOfLF", txtNoOfLF.Text);
                cmd.Parameters.AddWithValue("@NoOfRF", txtNoOfRF.Text);
                cmd.Parameters.AddWithValue("@NoOfPF",txtNoOfPF.Text);
                cmd.Parameters.AddWithValue("@Latitude",txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@WardNo", txtWardNo.Text);
                 
                cmd.ExecuteNonQuery();

                st1 = lblUser.Text;
                st2 = "VDC/MP  is added  having Name='" + txtNameOfVDCMunicipality.Text + "'";
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
                //con = new SqlConnection(cs.DBcon);

                //con.Open();
                //string ct = "select VDCId from tbl_IllakaInfo where VDCId=@find";


                //cmd = new SqlCommand(ct);

                //cmd.Connection = con;
                //cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 100, "VDCId"));


                //cmd.Parameters["@find"].Value = txtID. Text;


                //rdr = cmd.ExecuteReader();

                //if (rdr.Read())
                //{
                //    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Reset();
                //    if ((rdr != null))
                //    {
                //        rdr.Close();
                //    }
                //    return;
                //}

               
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from tbl_VDC_MPInfo where VDCId='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "VDC/MPNAME is deleted VDC_MP_Name='" + txtNameOfVDCMunicipality.Text + "'";
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
                string cb = "Update tbl_VDC_MPInfo Set VDC_MP_Name=@VDC_MP_Name, Location=@Location,Area=@Area,NoOfCF=@NoOfCF,NoOfLF=@NoOfLF,NoOfRF=@NoOfRF,NoOfPF=@NoOfPF,Latitude=@Latitude,Longitude=@Longitude,WardNo=@WardNo where VDCId='" + txtID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@VDC_MP_Name",txtNameOfVDCMunicipality.Text);
                cmd.Parameters.AddWithValue("@Location",txtLocation.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@NoOfCF", txtNoOfCF.Text);
                cmd.Parameters.AddWithValue("@NoOfLF", txtNoOfLF.Text);
                cmd.Parameters.AddWithValue("@NoOfRF", txtNoOfRF.Text);
                cmd.Parameters.AddWithValue("@NoOfPF", txtNoOfPF.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@WardNo", txtWardNo.Text);

                con = new SqlConnection(cs.DBcon);
                con.Open();

                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "VDC/MP Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the VDC/MP ='" + txtNameOfVDCMunicipality.Text + "'";
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
           txtNameOfVDCMunicipality.Enabled = true;
        }

        private void VDC_MunicipalityEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
