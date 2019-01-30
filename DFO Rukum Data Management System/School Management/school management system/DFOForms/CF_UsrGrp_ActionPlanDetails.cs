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
    public partial class CF_UsrGrp_ActionPlanDetails : Form
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
        public CF_UsrGrp_ActionPlanDetails()
        {
            InitializeComponent();
        }

        private void CF_UsrGrp_ActionPlanDetails_Load(object sender, EventArgs e)
        {
            FiscalYearName();
            AutocompleteCommunityForest();
            AutocompleteVDCMPName();
            AutocompleteIllakaName();
            

        }

        private void func()
        {
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='CF Usr Grp Action Plan Details' and User_Registration.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {

                lblsave.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblsave.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;

        }

        private void Reset()
        {
            txtID.Text = "";
            
            txtArea.Text = "";
            txtkhandacount.Text = "";
            txtCodeNo.Text = "";
            txtFileNo.Text = "";
            txtkhandacount.Text = "";
            txtfiscalYearName.Text = "";
            txtHouseHold.Text = "";
            txtLatRenewDate.Text = "";
            txtPresentFiscalYearEng.Text = "";
            txtPresentFiscalYearNepali.Text = "";
            rchtxtSpecies.Text = "";
            cmbCFName.Text = "";
            cmbIllakaName.Text = "";
            cmbVDC_MP.Text = "";

        }

        private void AutocompleteIllakaName()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string ct = "select distinct  RTRIM( IllakaName) from tbl_IllakaInfo";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbIllakaName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiscalYearName()
        {

            con = new SqlConnection(cs.DBcon);
            con.Open();

            string ct = "select distinct  RTRIM( fiscal_name) from tbl_FiscalYear  where isActive='" + true + "' ";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txtfiscalYearName.Text = rdr.GetValue(0).ToString();
            }

            con = new SqlConnection(cs.DBcon);
            con.Open();

            string ct1 = "select distinct  RTRIM( startdate_eng) from tbl_FiscalYear  where isActive='" + true + "' ";
            cmd = new SqlCommand(ct1);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txtPresentFiscalYearEng.Text = rdr.GetValue(0).ToString();
            }

            con = new SqlConnection(cs.DBcon);
            con.Open();

            string ct2 = "select distinct  RTRIM( startdate_nep) from tbl_FiscalYear  where isActive='" + true + "' ";
            cmd = new SqlCommand(ct2);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txtPresentFiscalYearNepali.Text = rdr.GetValue(0).ToString();
            }
        }

        private void AutocompleteVDCMPName()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string ct = "select distinct  RTRIM( VDC_MP_Name) from tbl_CommunityForestInfo  ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbVDC_MP.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AutocompleteCommunityForest()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string ct = "select distinct  RTRIM( CommunityForestName) from tbl_CommunityForestInfo ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCFName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CF_UsrGrp_ActionPlanDetails_FormClosing(object sender, FormClosingEventArgs e)
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
                string cq1 = "delete from tbl_CFUsrGrp_ActionPlan_Details where CFUGACDtls='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Community Forest UsrGrp Action Plan Details is deleted FileNo='" + txtFileNo.Text + "'";
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

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtFileNo.Text == "")
                {
                    MessageBox.Show("Please Enter File No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFileNo.Focus();
                    return;
                }
                if (cmbCFName.Text == "")
                {
                    MessageBox.Show("Please select CF Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbCFName.Focus();
                    return;
                }
                if (cmbVDC_MP.Text == null)
                {
                    MessageBox.Show("Please enter VDC/MP Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbVDC_MP.Focus();
                    return;
                }

                if (cmbIllakaName.Text == null)
                {
                    MessageBox.Show("Please enter Illaka Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbIllakaName.Focus();
                    return;
                }

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into tbl_CFUsrGrp_ActionPlan_Details ( FileNo,IllakaName,CFName,VDC_MP_Name,HouldHold,Area,KhandaCount,LastRenewDate,CFCodeNo,MainSpecies,PresentFYEng,PresentFYNep,PresentFYName) VALUES (@FileNo,@IllakaName,@CFName,@VDC_MP_Name,@HouldHold,@Area,@KhandaCount,@LastRenewDate,@CFCodeNo,@MainSpecies,@PresentFYEng,@PresentFYNep,@PresentFYName)";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;


                cmd.Parameters.AddWithValue("@FileNo", txtFileNo.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@KhandaCount",txtkhandacount.Text);
                cmd.Parameters.AddWithValue("@IllakaName", cmbIllakaName.Text);
                cmd.Parameters.AddWithValue("@CFName", cmbCFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbVDC_MP.Text);
                cmd.Parameters.AddWithValue("@LastRenewDate", txtLatRenewDate.Text);
                cmd.Parameters.AddWithValue("@HouldHold", txtHouseHold.Text);
                cmd.Parameters.AddWithValue("@PresentFYEng", txtPresentFiscalYearEng.Text);
                cmd.Parameters.AddWithValue("@PresentFYNep", txtPresentFiscalYearNepali.Text);
                cmd.Parameters.AddWithValue("@PresentFYName", txtfiscalYearName.Text);
                cmd.Parameters.AddWithValue("@MainSpecies", rchtxtSpecies.Text);

                //Code TO BE GENERATED  for साँख ILLAKAS

                //if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "खलंगा ")
                //{
                //    txtCodeNo.Text = "RUK/" + "SH/" + "31";

                //}


                ////CODE TO BE GENERATED FOR खोलागाउँ

                //else if (cmbIllakaName.Text == "खोलागाउँ")
                //{
                //    txtCodeNo.Text = "RUK/" + "kH/";
                //}

                cmd.Parameters.AddWithValue("@CFCodeNo", txtCodeNo.Text);





                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "added the new FileNo '" + txtFileNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Community Forest UsrGrp Action Plan Details", MessageBoxButtons.OK, MessageBoxIcon.Information);


                btnSave.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {

            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "Update tbl_CFUsrGrp_ActionPlan_Details set FileNo=@FileNo,IllakaName=@IllakaName,CFName=@CFName,VDC_MP_Name=@VDC_MP_Name,HouldHold=@HouldHold,Area=@Area,KhandaCount=@KhandaCount,LastRenewDate=@LastRenewDate, CFCodeNo=@CFCodeNo,MainSpecies=@MainSpecies,PresentFYEng=@PresentFYEng,PresentFYNep=@PresentFYNep, PresentFYName=@PresentFYName  where CFUGACDtls='" + txtID.Text + "'";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;


                cmd.Parameters.AddWithValue("@FileNo", txtFileNo.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@KhandaCount", txtkhandacount.Text);
                cmd.Parameters.AddWithValue("@IllakaName", cmbIllakaName.Text);
                cmd.Parameters.AddWithValue("@CFName", cmbCFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbVDC_MP.Text);
                cmd.Parameters.AddWithValue("@LastRenewDate", txtLatRenewDate.Text);
                cmd.Parameters.AddWithValue("@HouldHold", txtHouseHold.Text);
                cmd.Parameters.AddWithValue("@PresentFYEng", txtPresentFiscalYearEng.Text);
                cmd.Parameters.AddWithValue("@PresentFYNep", txtPresentFiscalYearNepali.Text);
                cmd.Parameters.AddWithValue("@PresentFYName", txtfiscalYearName.Text);
                cmd.Parameters.AddWithValue("@MainSpecies", rchtxtSpecies.Text);

                //Code TO BE GENERATED  for साँख ILLAKAS

                if (cmbIllakaName.Text == "साँख")
                {
                    txtCodeNo.Text = "RUK/" + "SH/" + "31";

                }


                //CODE TO BE GENERATED FOR खोलागाउँ

                else if (cmbIllakaName.Text == "खोलागाउँ")
                {
                    txtCodeNo.Text = "RUK/" + "kH/";
                }

                cmd.Parameters.AddWithValue("@CFCodeNo", txtCodeNo.Text);





                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "Community Forest UsrGrp Action Plan Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the tbl_CFUsrGrp_ActionPlan_Details ='" + txtFileNo.Text + "'";
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

        private void txtHouseHold_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtHouseHold, ref e);
        }

        private void txtkhandacount_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtkhandacount, ref e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CF_UsrGrp_ActionPlan_Details_Records frm = new CF_UsrGrp_ActionPlan_Details_Records();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            frm.set.Text = "CF_UsrGrp_ActionPlan_Details_View Records";
            frm.Show();
        }
    }
}
