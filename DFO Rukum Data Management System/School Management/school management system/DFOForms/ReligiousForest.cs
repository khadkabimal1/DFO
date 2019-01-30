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
    public partial class ReligiousForest : Form
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
        public ReligiousForest()
        {
            InitializeComponent();
        }

       
        private void ReligiousForest_Load(object sender, EventArgs e)
        {
            AutocompleteReligiousForest();
        }

        private void AutocompleteReligiousForest()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRFName.Text == "")
                {
                    MessageBox.Show("Please Enter Name Of Religious Forest", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRFName.Focus();
                    return;
                }



                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into tbl_ReligiousForestInfo(ReligiousForestName,VDC_MP_Name,Location,Area,SiteName,Latitude,Longitude,Map) VALUES (@ReligiousForestName,@VDC_MP_Name,@Location,@Area,@SiteName,@Latitude,@Longitude,@Map)";

                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ReligiousForestName", txtRFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbNameOfVDC.Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@SiteName", txtSiteName.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                MemoryStream ms = new MemoryStream();
                if (pbMapOfCF.Image != null)
                {
                    pbMapOfCF.Image.Save(ms, pbMapOfCF.Image.RawFormat);
                    byte[] img = ms.GetBuffer();
                    ms.Close();
                    cmd.Parameters.AddWithValue("@Map", img);
                }
                else
                    cmd.Parameters.AddWithValue("@Map", new byte[0]);

                cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();

                st1 = lblUser.Text;
                st2 = "Religious Forest is added  having Name='" + txtRFName.Text + "'";
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

        private void btnChooseMapToUpload_Click(object sender, EventArgs e)
        {
             try
            {
                var _with1 = OpenFileDialog1;

                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;
                //Reset the file name
                OpenFileDialog1.FileName = "";

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pbMapOfCF.Image = Image.FromFile(OpenFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         private void func()
        {

            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Religious Forest Entry' and User_Registration.UserID='" + lblUser.Text + "' ";
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
            txtRFName.Text = "";
            txtSiteName.Text = "";
            cmbNameOfVDC.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            pbMapOfCF.Image = Properties.Resources.background__2__fw;
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
              Reset();
             txtRFName.Enabled = true;
             btnSave.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
             pbMapOfCF. Image = null;
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
         try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update tbl_ReligiousForestInfo Set ReligiousForestName=@ReligiousForestName,VDC_MP_Name=@VDC_MP_Name, Location=@Location,Area=@Area,SiteName=@SiteName,Latitude=@Latitude,Longitude=@Longitude,Map=@Map where RFId='" + txtID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ReligiousForestName",txtRFName. Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name",cmbNameOfVDC. Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@SiteName",txtSiteName. Text);
                
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);

                MemoryStream ms = new MemoryStream();
                if (pbMapOfCF.Image != null)
                {
                    pbMapOfCF.Image.Save(ms, pbMapOfCF.Image.RawFormat);
                    byte[] img = ms.GetBuffer();
                    ms.Close();
                    cmd.Parameters.AddWithValue("@Map", img);
                }
                else
                    cmd.Parameters.AddWithValue("@Map", new byte[0]);

                con = new SqlConnection(cs.DBcon);
                con.Open();

                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "Religious Forest Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the Community Forest ='" + txtRFName. Text + "'";
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
            RFRecords frm = new RFRecords();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            //frm.set.Text = "Community Forest View Records";
            frm.Show();
        }

        private void ReligiousForest_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }
        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from tbl_ReligiousForestInfo where RFId='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Religious Forest is deleted ReligiousForestInfo='" + txtRFName.Text + "'";
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
    }
}
