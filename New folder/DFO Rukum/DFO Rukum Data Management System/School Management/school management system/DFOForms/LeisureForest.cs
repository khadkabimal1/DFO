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
    public partial class LeisureForest : Form
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
        public LeisureForest()
        {
            InitializeComponent();
        }
        private void AutocompleteLeisureForest()
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
                if (txtLFName.Text == "")
                {
                    MessageBox.Show("Please Enter Name Of Leisure Forest", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLFName.Focus();
                    return;
                }
                if (cmbNameOfVDC.Text == "")
                {
                    MessageBox.Show("Please Enter Name Of Adress ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbNameOfVDC.Focus();
                    return;
                }



                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into tbl_LeisureForestInfo(LeisureForestName,VDC_MP_Name,HouseHoldNo,HandOverFY,Area,Poor,VeryPoor,MediumPoor,Remarks) VALUES (@LeisureForestName,@VDC_MP_Name,@Area,@HouseHoldNo,@HandOverFY,@Poor,@VeryPoor,@MediumPoor,@Remarks)";

                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@LeisureForestName", txtLFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbNameOfVDC.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@HouseHoldNo", txtHouseHold.Text);
                cmd.Parameters.AddWithValue("@HandOverFY", txtHandOverFY.Text);
                cmd.Parameters.AddWithValue("@Poor", txtpoor.Text);
                cmd.Parameters.AddWithValue("@VeryPoor", txtVeryPoor.Text);
                cmd.Parameters.AddWithValue("@MediumPoor", txtMediumPoor.Text);
                cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
               

                cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();

                st1 = lblUser.Text;
                st2 = "Community Forest is added  having Name='" + txtLFName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;


                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();
        }

        private void LeisureForest_Load(object sender, EventArgs e)
        {
            AutocompleteLeisureForest();
        }

      

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
            txtLFName.Enabled = true;
            btnSave.Enabled = true;
        }

        private void func()
        {

            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Leisure Forest Entry' and User_Registration.UserID='" + lblUser.Text + "' ";
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
            txtHouseHold.Text = "";
            txtLFName.Text = "";
            txtHandOverFY.Text = "";
            cmbNameOfVDC.Text = "";
            txtpoor.Text = "";
            txtVeryPoor.Text = "";
            txtMediumPoor.Text = "";
            txtRemarks.Text = "";
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
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
                string cq1 = "delete from tbl_LeisureForestInfo where LFId='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Leisure Forest is deleted CommunityForestName='" + txtLFName.Text + "'";
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

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update tbl_LeisureForestInfo Set LeisureForestName=@LeisureForestName,VDC_MP_Name=@VDC_MP_Name,Area=@Area, HouseHoldNo=@HouseHoldNo,HandOverFY=@HandOverFY,Poor=@Poor,VeryPoor=@VeryPoor,MediumPoor=@MediumPoor,Remarks=@Remarks where LFId='" + txtID.Text + "'";
               
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@LeisureForestName", txtLFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbNameOfVDC.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@HouseHoldNo", txtHouseHold.Text);
                cmd.Parameters.AddWithValue("@HandOverFY", txtHandOverFY.Text);
                cmd.Parameters.AddWithValue("@Poor", txtpoor.Text);
                cmd.Parameters.AddWithValue("@VeryPoor", txtVeryPoor.Text);
                cmd.Parameters.AddWithValue("@MediumPoor", txtMediumPoor.Text);
                cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                
                con = new SqlConnection(cs.DBcon);
                con.Open();

                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "Community Forest Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the Leisure Forest ='" + txtLFName.Text + "'";
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
            LFRecords frm = new LFRecords();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            //frm.set.Text = "Community Forest View Records";
            frm.Show();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }


        private void LeisureForest_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }

       
        }

}
