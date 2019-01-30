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
    public partial class IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails : Form
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

        public IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails()
        {
            InitializeComponent();
        }

        private void func()
        {
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Illaka Forest Office And VDC_AccTo_CF Usr Grp Details' and User_Registration.UserID='" + lblUser.Text + "' ";
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
            txtAAC.Text = "";
            txtArea.Text = "";
            txtCFFiscalYear.Text = "";
            txtCFGS.Text = "";
            txtCFHandOverDate.Text = "";
            txtCodeNo.Text = "";
            txtFemale.Text = "";
            txtFileNo.Text = "";
            txtGroupRegnDate.Text = "";
            txtfiscalYearName.Text = "";
            txtHouseHold.Text = "";
            txtLatRenewDate.Text = "";
            txtMale.Text = "";
            txtTotalHouseHold.Text = "";
            txtPresentFiscalYearEng.Text = "";
            txtPresentFiscalYearNepali.Text = "";
            rchtxtSpecies.Text = "";
            cmbCFName.Text = "";
            cmbIllakaName.Text = "";
            cmbVDC_MP.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtSiteName.Text = "";
            txtTestCode.Text = "";

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

        private void cmbCFName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbVDC_MP.Items.Clear();
            //cmbVDC_MP.Text = "";
            //cmbVDC_MP.Enabled = true;
            //cmbVDC_MP.Focus();

            //try
            //{

            //    con = new SqlConnection(cs.DBcon);
            //    con.Open();


            //    string ct = "select distinct  RTRIM( VDC_MP_Name ) from tbl_CommunityForestInfo where CommunityForestName ='" + cmbCFName.Text + "' ";

            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;

            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        cmbVDC_MP.Items.Add(rdr[0]);
            //    }
            //    con.Close();

            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails_Load(object sender, EventArgs e)
        {
            AutocompleteCommunityForest();
            AutocompleteVDCMPName();
            AutocompleteIllakaName();
            FiscalYearName();
        }

        private double total()
        {
            int sum = 0;
            int total = 0;
            int male = 0;
            int Female = 0;
            int HouseHold = 0;

            if (txtTotalHouseHold.Text == "")
                total = Convert.ToInt32(0);
            else
                total = Convert.ToInt32(txtTotalHouseHold.Text);

            if (txtMale.Text == "")
                male = Convert.ToInt32(0);
            else
                male = Convert.ToInt32(txtMale.Text);


            if (txtFemale.Text == "")

                Female = Convert.ToInt32(0);
            else
                Female = Convert.ToInt32(txtFemale.Text);


            if (txtHouseHold.Text == "")

                HouseHold = Convert.ToInt32(0);
            else
                HouseHold = Convert.ToInt32(txtHouseHold.Text);


            sum = male + Female;
            return sum;

        }

        private void txtHouseHold_TextChanged(object sender, EventArgs e)
        {
            txtTotalHouseHold.Text = total().ToString();
        }

        private void txtMale_TextChanged(object sender, EventArgs e)
        {
            txtTotalHouseHold.Text = total().ToString();
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

        private void txtFemale_TextChanged(object sender, EventArgs e)
        {
            txtTotalHouseHold.Text = total().ToString();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
            btnSave.Enabled = true;
        }

        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails where IFOAVDCFUGDtls='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Illaka Forest Office And VDC_AccTo_CFUsrGrp Details is deleted FileNo='" + txtFileNo.Text + "'";
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

        private void auto()
        {
            //txtCodeNo.Text = "RUK/-" ;
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

                string cb = "insert into tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails ( FileNo,IllakaName,CFName,VDC_MP_Name,HouldHold,Male,Female,Total,Area,CFGS,AAC,CF_FiscalYear,CFHandOverDate,LastRenewDate,GroupRegnDate,CFCodeNo,MainSpecies,PresentFYEng,PresentFYNep,PresentFYName,Latitude,Longitude,SiteName,TestCode) VALUES (@FileNo,@IllakaName,@CFName,@VDC_MP_Name,@HouldHold,@Male,@Female,@Total,@Area,@CFGS,@AAC,@CF_FiscalYear, @CFHandOverDate,@LastRenewDate,@GroupRegnDate,@CFCodeNo,@MainSpecies,@PresentFYEng,@PresentFYNep,@PresentFYName,@Latitude,@Longitude,@SiteName,@TestCode)";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;


                cmd.Parameters.AddWithValue("@FileNo", txtFileNo.Text);
                cmd.Parameters.AddWithValue("@CFGS", txtCFGS.Text);
                cmd.Parameters.AddWithValue("@AAC", txtAAC.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@Latitude",txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude",txtLongitude. Text);
                cmd.Parameters.AddWithValue("@IllakaName", cmbIllakaName.Text);
                cmd.Parameters.AddWithValue("@CFName", cmbCFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbVDC_MP.Text);
                cmd.Parameters.AddWithValue("@SiteName", txtSiteName.Text);
                cmd.Parameters.AddWithValue("@CF_FiscalYear", txtCFFiscalYear.Text);
                cmd.Parameters.AddWithValue("@CFHandOverDate",txtCFHandOverDate.Text);
                cmd.Parameters.AddWithValue("@GroupRegnDate", txtGroupRegnDate.Text);
                cmd.Parameters.AddWithValue("@LastRenewDate",txtLatRenewDate. Text);
                cmd.Parameters.AddWithValue("@HouldHold", txtHouseHold.Text);
                if (txtMale.Text == "")
                    cmd.Parameters.AddWithValue("@Male", 0);
                else
                    cmd.Parameters.AddWithValue("@Male", txtMale.Text);


                if (txtFemale.Text == "")
                    cmd.Parameters.AddWithValue("@Female", 0);
                else
                    cmd.Parameters.AddWithValue("@Female", txtFemale.Text);


                if (txtTotalHouseHold.Text == "")
                    cmd.Parameters.AddWithValue("@Total", 0);
                else
                    cmd.Parameters.AddWithValue("@Total", txtTotalHouseHold.Text);

                cmd.Parameters.AddWithValue("@PresentFYEng", txtPresentFiscalYearEng.Text);
                cmd.Parameters.AddWithValue("@PresentFYNep", txtPresentFiscalYearNepali.Text);
                cmd.Parameters.AddWithValue("@PresentFYName", txtfiscalYearName.Text);
                cmd.Parameters.AddWithValue("@MainSpecies",rchtxtSpecies.Text);




                #region//Code TO BE GENERATED  for साँख ILLAKAS

                if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "खलंगा  १" || cmbVDC_MP.Text == "खलंगा  २" || cmbVDC_MP.Text == "खलंगा  ३" || cmbVDC_MP.Text == "खलंगा  ४" || cmbVDC_MP.Text == "खलंगा  ५" || cmbVDC_MP.Text == "खलंगा  ६" || cmbVDC_MP.Text == "खलंगा  ७" || cmbVDC_MP.Text == "खलंगा  ८" || cmbVDC_MP.Text == "खलंगा  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "31";
                }
                else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "साँख  १" || cmbVDC_MP.Text == "साँख  २" || cmbVDC_MP.Text == "साँख  ३" || cmbVDC_MP.Text == "साँख  ४" || cmbVDC_MP.Text == "साँख  ५" || cmbVDC_MP.Text == "साँख  ६" || cmbVDC_MP.Text == "साँख  ७" || cmbVDC_MP.Text == "साँख  ८" || cmbVDC_MP.Text == "साँख  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "30";
                }
                else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "स्यालापाखा  १" || cmbVDC_MP.Text == "स्यालापाखा  २" || cmbVDC_MP.Text == "स्यालापाखा  ३" || cmbVDC_MP.Text == "स्यालापाखा  ४" || cmbVDC_MP.Text == "स्यालापाखा  ५" || cmbVDC_MP.Text == "स्यालापाखा  ६" || cmbVDC_MP.Text == "स्यालापाखा  ७" || cmbVDC_MP.Text == "स्यालापाखा  ८" || cmbVDC_MP.Text == "स्यालापाखा  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "32";
                }
                else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "चुनवाङ  १" || cmbVDC_MP.Text == "चुनवाङ  २" || cmbVDC_MP.Text == "चुनवाङ  ३" || cmbVDC_MP.Text == "चुनवाङ  ४" || cmbVDC_MP.Text == "चुनवाङ  ५" || cmbVDC_MP.Text == "चुनवाङ  ६" || cmbVDC_MP.Text == "चुनवाङ  ७" || cmbVDC_MP.Text == "चुनवाङ  ८" || cmbVDC_MP.Text == "चुनवाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "33";
                }
                else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "चौखवाङ  १" || cmbVDC_MP.Text == "चौखवाङ  २" || cmbVDC_MP.Text == "चौखवाङ  ३" || cmbVDC_MP.Text == "चौखवाङ  ४" || cmbVDC_MP.Text == "चौखवाङ  ५" || cmbVDC_MP.Text == "चौखवाङ  ६" || cmbVDC_MP.Text == "चौखवाङ  ७" || cmbVDC_MP.Text == "चौखवाङ  ८" || cmbVDC_MP.Text == "चौखवाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "29";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌रुंघा ILLAKAS
                if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "मूरू  १" || cmbVDC_MP.Text == "मूरू  २" || cmbVDC_MP.Text == "मूरू  ३" || cmbVDC_MP.Text == "मूरू  ४" || cmbVDC_MP.Text == "मूरू  ५" || cmbVDC_MP.Text == "मूरू  ६" || cmbVDC_MP.Text == "मूरू  ७" || cmbVDC_MP.Text == "मूरू  ८" || cmbVDC_MP.Text == "मूरू  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "10";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "रुंघा  १" || cmbVDC_MP.Text == "रुंघा  २" || cmbVDC_MP.Text == "रुंघा  ३" || cmbVDC_MP.Text == "रुंघा  ४" || cmbVDC_MP.Text == "रुंघा  ५" || cmbVDC_MP.Text == "रुंघा  ६" || cmbVDC_MP.Text == "रुंघा  ७" || cmbVDC_MP.Text == "रुंघा  ८" || cmbVDC_MP.Text == "रुंघा  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "12";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "खारा  १" || cmbVDC_MP.Text == "खारा  २" || cmbVDC_MP.Text == "खारा  ३" || cmbVDC_MP.Text == "खारा  ४" || cmbVDC_MP.Text == "खारा  ५" || cmbVDC_MP.Text == "खारा  ६" || cmbVDC_MP.Text == "खारा  ७" || cmbVDC_MP.Text == "खारा  ८" || cmbVDC_MP.Text == "खारा  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "11";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "नुवाकोट  १" || cmbVDC_MP.Text == "नुवाकोट  २" || cmbVDC_MP.Text == "नुवाकोट  ३" || cmbVDC_MP.Text == "नुवाकोट  ४" || cmbVDC_MP.Text == "नुवाकोट  ५" || cmbVDC_MP.Text == "नुवाकोट  ६" || cmbVDC_MP.Text == "नुवाकोट  ७" || cmbVDC_MP.Text == "नुवाकोट  ८" || cmbVDC_MP.Text == "नुवाकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "07";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "पेउघा  १" || cmbVDC_MP.Text == "पेउघा  २" || cmbVDC_MP.Text == "पेउघा  ३" || cmbVDC_MP.Text == "पेउघा  ४" || cmbVDC_MP.Text == "पेउघा  ५" || cmbVDC_MP.Text == "पेउघा  ६" || cmbVDC_MP.Text == "पेउघा  ७" || cmbVDC_MP.Text == "पेउघा  ८" || cmbVDC_MP.Text == "पेउघा  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "08";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "छिवाङ  १" || cmbVDC_MP.Text == "छिवाङ  २" || cmbVDC_MP.Text == "छिवाङ  ३" || cmbVDC_MP.Text == "छिवाङ  ४" || cmbVDC_MP.Text == "छिवाङ  ५" || cmbVDC_MP.Text == "छिवाङ  ६" || cmbVDC_MP.Text == "छिवाङ  ७" || cmbVDC_MP.Text == "छिवाङ  ८" || cmbVDC_MP.Text == "छिवाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "09";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "भलाक्चा  १" || cmbVDC_MP.Text == "भलाक्चा  २" || cmbVDC_MP.Text == "भलाक्चा  ३" || cmbVDC_MP.Text == "भलाक्चा  ४" || cmbVDC_MP.Text == "भलाक्चा  ५" || cmbVDC_MP.Text == "भलाक्चा  ६" || cmbVDC_MP.Text == "भलाक्चा  ७" || cmbVDC_MP.Text == "भलाक्चा  ८" || cmbVDC_MP.Text == "भलाक्चा  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "13";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌खोलागाउँ ILLAKAS
                if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "खोलागाउँ  १" || cmbVDC_MP.Text == "खोलागाउँ  २" || cmbVDC_MP.Text == "खोलागाउँ  ३" || cmbVDC_MP.Text == "खोलागाउँ  ४" || cmbVDC_MP.Text == "खोलागाउँ  ५" || cmbVDC_MP.Text == "खोलागाउँ  ६" || cmbVDC_MP.Text == "खोलागाउँ  ७" || cmbVDC_MP.Text == "खोलागाउँ  ८" || cmbVDC_MP.Text == "खोलागाउँ  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "04";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "बिजयश्योरी  १" || cmbVDC_MP.Text == "बिजयश्योरी  २" || cmbVDC_MP.Text == "बिजयश्योरी  ३" || cmbVDC_MP.Text == "बिजयश्योरी  ४" || cmbVDC_MP.Text == "बिजयश्योरी  ५" || cmbVDC_MP.Text == "बिजयश्योरी  ६" || cmbVDC_MP.Text == "बिजयश्योरी  ७" || cmbVDC_MP.Text == "बिजयश्योरी  ८" || cmbVDC_MP.Text == "बिजयश्योरी  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "01";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "कोटजहारी  १" || cmbVDC_MP.Text == "कोटजहारी  २" || cmbVDC_MP.Text == "कोटजहारी  ३" || cmbVDC_MP.Text == "कोटजहारी  ४" || cmbVDC_MP.Text == "कोटजहारी  ५" || cmbVDC_MP.Text == "कोटजहारी  ६" || cmbVDC_MP.Text == "कोटजहारी  ७" || cmbVDC_MP.Text == "कोटजहारी  ८" || cmbVDC_MP.Text == "कोटजहारी  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "02";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "पूतिेमकांडा  १" || cmbVDC_MP.Text == "पूतिेमकांडा  २" || cmbVDC_MP.Text == "पूतिेमकांडा  ३" || cmbVDC_MP.Text == "पूतिेमकांडा  ४" || cmbVDC_MP.Text == "पूतिेमकांडा  ५" || cmbVDC_MP.Text == "पूतिेमकांडा  ६" || cmbVDC_MP.Text == "पूतिेमकांडा  ७" || cmbVDC_MP.Text == "पूतिेमकांडा  ८" || cmbVDC_MP.Text == "पूतिेमकांडा  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "03";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "अर्मा  १" || cmbVDC_MP.Text == "अर्मा  २" || cmbVDC_MP.Text == "अर्मा  ३" || cmbVDC_MP.Text == "अर्मा  ४" || cmbVDC_MP.Text == "अर्मा  ५" || cmbVDC_MP.Text == "अर्मा  ६" || cmbVDC_MP.Text == "अर्मा  ७" || cmbVDC_MP.Text == "अर्मा  ८" || cmbVDC_MP.Text == "अर्मा  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "06";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "सिम्ली  १" || cmbVDC_MP.Text == "सिम्ली  २" || cmbVDC_MP.Text == "सिम्ली  ३" || cmbVDC_MP.Text == "सिम्ली  ४" || cmbVDC_MP.Text == "सिम्ली  ५" || cmbVDC_MP.Text == "सिम्ली  ६" || cmbVDC_MP.Text == "सिम्ली  ७" || cmbVDC_MP.Text == "सिम्ली  ८" || cmbVDC_MP.Text == "सिम्ली  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "05";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌आठविसकोट ILLAKAS
                if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "आठविसकोट  १" || cmbVDC_MP.Text == "आठविसकोट  २" || cmbVDC_MP.Text == "आठविसकोट  ३" || cmbVDC_MP.Text == "आठविसकोट  ४" || cmbVDC_MP.Text == "आठविसकोट  ५" || cmbVDC_MP.Text == "आठविसकोट  ६" || cmbVDC_MP.Text == "आठविसकोट  ७" || cmbVDC_MP.Text == "आठविसकोट  ८" || cmbVDC_MP.Text == "आठविसकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "20";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "घेत्मा  १" || cmbVDC_MP.Text == "घेत्मा  २" || cmbVDC_MP.Text == "घेत्मा  ३" || cmbVDC_MP.Text == "घेत्मा  ४" || cmbVDC_MP.Text == "घेत्मा  ५" || cmbVDC_MP.Text == "घेत्मा  ६" || cmbVDC_MP.Text == "घेत्मा  ७" || cmbVDC_MP.Text == "घेत्मा  ८" || cmbVDC_MP.Text == "घेत्मा  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "15";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "आठविसडांडा गाऊं  १" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  २" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ३" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ४" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ५" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ६" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ७" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ८" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "16";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "गरायला  १" || cmbVDC_MP.Text == "गरायला  २" || cmbVDC_MP.Text == "गरायला  ३" || cmbVDC_MP.Text == "गरायला  ४" || cmbVDC_MP.Text == "गरायला  ५" || cmbVDC_MP.Text == "गरायला  ६" || cmbVDC_MP.Text == "गरायला  ७" || cmbVDC_MP.Text == "गरायला  ८" || cmbVDC_MP.Text == "गरायला  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "14";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "झूला  १" || cmbVDC_MP.Text == "झूला  २" || cmbVDC_MP.Text == "झूला  ३" || cmbVDC_MP.Text == "झूला  ४" || cmbVDC_MP.Text == "झूला  ५" || cmbVDC_MP.Text == "झूला  ६" || cmbVDC_MP.Text == "झूला  ७" || cmbVDC_MP.Text == "झूला  ८" || cmbVDC_MP.Text == "झूला  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "18";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "मग्मा  १" || cmbVDC_MP.Text == "मग्मा  २" || cmbVDC_MP.Text == "मग्मा  ३" || cmbVDC_MP.Text == "मग्मा  ४" || cmbVDC_MP.Text == "मग्मा  ५" || cmbVDC_MP.Text == "मग्मा  ६" || cmbVDC_MP.Text == "मग्मा  ७" || cmbVDC_MP.Text == "मग्मा  ८" || cmbVDC_MP.Text == "मग्मा  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "19";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "दूली  १" || cmbVDC_MP.Text == "दूली  २" || cmbVDC_MP.Text == "दूली  ३" || cmbVDC_MP.Text == "दूली  ४" || cmbVDC_MP.Text == "दूली  ५" || cmbVDC_MP.Text == "दूली  ६" || cmbVDC_MP.Text == "दूली  ७" || cmbVDC_MP.Text == "दूली  ८" || cmbVDC_MP.Text == "दूली  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "17";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌स्यालाखदी ILLAKAS
                if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "स्यालाखदी  १" || cmbVDC_MP.Text == "स्यालाखदी  २" || cmbVDC_MP.Text == "स्यालाखदी  ३" || cmbVDC_MP.Text == "स्यालाखदी  ४" || cmbVDC_MP.Text == "स्यालाखदी  ५" || cmbVDC_MP.Text == "स्यालाखदी  ६" || cmbVDC_MP.Text == "स्यालाखदी  ७" || cmbVDC_MP.Text == "स्यालाखदी  ८" || cmbVDC_MP.Text == "स्यालाखदी  ९")
                {
                    txtTestCode.Text = "RUK" + "SA" + "27";
                }
                else if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "गोतामकोट  १" || cmbVDC_MP.Text == "गोतामकोट  २" || cmbVDC_MP.Text == "गोतामकोट  ३" || cmbVDC_MP.Text == "गोतामकोट  ४" || cmbVDC_MP.Text == "गोतामकोट  ५" || cmbVDC_MP.Text == "गोतामकोट  ६" || cmbVDC_MP.Text == "गोतामकोट  ७" || cmbVDC_MP.Text == "गोतामकोट  ८" || cmbVDC_MP.Text == "गोतामकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "SA" + "26";
                }
                else if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "सिस्ने  १" || cmbVDC_MP.Text == "सिस्ने  २" || cmbVDC_MP.Text == "सिस्ने  ३" || cmbVDC_MP.Text == "सिस्ने  ४" || cmbVDC_MP.Text == "सिस्ने  ५" || cmbVDC_MP.Text == "सिस्ने  ६" || cmbVDC_MP.Text == "सिस्ने  ७" || cmbVDC_MP.Text == "सिस्ने  ८" || cmbVDC_MP.Text == "सिस्ने  ९")
                {
                    txtTestCode.Text = "RUK" + "SA" + "28";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌प्वाङ ILLAKAS
                if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "प्वाङ  १" || cmbVDC_MP.Text == "प्वाङ  २" || cmbVDC_MP.Text == "प्वाङ  ३" || cmbVDC_MP.Text == "प्वाङ  ४" || cmbVDC_MP.Text == "प्वाङ  ५" || cmbVDC_MP.Text == "प्वाङ  ६" || cmbVDC_MP.Text == "प्वाङ  ७" || cmbVDC_MP.Text == "प्वाङ  ८" || cmbVDC_MP.Text == "प्वाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "24";
                }
                else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "पोखरा  १" || cmbVDC_MP.Text == "पोखरा  २" || cmbVDC_MP.Text == "पोखरा  ३" || cmbVDC_MP.Text == "पोखरा  ४" || cmbVDC_MP.Text == "पोखरा  ५" || cmbVDC_MP.Text == "पोखरा  ६" || cmbVDC_MP.Text == "पोखरा  ७" || cmbVDC_MP.Text == "पोखरा  ८" || cmbVDC_MP.Text == "पोखरा  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "23";
                }
                else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "पिपल  १" || cmbVDC_MP.Text == "पिपल  २" || cmbVDC_MP.Text == "पिपल  ३" || cmbVDC_MP.Text == "पिपल  ४" || cmbVDC_MP.Text == "पिपल  ५" || cmbVDC_MP.Text == "पिपल  ६" || cmbVDC_MP.Text == "पिपल  ७" || cmbVDC_MP.Text == "पिपल  ८" || cmbVDC_MP.Text == "पिपल  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "22";
                }
                else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "बाफिकोट  १" || cmbVDC_MP.Text == "बाफिकोट  २" || cmbVDC_MP.Text == "बाफिकोट  ३" || cmbVDC_MP.Text == "बाफिकोट  ४" || cmbVDC_MP.Text == "बाफिकोट  ५" || cmbVDC_MP.Text == "बाफिकोट  ६" || cmbVDC_MP.Text == "बाफिकोट  ७" || cmbVDC_MP.Text == "बाफिकोट  ८" || cmbVDC_MP.Text == "बाफिकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "21";
                }
                else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "जाङ  १" || cmbVDC_MP.Text == "जाङ  २" || cmbVDC_MP.Text == "जाङ  ३" || cmbVDC_MP.Text == "जाङ  ४" || cmbVDC_MP.Text == "जाङ  ५" || cmbVDC_MP.Text == "जाङ  ६" || cmbVDC_MP.Text == "जाङ  ७" || cmbVDC_MP.Text == "जाङ  ८" || cmbVDC_MP.Text == "जाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "25";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌मोरावाङ ILLAKAS
                if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "शोभा  १" || cmbVDC_MP.Text == "शोभा  २" || cmbVDC_MP.Text == "शोभा  ३" || cmbVDC_MP.Text == "शोभा  ४" || cmbVDC_MP.Text == "शोभा  ५" || cmbVDC_MP.Text == "शोभा  ६" || cmbVDC_MP.Text == "शोभा  ७" || cmbVDC_MP.Text == "शोभा  ८" || cmbVDC_MP.Text == "शोभा  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "34";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "रुकूमकोट  १" || cmbVDC_MP.Text == "रुकूमकोट  २" || cmbVDC_MP.Text == "रुकूमकोट  ३" || cmbVDC_MP.Text == "रुकूमकोट  ४" || cmbVDC_MP.Text == "रुकूमकोट  ५" || cmbVDC_MP.Text == "रुकूमकोट  ६" || cmbVDC_MP.Text == "रुकूमकोट  ७" || cmbVDC_MP.Text == "रुकूमकोट  ८" || cmbVDC_MP.Text == "रुकूमकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "34";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "कांडा  १" || cmbVDC_MP.Text == "कांडा  २" || cmbVDC_MP.Text == "कांडा  ३" || cmbVDC_MP.Text == "कांडा  ४" || cmbVDC_MP.Text == "कांडा  ५" || cmbVDC_MP.Text == "कांडा  ६" || cmbVDC_MP.Text == "कांडा  ७" || cmbVDC_MP.Text == "कांडा  ८" || cmbVDC_MP.Text == "कांडा  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "36";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "मोरावाङ  १" || cmbVDC_MP.Text == "मोरावाङ  २" || cmbVDC_MP.Text == "मोरावाङ  ३" || cmbVDC_MP.Text == "मोरावाङ  ४" || cmbVDC_MP.Text == "मोरावाङ  ५" || cmbVDC_MP.Text == "मोरावाङ  ६" || cmbVDC_MP.Text == "मोरावाङ  ७" || cmbVDC_MP.Text == "मोरावाङ  ८" || cmbVDC_MP.Text == "मोरावाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "37";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "महत  १" || cmbVDC_MP.Text == "महत  २" || cmbVDC_MP.Text == "महत  ३" || cmbVDC_MP.Text == "महत  ४" || cmbVDC_MP.Text == "महत  ५" || cmbVDC_MP.Text == "महत  ६" || cmbVDC_MP.Text == "महत  ७" || cmbVDC_MP.Text == "महत  ८" || cmbVDC_MP.Text == "महत  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "35";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "कांत्रि  १" || cmbVDC_MP.Text == "कांत्रि   २" || cmbVDC_MP.Text == "कांत्रि   ३" || cmbVDC_MP.Text == "कांत्रि   ४" || cmbVDC_MP.Text == "कांत्रि   ५" || cmbVDC_MP.Text == "कांत्रि   ६" || cmbVDC_MP.Text == "कांत्रि   ७" || cmbVDC_MP.Text == "कांत्रि   ८" || cmbVDC_MP.Text == "कांत्रि   ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "38";
                }

                #endregion

                #region//Code TO BE GENERATED  for ‍‌कोल ILLAKAS
                if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "कोल  १" || cmbVDC_MP.Text == "कोल  २" || cmbVDC_MP.Text == "कोल  ३" || cmbVDC_MP.Text == "कोल  ४" || cmbVDC_MP.Text == "कोल  ५" || cmbVDC_MP.Text == "कोल  ६" || cmbVDC_MP.Text == "कोल  ७" || cmbVDC_MP.Text == "कोल  ८" || cmbVDC_MP.Text == "कोल  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "40";
                }
                else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "राङसी  १" || cmbVDC_MP.Text == "राङसी  २" || cmbVDC_MP.Text == "राङसी  ३" || cmbVDC_MP.Text == "राङसी  ४" || cmbVDC_MP.Text == "राङसी  ५" || cmbVDC_MP.Text == "राङसी  ६" || cmbVDC_MP.Text == "राङसी  ७" || cmbVDC_MP.Text == "राङसी  ८" || cmbVDC_MP.Text == "राङसी  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "39";
                }
                else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "तकसेरा  १" || cmbVDC_MP.Text == "तकसेरा  २" || cmbVDC_MP.Text == "तकसेरा  ३" || cmbVDC_MP.Text == "तकसेरा  ४" || cmbVDC_MP.Text == "तकसेरा  ५" || cmbVDC_MP.Text == "तकसेरा  ६" || cmbVDC_MP.Text == "तकसेरा  ७" || cmbVDC_MP.Text == "तकसेरा  ८" || cmbVDC_MP.Text == "तकसेरा  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "41";
                }
                else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "हुकाम  १" || cmbVDC_MP.Text == "हुकाम  २" || cmbVDC_MP.Text == "हुकाम  ३" || cmbVDC_MP.Text == "हुकाम  ४" || cmbVDC_MP.Text == "हुकाम  ५" || cmbVDC_MP.Text == "हुकाम  ६" || cmbVDC_MP.Text == "हुकाम  ७" || cmbVDC_MP.Text == "हुकाम  ८" || cmbVDC_MP.Text == "हुकाम  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "43";
                }
                else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "रन्मामैकोट  १" || cmbVDC_MP.Text == "रन्मामैकोट  २" || cmbVDC_MP.Text == "रन्मामैकोट  ३" || cmbVDC_MP.Text == "रन्मामैकोट  ४" || cmbVDC_MP.Text == "रन्मामैकोट  ५" || cmbVDC_MP.Text == "रन्मामैकोट  ६" || cmbVDC_MP.Text == "महत  ७" || cmbVDC_MP.Text == "रन्मामैकोट  ८" || cmbVDC_MP.Text == "रन्मामैकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "42";
                }


                #endregion

                cmd.Parameters.AddWithValue("@CFCodeNo", txtCodeNo.Text);
                cmd.Parameters.AddWithValue("@TestCode", txtTestCode.Text);
              

                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "added the new FileNo '" +txtFileNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Illaka Forest Office And VDC_AccTo_CFUsrGrp Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                string cb = "Update tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails set FileNo=@FileNo,IllakaName=@IllakaName,CFName=@CFName,VDC_MP_Name=@VDC_MP_Name,HouldHold=@HouldHold,Male=@Male,Female=@Female,Total=@Total,Area=@Area,CFGS=@CFGS,AAC=@AAC,CF_FiscalYear=@CF_FiscalYear,CFHandOverDate=@CFHandOverDate,LastRenewDate=@LastRenewDate, GroupRegnDate=@GroupRegnDate,CFCodeNo=@CFCodeNo,MainSpecies=@MainSpecies,PresentFYEng=@PresentFYEng,PresentFYNep=@PresentFYNep, PresentFYName=@PresentFYName,Latitude=@Latitude,Longitude=@Longitude,SiteName=@SiteName,  TestCode=@TestCode where IFOAVDCFUGDtls='" + txtID.Text + "'";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@FileNo", txtFileNo.Text);
                cmd.Parameters.AddWithValue("@CFGS", txtCFGS.Text);
                cmd.Parameters.AddWithValue("@AAC", txtAAC.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@IllakaName", cmbIllakaName.Text);
                cmd.Parameters.AddWithValue("@CFName", cmbCFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbVDC_MP.Text);
                cmd.Parameters.AddWithValue("@SiteName", txtSiteName.Text);
                cmd.Parameters.AddWithValue("@CF_FiscalYear", txtCFFiscalYear.Text);
                cmd.Parameters.AddWithValue("@CFHandOverDate", txtCFHandOverDate.Text);
                cmd.Parameters.AddWithValue("@GroupRegnDate", txtGroupRegnDate.Text);
                cmd.Parameters.AddWithValue("@LastRenewDate", txtLatRenewDate.Text);
                cmd.Parameters.AddWithValue("@HouldHold", txtHouseHold.Text);
                if (txtMale.Text == "")
                    cmd.Parameters.AddWithValue("@Male", 0);
                else
                    cmd.Parameters.AddWithValue("@Male", txtMale.Text);


                if (txtFemale.Text == "")
                    cmd.Parameters.AddWithValue("@Female", 0);
                else
                    cmd.Parameters.AddWithValue("@Female", txtFemale.Text);


                if (txtTotalHouseHold.Text == "")
                    cmd.Parameters.AddWithValue("@Total", 0);
                else
                    cmd.Parameters.AddWithValue("@Total", txtTotalHouseHold.Text);

                cmd.Parameters.AddWithValue("@PresentFYEng", txtPresentFiscalYearEng.Text);
                cmd.Parameters.AddWithValue("@PresentFYNep", txtPresentFiscalYearNepali.Text);
                cmd.Parameters.AddWithValue("@PresentFYName", txtfiscalYearName.Text);
                cmd.Parameters.AddWithValue("@MainSpecies", rchtxtSpecies.Text);

                #region//Code TO BE GENERATED  for साँख ILLAKAS

                if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "खलंगा  १" || cmbVDC_MP.Text == "खलंगा  २" || cmbVDC_MP.Text == "खलंगा  ३" || cmbVDC_MP.Text == "खलंगा  ४" || cmbVDC_MP.Text == "खलंगा  ५" || cmbVDC_MP.Text == "खलंगा  ६" || cmbVDC_MP.Text == "खलंगा  ७" || cmbVDC_MP.Text == "खलंगा  ८" || cmbVDC_MP.Text == "खलंगा  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "31";
                }
                else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "साँख  १" || cmbVDC_MP.Text == "साँख  २" || cmbVDC_MP.Text == "साँख  ३" || cmbVDC_MP.Text == "साँख  ४" || cmbVDC_MP.Text == "साँख  ५" || cmbVDC_MP.Text == "साँख  ६" || cmbVDC_MP.Text == "साँख  ७" || cmbVDC_MP.Text == "साँख  ८" || cmbVDC_MP.Text == "साँख  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "30";
                }
                else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "स्यालापाखा  १" || cmbVDC_MP.Text == "स्यालापाखा  २" || cmbVDC_MP.Text == "स्यालापाखा  ३" || cmbVDC_MP.Text == "स्यालापाखा  ४" || cmbVDC_MP.Text == "स्यालापाखा  ५" || cmbVDC_MP.Text == "स्यालापाखा  ६" || cmbVDC_MP.Text == "स्यालापाखा  ७" || cmbVDC_MP.Text == "स्यालापाखा  ८" || cmbVDC_MP.Text == "स्यालापाखा  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "32";
                }
                else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "चुनवाङ  १" || cmbVDC_MP.Text == "चुनवाङ  २" || cmbVDC_MP.Text == "चुनवाङ  ३" || cmbVDC_MP.Text == "चुनवाङ  ४" || cmbVDC_MP.Text == "चुनवाङ  ५" || cmbVDC_MP.Text == "चुनवाङ  ६" || cmbVDC_MP.Text == "चुनवाङ  ७" || cmbVDC_MP.Text == "चुनवाङ  ८" || cmbVDC_MP.Text == "चुनवाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "33";
                }
                else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "चौखवाङ  १" || cmbVDC_MP.Text == "चौखवाङ  २" || cmbVDC_MP.Text == "चौखवाङ  ३" || cmbVDC_MP.Text == "चौखवाङ  ४" || cmbVDC_MP.Text == "चौखवाङ  ५" || cmbVDC_MP.Text == "चौखवाङ  ६" || cmbVDC_MP.Text == "चौखवाङ  ७" || cmbVDC_MP.Text == "चौखवाङ  ८" || cmbVDC_MP.Text == "चौखवाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "SH" + "29";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌रुंघा ILLAKAS
                if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "मूरू  १" || cmbVDC_MP.Text == "मूरू  २" || cmbVDC_MP.Text == "मूरू  ३" || cmbVDC_MP.Text == "मूरू  ४" || cmbVDC_MP.Text == "मूरू  ५" || cmbVDC_MP.Text == "मूरू  ६" || cmbVDC_MP.Text == "मूरू  ७" || cmbVDC_MP.Text == "मूरू  ८" || cmbVDC_MP.Text == "मूरू  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "10";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "रुंघा  १" || cmbVDC_MP.Text == "रुंघा  २" || cmbVDC_MP.Text == "रुंघा  ३" || cmbVDC_MP.Text == "रुंघा  ४" || cmbVDC_MP.Text == "रुंघा  ५" || cmbVDC_MP.Text == "रुंघा  ६" || cmbVDC_MP.Text == "रुंघा  ७" || cmbVDC_MP.Text == "रुंघा  ८" || cmbVDC_MP.Text == "रुंघा  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "12";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "खारा  १" || cmbVDC_MP.Text == "खारा  २" || cmbVDC_MP.Text == "खारा  ३" || cmbVDC_MP.Text == "खारा  ४" || cmbVDC_MP.Text == "खारा  ५" || cmbVDC_MP.Text == "खारा  ६" || cmbVDC_MP.Text == "खारा  ७" || cmbVDC_MP.Text == "खारा  ८" || cmbVDC_MP.Text == "खारा  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "11";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "नुवाकोट  १" || cmbVDC_MP.Text == "नुवाकोट  २" || cmbVDC_MP.Text == "नुवाकोट  ३" || cmbVDC_MP.Text == "नुवाकोट  ४" || cmbVDC_MP.Text == "नुवाकोट  ५" || cmbVDC_MP.Text == "नुवाकोट  ६" || cmbVDC_MP.Text == "नुवाकोट  ७" || cmbVDC_MP.Text == "नुवाकोट  ८" || cmbVDC_MP.Text == "नुवाकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "07";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "पेउघा  १" || cmbVDC_MP.Text == "पेउघा  २" || cmbVDC_MP.Text == "पेउघा  ३" || cmbVDC_MP.Text == "पेउघा  ४" || cmbVDC_MP.Text == "पेउघा  ५" || cmbVDC_MP.Text == "पेउघा  ६" || cmbVDC_MP.Text == "पेउघा  ७" || cmbVDC_MP.Text == "पेउघा  ८" || cmbVDC_MP.Text == "पेउघा  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "08";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "छिवाङ  १" || cmbVDC_MP.Text == "छिवाङ  २" || cmbVDC_MP.Text == "छिवाङ  ३" || cmbVDC_MP.Text == "छिवाङ  ४" || cmbVDC_MP.Text == "छिवाङ  ५" || cmbVDC_MP.Text == "छिवाङ  ६" || cmbVDC_MP.Text == "छिवाङ  ७" || cmbVDC_MP.Text == "छिवाङ  ८" || cmbVDC_MP.Text == "छिवाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "09";
                }
                else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "भलाक्चा  १" || cmbVDC_MP.Text == "भलाक्चा  २" || cmbVDC_MP.Text == "भलाक्चा  ३" || cmbVDC_MP.Text == "भलाक्चा  ४" || cmbVDC_MP.Text == "भलाक्चा  ५" || cmbVDC_MP.Text == "भलाक्चा  ६" || cmbVDC_MP.Text == "भलाक्चा  ७" || cmbVDC_MP.Text == "भलाक्चा  ८" || cmbVDC_MP.Text == "भलाक्चा  ९")
                {
                    txtTestCode.Text = "RUK" + "RU" + "13";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌खोलागाउँ ILLAKAS
                if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "खोलागाउँ  १" || cmbVDC_MP.Text == "खोलागाउँ  २" || cmbVDC_MP.Text == "खोलागाउँ  ३" || cmbVDC_MP.Text == "खोलागाउँ  ४" || cmbVDC_MP.Text == "खोलागाउँ  ५" || cmbVDC_MP.Text == "खोलागाउँ  ६" || cmbVDC_MP.Text == "खोलागाउँ  ७" || cmbVDC_MP.Text == "खोलागाउँ  ८" || cmbVDC_MP.Text == "खोलागाउँ  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "04";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "बिजयश्योरी  १" || cmbVDC_MP.Text == "बिजयश्योरी  २" || cmbVDC_MP.Text == "बिजयश्योरी  ३" || cmbVDC_MP.Text == "बिजयश्योरी  ४" || cmbVDC_MP.Text == "बिजयश्योरी  ५" || cmbVDC_MP.Text == "बिजयश्योरी  ६" || cmbVDC_MP.Text == "बिजयश्योरी  ७" || cmbVDC_MP.Text == "बिजयश्योरी  ८" || cmbVDC_MP.Text == "बिजयश्योरी  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "01";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "कोटजहारी  १" || cmbVDC_MP.Text == "कोटजहारी  २" || cmbVDC_MP.Text == "कोटजहारी  ३" || cmbVDC_MP.Text == "कोटजहारी  ४" || cmbVDC_MP.Text == "कोटजहारी  ५" || cmbVDC_MP.Text == "कोटजहारी  ६" || cmbVDC_MP.Text == "कोटजहारी  ७" || cmbVDC_MP.Text == "कोटजहारी  ८" || cmbVDC_MP.Text == "कोटजहारी  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "02";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "पूतिेमकांडा  १" || cmbVDC_MP.Text == "पूतिेमकांडा  २" || cmbVDC_MP.Text == "पूतिेमकांडा  ३" || cmbVDC_MP.Text == "पूतिेमकांडा  ४" || cmbVDC_MP.Text == "पूतिेमकांडा  ५" || cmbVDC_MP.Text == "पूतिेमकांडा  ६" || cmbVDC_MP.Text == "पूतिेमकांडा  ७" || cmbVDC_MP.Text == "पूतिेमकांडा  ८" || cmbVDC_MP.Text == "पूतिेमकांडा  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "03";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "अर्मा  १" || cmbVDC_MP.Text == "अर्मा  २" || cmbVDC_MP.Text == "अर्मा  ३" || cmbVDC_MP.Text == "अर्मा  ४" || cmbVDC_MP.Text == "अर्मा  ५" || cmbVDC_MP.Text == "अर्मा  ६" || cmbVDC_MP.Text == "अर्मा  ७" || cmbVDC_MP.Text == "अर्मा  ८" || cmbVDC_MP.Text == "अर्मा  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "06";
                }
                else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "सिम्ली  १" || cmbVDC_MP.Text == "सिम्ली  २" || cmbVDC_MP.Text == "सिम्ली  ३" || cmbVDC_MP.Text == "सिम्ली  ४" || cmbVDC_MP.Text == "सिम्ली  ५" || cmbVDC_MP.Text == "सिम्ली  ६" || cmbVDC_MP.Text == "सिम्ली  ७" || cmbVDC_MP.Text == "सिम्ली  ८" || cmbVDC_MP.Text == "सिम्ली  ९")
                {
                    txtTestCode.Text = "RUK" + "KH" + "05";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌आठविसकोट ILLAKAS
                if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "आठविसकोट  १" || cmbVDC_MP.Text == "आठविसकोट  २" || cmbVDC_MP.Text == "आठविसकोट  ३" || cmbVDC_MP.Text == "आठविसकोट  ४" || cmbVDC_MP.Text == "आठविसकोट  ५" || cmbVDC_MP.Text == "आठविसकोट  ६" || cmbVDC_MP.Text == "आठविसकोट  ७" || cmbVDC_MP.Text == "आठविसकोट  ८" || cmbVDC_MP.Text == "आठविसकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "20";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "घेत्मा  १" || cmbVDC_MP.Text == "घेत्मा  २" || cmbVDC_MP.Text == "घेत्मा  ३" || cmbVDC_MP.Text == "घेत्मा  ४" || cmbVDC_MP.Text == "घेत्मा  ५" || cmbVDC_MP.Text == "घेत्मा  ६" || cmbVDC_MP.Text == "घेत्मा  ७" || cmbVDC_MP.Text == "घेत्मा  ८" || cmbVDC_MP.Text == "घेत्मा  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "15";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "आठविसडांडा गाऊं  १" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  २" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ३" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ४" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ५" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ६" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ७" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ८" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "16";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "गरायला  १" || cmbVDC_MP.Text == "गरायला  २" || cmbVDC_MP.Text == "गरायला  ३" || cmbVDC_MP.Text == "गरायला  ४" || cmbVDC_MP.Text == "गरायला  ५" || cmbVDC_MP.Text == "गरायला  ६" || cmbVDC_MP.Text == "गरायला  ७" || cmbVDC_MP.Text == "गरायला  ८" || cmbVDC_MP.Text == "गरायला  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "14";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "झूला  १" || cmbVDC_MP.Text == "झूला  २" || cmbVDC_MP.Text == "झूला  ३" || cmbVDC_MP.Text == "झूला  ४" || cmbVDC_MP.Text == "झूला  ५" || cmbVDC_MP.Text == "झूला  ६" || cmbVDC_MP.Text == "झूला  ७" || cmbVDC_MP.Text == "झूला  ८" || cmbVDC_MP.Text == "झूला  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "18";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "मग्मा  १" || cmbVDC_MP.Text == "मग्मा  २" || cmbVDC_MP.Text == "मग्मा  ३" || cmbVDC_MP.Text == "मग्मा  ४" || cmbVDC_MP.Text == "मग्मा  ५" || cmbVDC_MP.Text == "मग्मा  ६" || cmbVDC_MP.Text == "मग्मा  ७" || cmbVDC_MP.Text == "मग्मा  ८" || cmbVDC_MP.Text == "मग्मा  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "19";
                }
                else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "दूली  १" || cmbVDC_MP.Text == "दूली  २" || cmbVDC_MP.Text == "दूली  ३" || cmbVDC_MP.Text == "दूली  ४" || cmbVDC_MP.Text == "दूली  ५" || cmbVDC_MP.Text == "दूली  ६" || cmbVDC_MP.Text == "दूली  ७" || cmbVDC_MP.Text == "दूली  ८" || cmbVDC_MP.Text == "दूली  ९")
                {
                    txtTestCode.Text = "RUK" + "AB" + "17";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌स्यालाखदी ILLAKAS
                if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "स्यालाखदी  १" || cmbVDC_MP.Text == "स्यालाखदी  २" || cmbVDC_MP.Text == "स्यालाखदी  ३" || cmbVDC_MP.Text == "स्यालाखदी  ४" || cmbVDC_MP.Text == "स्यालाखदी  ५" || cmbVDC_MP.Text == "स्यालाखदी  ६" || cmbVDC_MP.Text == "स्यालाखदी  ७" || cmbVDC_MP.Text == "स्यालाखदी  ८" || cmbVDC_MP.Text == "स्यालाखदी  ९")
                {
                    txtTestCode.Text = "RUK" + "SA" + "27";
                }
                else if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "गोतामकोट  १" || cmbVDC_MP.Text == "गोतामकोट  २" || cmbVDC_MP.Text == "गोतामकोट  ३" || cmbVDC_MP.Text == "गोतामकोट  ४" || cmbVDC_MP.Text == "गोतामकोट  ५" || cmbVDC_MP.Text == "गोतामकोट  ६" || cmbVDC_MP.Text == "गोतामकोट  ७" || cmbVDC_MP.Text == "गोतामकोट  ८" || cmbVDC_MP.Text == "गोतामकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "SA" + "26";
                }
                else if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "सिस्ने  १" || cmbVDC_MP.Text == "सिस्ने  २" || cmbVDC_MP.Text == "सिस्ने  ३" || cmbVDC_MP.Text == "सिस्ने  ४" || cmbVDC_MP.Text == "सिस्ने  ५" || cmbVDC_MP.Text == "सिस्ने  ६" || cmbVDC_MP.Text == "सिस्ने  ७" || cmbVDC_MP.Text == "सिस्ने  ८" || cmbVDC_MP.Text == "सिस्ने  ९")
                {
                    txtTestCode.Text = "RUK" + "SA" + "28";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌प्वाङ ILLAKAS
                if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "प्वाङ  १" || cmbVDC_MP.Text == "प्वाङ  २" || cmbVDC_MP.Text == "प्वाङ  ३" || cmbVDC_MP.Text == "प्वाङ  ४" || cmbVDC_MP.Text == "प्वाङ  ५" || cmbVDC_MP.Text == "प्वाङ  ६" || cmbVDC_MP.Text == "प्वाङ  ७" || cmbVDC_MP.Text == "प्वाङ  ८" || cmbVDC_MP.Text == "प्वाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "24";
                }
                else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "पोखरा  १" || cmbVDC_MP.Text == "पोखरा  २" || cmbVDC_MP.Text == "पोखरा  ३" || cmbVDC_MP.Text == "पोखरा  ४" || cmbVDC_MP.Text == "पोखरा  ५" || cmbVDC_MP.Text == "पोखरा  ६" || cmbVDC_MP.Text == "पोखरा  ७" || cmbVDC_MP.Text == "पोखरा  ८" || cmbVDC_MP.Text == "पोखरा  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "23";
                }
                else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "पिपल  १" || cmbVDC_MP.Text == "पिपल  २" || cmbVDC_MP.Text == "पिपल  ३" || cmbVDC_MP.Text == "पिपल  ४" || cmbVDC_MP.Text == "पिपल  ५" || cmbVDC_MP.Text == "पिपल  ६" || cmbVDC_MP.Text == "पिपल  ७" || cmbVDC_MP.Text == "पिपल  ८" || cmbVDC_MP.Text == "पिपल  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "22";
                }
                else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "बाफिकोट  १" || cmbVDC_MP.Text == "बाफिकोट  २" || cmbVDC_MP.Text == "बाफिकोट  ३" || cmbVDC_MP.Text == "बाफिकोट  ४" || cmbVDC_MP.Text == "बाफिकोट  ५" || cmbVDC_MP.Text == "बाफिकोट  ६" || cmbVDC_MP.Text == "बाफिकोट  ७" || cmbVDC_MP.Text == "बाफिकोट  ८" || cmbVDC_MP.Text == "बाफिकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "21";
                }
                else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "जाङ  १" || cmbVDC_MP.Text == "जाङ  २" || cmbVDC_MP.Text == "जाङ  ३" || cmbVDC_MP.Text == "जाङ  ४" || cmbVDC_MP.Text == "जाङ  ५" || cmbVDC_MP.Text == "जाङ  ६" || cmbVDC_MP.Text == "जाङ  ७" || cmbVDC_MP.Text == "जाङ  ८" || cmbVDC_MP.Text == "जाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "PW" + "25";
                }
                #endregion

                #region//Code TO BE GENERATED  for ‍‌मोरावाङ ILLAKAS
                if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "शोभा  १" || cmbVDC_MP.Text == "शोभा  २" || cmbVDC_MP.Text == "शोभा  ३" || cmbVDC_MP.Text == "शोभा  ४" || cmbVDC_MP.Text == "शोभा  ५" || cmbVDC_MP.Text == "शोभा  ६" || cmbVDC_MP.Text == "शोभा  ७" || cmbVDC_MP.Text == "शोभा  ८" || cmbVDC_MP.Text == "शोभा  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "34";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "रुकूमकोट  १" || cmbVDC_MP.Text == "रुकूमकोट  २" || cmbVDC_MP.Text == "रुकूमकोट  ३" || cmbVDC_MP.Text == "रुकूमकोट  ४" || cmbVDC_MP.Text == "रुकूमकोट  ५" || cmbVDC_MP.Text == "रुकूमकोट  ६" || cmbVDC_MP.Text == "रुकूमकोट  ७" || cmbVDC_MP.Text == "रुकूमकोट  ८" || cmbVDC_MP.Text == "रुकूमकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "34";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "कांडा  १" || cmbVDC_MP.Text == "कांडा  २" || cmbVDC_MP.Text == "कांडा  ३" || cmbVDC_MP.Text == "कांडा  ४" || cmbVDC_MP.Text == "कांडा  ५" || cmbVDC_MP.Text == "कांडा  ६" || cmbVDC_MP.Text == "कांडा  ७" || cmbVDC_MP.Text == "कांडा  ८" || cmbVDC_MP.Text == "कांडा  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "36";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "मोरावाङ  १" || cmbVDC_MP.Text == "मोरावाङ  २" || cmbVDC_MP.Text == "मोरावाङ  ३" || cmbVDC_MP.Text == "मोरावाङ  ४" || cmbVDC_MP.Text == "मोरावाङ  ५" || cmbVDC_MP.Text == "मोरावाङ  ६" || cmbVDC_MP.Text == "मोरावाङ  ७" || cmbVDC_MP.Text == "मोरावाङ  ८" || cmbVDC_MP.Text == "मोरावाङ  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "37";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "महत  १" || cmbVDC_MP.Text == "महत  २" || cmbVDC_MP.Text == "महत  ३" || cmbVDC_MP.Text == "महत  ४" || cmbVDC_MP.Text == "महत  ५" || cmbVDC_MP.Text == "महत  ६" || cmbVDC_MP.Text == "महत  ७" || cmbVDC_MP.Text == "महत  ८" || cmbVDC_MP.Text == "महत  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "35";
                }
                else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "कांत्रि  १" || cmbVDC_MP.Text == "कांत्रि  २" || cmbVDC_MP.Text == "कांत्रि  ३" || cmbVDC_MP.Text == "कांत्रि  ४" || cmbVDC_MP.Text == "कांत्रि  ५" || cmbVDC_MP.Text == "कांत्रि  ६" || cmbVDC_MP.Text == "कांत्रि  ७" || cmbVDC_MP.Text == "कांत्रि  ८" || cmbVDC_MP.Text == "कांत्रि  ९")
                {
                    txtTestCode.Text = "RUK" + "MO" + "38";
                }

                #endregion

                #region//Code TO BE GENERATED  for ‍‌कोल ILLAKAS
                if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "कोल  १" || cmbVDC_MP.Text == "कोल  २" || cmbVDC_MP.Text == "कोल  ३" || cmbVDC_MP.Text == "कोल  ४" || cmbVDC_MP.Text == "कोल  ५" || cmbVDC_MP.Text == "कोल  ६" || cmbVDC_MP.Text == "कोल  ७" || cmbVDC_MP.Text == "कोल  ८" || cmbVDC_MP.Text == "कोल  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "40";
                }
                else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "राङसी  १" || cmbVDC_MP.Text == "राङसी  २" || cmbVDC_MP.Text == "राङसी  ३" || cmbVDC_MP.Text == "राङसी  ४" || cmbVDC_MP.Text == "राङसी  ५" || cmbVDC_MP.Text == "राङसी  ६" || cmbVDC_MP.Text == "राङसी  ७" || cmbVDC_MP.Text == "राङसी  ८" || cmbVDC_MP.Text == "राङसी  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "39";
                }
                else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "तकसेरा  १" || cmbVDC_MP.Text == "तकसेरा  २" || cmbVDC_MP.Text == "तकसेरा  ३" || cmbVDC_MP.Text == "तकसेरा  ४" || cmbVDC_MP.Text == "तकसेरा  ५" || cmbVDC_MP.Text == "तकसेरा  ६" || cmbVDC_MP.Text == "तकसेरा  ७" || cmbVDC_MP.Text == "तकसेरा  ८" || cmbVDC_MP.Text == "तकसेरा  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "41";
                }
                else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "हुकाम  १" || cmbVDC_MP.Text == "हुकाम  २" || cmbVDC_MP.Text == "हुकाम  ३" || cmbVDC_MP.Text == "हुकाम  ४" || cmbVDC_MP.Text == "हुकाम  ५" || cmbVDC_MP.Text == "हुकाम  ६" || cmbVDC_MP.Text == "हुकाम  ७" || cmbVDC_MP.Text == "हुकाम  ८" || cmbVDC_MP.Text == "हुकाम  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "43";
                }
                else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "रन्मामैकोट  १" || cmbVDC_MP.Text == "रन्मामैकोट  २" || cmbVDC_MP.Text == "रन्मामैकोट  ३" || cmbVDC_MP.Text == "रन्मामैकोट  ४" || cmbVDC_MP.Text == "रन्मामैकोट  ५" || cmbVDC_MP.Text == "रन्मामैकोट  ६" || cmbVDC_MP.Text == "महत  ७" || cmbVDC_MP.Text == "रन्मामैकोट  ८" || cmbVDC_MP.Text == "रन्मामैकोट  ९")
                {
                    txtTestCode.Text = "RUK" + "KO" + "42";
                }


                #endregion

                cmd.Parameters.AddWithValue("@CFCodeNo", txtCodeNo.Text);
                cmd.Parameters.AddWithValue("@TestCode", txtTestCode.Text);
                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "Illaka Forest Office And VDC_AccTo_CFUsrGrp Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails ='" + txtFileNo.Text + "'";
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

        private void IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Illaka_FO_And__VDC_Wise_CF_DetailsRecords frm = new Illaka_FO_And__VDC_Wise_CF_DetailsRecords();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            frm.set.Text = "VDC/MP View Records";
            frm.Show();
        }

        private void cmbIllakaName_SelectedIndexChanged(object sender, EventArgs e)
        {

            #region code for खलंगा
            if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "खलंगा  १" || cmbVDC_MP.Text == "खलंगा  २" || cmbVDC_MP.Text == "खलंगा  ३" || cmbVDC_MP.Text == "खलंगा  ४" || cmbVDC_MP.Text == "खलंगा  ५" || cmbVDC_MP.Text == "खलंगा  ६" || cmbVDC_MP.Text == "खलंगा  ७" || cmbVDC_MP.Text == "खलंगा  ८" || cmbVDC_MP.Text == "खलंगा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH31'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "साँख  १" || cmbVDC_MP.Text == "साँख  २" || cmbVDC_MP.Text == "साँख  ३" || cmbVDC_MP.Text == "साँख  ४" || cmbVDC_MP.Text == "साँख  ५" || cmbVDC_MP.Text == "साँख  ६" || cmbVDC_MP.Text == "साँख  ७" || cmbVDC_MP.Text == "साँख  ८" || cmbVDC_MP.Text == "साँख  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH30'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }

            else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "स्यालापाखा  १" || cmbVDC_MP.Text == "स्यालापाखा  २" || cmbVDC_MP.Text == "स्यालापाखा  ३" || cmbVDC_MP.Text == "स्यालापाखा  ४" || cmbVDC_MP.Text == "स्यालापाखा  ५" || cmbVDC_MP.Text == "स्यालापाखा  ६" || cmbVDC_MP.Text == "स्यालापाखा  ७" || cmbVDC_MP.Text == "स्यालापाखा  ८" || cmbVDC_MP.Text == "स्यालापाखा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH32'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "चुनवाङ  १" || cmbVDC_MP.Text == "चुनवाङ  २" || cmbVDC_MP.Text == "चुनवाङ  ३" || cmbVDC_MP.Text == "चुनवाङ  ४" || cmbVDC_MP.Text == "चुनवाङ  ५" || cmbVDC_MP.Text == "चुनवाङ  ६" || cmbVDC_MP.Text == "चुनवाङ  ७" || cmbVDC_MP.Text == "चुनवाङ  ८" || cmbVDC_MP.Text == "चुनवाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH33'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "चौखवाङ  १" || cmbVDC_MP.Text == "चौखवाङ  २" || cmbVDC_MP.Text == "चौखवाङ  ३" || cmbVDC_MP.Text == "चौखवाङ  ४" || cmbVDC_MP.Text == "चौखवाङ  ५" || cmbVDC_MP.Text == "चौखवाङ  ६" || cmbVDC_MP.Text == "चौखवाङ  ७" || cmbVDC_MP.Text == "चौखवाङ  ८" || cmbVDC_MP.Text == "चौखवाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH29'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region Max code for ‍‌रुंघा

            //Code TO BE GENERATED  for ‍‌रुंघा ILLAKAS
            if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "मूरू  १" || cmbVDC_MP.Text == "मूरू  २" || cmbVDC_MP.Text == "मूरू  ३" || cmbVDC_MP.Text == "मूरू  ४" || cmbVDC_MP.Text == "मूरू  ५" || cmbVDC_MP.Text == "मूरू  ६" || cmbVDC_MP.Text == "मूरू  ७" || cmbVDC_MP.Text == "मूरू  ८" || cmbVDC_MP.Text == "मूरू  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU10'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "रुंघा  १" || cmbVDC_MP.Text == "रुंघा  २" || cmbVDC_MP.Text == "रुंघा  ३" || cmbVDC_MP.Text == "रुंघा  ४" || cmbVDC_MP.Text == "रुंघा  ५" || cmbVDC_MP.Text == "रुंघा  ६" || cmbVDC_MP.Text == "रुंघा  ७" || cmbVDC_MP.Text == "रुंघा  ८" || cmbVDC_MP.Text == "रुंघा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU12'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "खारा  १" || cmbVDC_MP.Text == "खारा  २" || cmbVDC_MP.Text == "खारा  ३" || cmbVDC_MP.Text == "खारा  ४" || cmbVDC_MP.Text == "खारा  ५" || cmbVDC_MP.Text == "खारा  ६" || cmbVDC_MP.Text == "खारा  ७" || cmbVDC_MP.Text == "खारा  ८" || cmbVDC_MP.Text == "खारा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU11'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "नुवाकोट  १" || cmbVDC_MP.Text == "नुवाकोट  २" || cmbVDC_MP.Text == "नुवाकोट  ३" || cmbVDC_MP.Text == "नुवाकोट  ४" || cmbVDC_MP.Text == "नुवाकोट  ५" || cmbVDC_MP.Text == "नुवाकोट  ६" || cmbVDC_MP.Text == "नुवाकोट  ७" || cmbVDC_MP.Text == "नुवाकोट  ८" || cmbVDC_MP.Text == "नुवाकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU07'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "पेउघा  १" || cmbVDC_MP.Text == "पेउघा  २" || cmbVDC_MP.Text == "पेउघा  ३" || cmbVDC_MP.Text == "पेउघा  ४" || cmbVDC_MP.Text == "पेउघा  ५" || cmbVDC_MP.Text == "पेउघा  ६" || cmbVDC_MP.Text == "पेउघा  ७" || cmbVDC_MP.Text == "पेउघा  ८" || cmbVDC_MP.Text == "पेउघा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU08'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "छिवाङ  १" || cmbVDC_MP.Text == "छिवाङ  २" || cmbVDC_MP.Text == "छिवाङ  ३" || cmbVDC_MP.Text == "छिवाङ  ४" || cmbVDC_MP.Text == "छिवाङ  ५" || cmbVDC_MP.Text == "छिवाङ  ६" || cmbVDC_MP.Text == "छिवाङ  ७" || cmbVDC_MP.Text == "छिवाङ  ८" || cmbVDC_MP.Text == "छिवाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU09'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "भलाक्चा  १" || cmbVDC_MP.Text == "भलाक्चा  २" || cmbVDC_MP.Text == "भलाक्चा  ३" || cmbVDC_MP.Text == "भलाक्चा  ४" || cmbVDC_MP.Text == "भलाक्चा  ५" || cmbVDC_MP.Text == "भलाक्चा  ६" || cmbVDC_MP.Text == "भलाक्चा  ७" || cmbVDC_MP.Text == "भलाक्चा  ८" || cmbVDC_MP.Text == "भलाक्चा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU13'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }

            #endregion

            #region Max code for खोलागाउँ
            //Code TO BE GENERATED  for ‍‌खोलागाउँ ILLAKAS
            if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "खोलागाउँ  १" || cmbVDC_MP.Text == "खोलागाउँ  २" || cmbVDC_MP.Text == "खोलागाउँ  ३" || cmbVDC_MP.Text == "खोलागाउँ  ४" || cmbVDC_MP.Text == "खोलागाउँ  ५" || cmbVDC_MP.Text == "खोलागाउँ  ६" || cmbVDC_MP.Text == "खोलागाउँ  ७" || cmbVDC_MP.Text == "खोलागाउँ  ८" || cmbVDC_MP.Text == "खोलागाउँ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH04'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "बिजयश्योरी  १" || cmbVDC_MP.Text == "बिजयश्योरी  २" || cmbVDC_MP.Text == "बिजयश्योरी  ३" || cmbVDC_MP.Text == "बिजयश्योरी  ४" || cmbVDC_MP.Text == "बिजयश्योरी  ५" || cmbVDC_MP.Text == "बिजयश्योरी  ६" || cmbVDC_MP.Text == "बिजयश्योरी  ७" || cmbVDC_MP.Text == "बिजयश्योरी  ८" || cmbVDC_MP.Text == "बिजयश्योरी  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH01'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "कोटजहारी  १" || cmbVDC_MP.Text == "कोटजहारी  २" || cmbVDC_MP.Text == "कोटजहारी  ३" || cmbVDC_MP.Text == "कोटजहारी  ४" || cmbVDC_MP.Text == "कोटजहारी  ५" || cmbVDC_MP.Text == "कोटजहारी  ६" || cmbVDC_MP.Text == "कोटजहारी  ७" || cmbVDC_MP.Text == "कोटजहारी  ८" || cmbVDC_MP.Text == "कोटजहारी  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH02'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "पूतिेमकांडा  १" || cmbVDC_MP.Text == "पूतिेमकांडा  २" || cmbVDC_MP.Text == "पूतिेमकांडा  ३" || cmbVDC_MP.Text == "पूतिेमकांडा  ४" || cmbVDC_MP.Text == "पूतिेमकांडा  ५" || cmbVDC_MP.Text == "पूतिेमकांडा  ६" || cmbVDC_MP.Text == "पूतिेमकांडा  ७" || cmbVDC_MP.Text == "पूतिेमकांडा  ८" || cmbVDC_MP.Text == "पूतिेमकांडा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH03'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "अर्मा  १" || cmbVDC_MP.Text == "अर्मा  २" || cmbVDC_MP.Text == "अर्मा  ३" || cmbVDC_MP.Text == "अर्मा  ४" || cmbVDC_MP.Text == "अर्मा  ५" || cmbVDC_MP.Text == "अर्मा  ६" || cmbVDC_MP.Text == "अर्मा  ७" || cmbVDC_MP.Text == "अर्मा  ८" || cmbVDC_MP.Text == "अर्मा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH06'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "सिम्ली  १" || cmbVDC_MP.Text == "सिम्ली  २" || cmbVDC_MP.Text == "सिम्ली  ३" || cmbVDC_MP.Text == "सिम्ली  ४" || cmbVDC_MP.Text == "सिम्ली  ५" || cmbVDC_MP.Text == "सिम्ली  ६" || cmbVDC_MP.Text == "सिम्ली  ७" || cmbVDC_MP.Text == "सिम्ली  ८" || cmbVDC_MP.Text == "सिम्ली  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH05'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region  Max code for आठविसकोट
            //Code TO BE GENERATED  for ‍‌आठविसकोट ILLAKAS
            if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "आठविसकोट  १" || cmbVDC_MP.Text == "आठविसकोट  २" || cmbVDC_MP.Text == "आठविसकोट  ३" || cmbVDC_MP.Text == "आठविसकोट  ४" || cmbVDC_MP.Text == "आठविसकोट  ५" || cmbVDC_MP.Text == "आठविसकोट  ६" || cmbVDC_MP.Text == "आठविसकोट  ७" || cmbVDC_MP.Text == "आठविसकोट  ८" || cmbVDC_MP.Text == "आठविसकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB20'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "घेत्मा  १" || cmbVDC_MP.Text == "घेत्मा  २" || cmbVDC_MP.Text == "घेत्मा  ३" || cmbVDC_MP.Text == "घेत्मा  ४" || cmbVDC_MP.Text == "घेत्मा  ५" || cmbVDC_MP.Text == "घेत्मा  ६" || cmbVDC_MP.Text == "घेत्मा  ७" || cmbVDC_MP.Text == "घेत्मा  ८" || cmbVDC_MP.Text == "घेत्मा  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB15'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "आठविसडांडा गाऊं  १" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  २" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ३" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ४" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ५" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ६" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ७" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ८" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB16'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "गरायला  १" || cmbVDC_MP.Text == "गरायला  २" || cmbVDC_MP.Text == "गरायला  ३" || cmbVDC_MP.Text == "गरायला  ४" || cmbVDC_MP.Text == "गरायला  ५" || cmbVDC_MP.Text == "गरायला  ६" || cmbVDC_MP.Text == "गरायला  ७" || cmbVDC_MP.Text == "गरायला  ८" || cmbVDC_MP.Text == "गरायला  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB14'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "झूला  १" || cmbVDC_MP.Text == "झूला  २" || cmbVDC_MP.Text == "झूला  ३" || cmbVDC_MP.Text == "झूला  ४" || cmbVDC_MP.Text == "झूला  ५" || cmbVDC_MP.Text == "झूला  ६" || cmbVDC_MP.Text == "झूला  ७" || cmbVDC_MP.Text == "झूला  ८" || cmbVDC_MP.Text == "झूला  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB18'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "मग्मा  १" || cmbVDC_MP.Text == "मग्मा  २" || cmbVDC_MP.Text == "मग्मा  ३" || cmbVDC_MP.Text == "मग्मा  ४" || cmbVDC_MP.Text == "मग्मा  ५" || cmbVDC_MP.Text == "मग्मा  ६" || cmbVDC_MP.Text == "मग्मा  ७" || cmbVDC_MP.Text == "मग्मा  ८" || cmbVDC_MP.Text == "मग्मा  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB19'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "दूली  १" || cmbVDC_MP.Text == "दूली  २" || cmbVDC_MP.Text == "दूली  ३" || cmbVDC_MP.Text == "दूली  ४" || cmbVDC_MP.Text == "दूली  ५" || cmbVDC_MP.Text == "दूली  ६" || cmbVDC_MP.Text == "दूली  ७" || cmbVDC_MP.Text == "दूली  ८" || cmbVDC_MP.Text == "दूली  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB17'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region  Max code for स्यालाखदी
            //Code TO BE GENERATED  for ‍‌स्यालाखदी ILLAKAS
            if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "स्यालाखदी  १" || cmbVDC_MP.Text == "स्यालाखदी  २" || cmbVDC_MP.Text == "स्यालाखदी  ३" || cmbVDC_MP.Text == "स्यालाखदी  ४" || cmbVDC_MP.Text == "स्यालाखदी  ५" || cmbVDC_MP.Text == "स्यालाखदी  ६" || cmbVDC_MP.Text == "स्यालाखदी  ७" || cmbVDC_MP.Text == "स्यालाखदी  ८" || cmbVDC_MP.Text == "स्यालाखदी  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSA27'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "गोतामकोट  १" || cmbVDC_MP.Text == "गोतामकोट  २" || cmbVDC_MP.Text == "गोतामकोट  ३" || cmbVDC_MP.Text == "गोतामकोट  ४" || cmbVDC_MP.Text == "गोतामकोट  ५" || cmbVDC_MP.Text == "गोतामकोट  ६" || cmbVDC_MP.Text == "गोतामकोट  ७" || cmbVDC_MP.Text == "गोतामकोट  ८" || cmbVDC_MP.Text == "गोतामकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSA26'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "सिस्ने  १" || cmbVDC_MP.Text == "सिस्ने  २" || cmbVDC_MP.Text == "सिस्ने  ३" || cmbVDC_MP.Text == "सिस्ने  ४" || cmbVDC_MP.Text == "सिस्ने  ५" || cmbVDC_MP.Text == "सिस्ने  ६" || cmbVDC_MP.Text == "सिस्ने  ७" || cmbVDC_MP.Text == "सिस्ने  ८" || cmbVDC_MP.Text == "सिस्ने  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSA28'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region Max code FOR प्वाङ
            //Code TO BE GENERATED  for ‍‌प्वाङ ILLAKAS
            if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "प्वाङ  १" || cmbVDC_MP.Text == "प्वाङ  २" || cmbVDC_MP.Text == "प्वाङ  ३" || cmbVDC_MP.Text == "प्वाङ  ४" || cmbVDC_MP.Text == "प्वाङ  ५" || cmbVDC_MP.Text == "प्वाङ  ६" || cmbVDC_MP.Text == "प्वाङ  ७" || cmbVDC_MP.Text == "प्वाङ  ८" || cmbVDC_MP.Text == "प्वाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW24'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "पोखरा  १" || cmbVDC_MP.Text == "पोखरा  २" || cmbVDC_MP.Text == "पोखरा  ३" || cmbVDC_MP.Text == "पोखरा  ४" || cmbVDC_MP.Text == "पोखरा  ५" || cmbVDC_MP.Text == "पोखरा  ६" || cmbVDC_MP.Text == "पोखरा  ७" || cmbVDC_MP.Text == "पोखरा  ८" || cmbVDC_MP.Text == "पोखरा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW23'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "पिपल  १" || cmbVDC_MP.Text == "पिपल  २" || cmbVDC_MP.Text == "पिपल  ३" || cmbVDC_MP.Text == "पिपल  ४" || cmbVDC_MP.Text == "पिपल  ५" || cmbVDC_MP.Text == "पिपल  ६" || cmbVDC_MP.Text == "पिपल  ७" || cmbVDC_MP.Text == "पिपल  ८" || cmbVDC_MP.Text == "पिपल  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW22'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "बाफिकोट  १" || cmbVDC_MP.Text == "बाफिकोट  २" || cmbVDC_MP.Text == "बाफिकोट  ३" || cmbVDC_MP.Text == "बाफिकोट  ४" || cmbVDC_MP.Text == "बाफिकोट  ५" || cmbVDC_MP.Text == "बाफिकोट  ६" || cmbVDC_MP.Text == "बाफिकोट  ७" || cmbVDC_MP.Text == "बाफिकोट  ८" || cmbVDC_MP.Text == "बाफिकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW21'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "जाङ  १" || cmbVDC_MP.Text == "जाङ  २" || cmbVDC_MP.Text == "जाङ  ३" || cmbVDC_MP.Text == "जाङ  ४" || cmbVDC_MP.Text == "जाङ  ५" || cmbVDC_MP.Text == "जाङ  ६" || cmbVDC_MP.Text == "जाङ  ७" || cmbVDC_MP.Text == "जाङ  ८" || cmbVDC_MP.Text == "जाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW25'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region Max code FOR मोरावाङ
            //Code TO BE GENERATED  for ‍‌मोरावाङ ILLAKAS
            if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "शोभा  १" || cmbVDC_MP.Text == "शोभा  २" || cmbVDC_MP.Text == "शोभा  ३" || cmbVDC_MP.Text == "शोभा  ४" || cmbVDC_MP.Text == "शोभा  ५" || cmbVDC_MP.Text == "शोभा  ६" || cmbVDC_MP.Text == "शोभा  ७" || cmbVDC_MP.Text == "शोभा  ८" || cmbVDC_MP.Text == "शोभा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO34'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "रुकूमकोट  १" || cmbVDC_MP.Text == "रुकूमकोट  २" || cmbVDC_MP.Text == "रुकूमकोट  ३" || cmbVDC_MP.Text == "रुकूमकोट  ४" || cmbVDC_MP.Text == "रुकूमकोट  ५" || cmbVDC_MP.Text == "रुकूमकोट  ६" || cmbVDC_MP.Text == "रुकूमकोट  ७" || cmbVDC_MP.Text == "रुकूमकोट  ८" || cmbVDC_MP.Text == "रुकूमकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO34'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "कांडा  १" || cmbVDC_MP.Text == "कांडा  २" || cmbVDC_MP.Text == "कांडा  ३" || cmbVDC_MP.Text == "कांडा  ४" || cmbVDC_MP.Text == "कांडा  ५" || cmbVDC_MP.Text == "कांडा  ६" || cmbVDC_MP.Text == "कांडा  ७" || cmbVDC_MP.Text == "कांडा  ८" || cmbVDC_MP.Text == "कांडा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO36'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "मोरावाङ  १" || cmbVDC_MP.Text == "मोरावाङ  २" || cmbVDC_MP.Text == "मोरावाङ  ३" || cmbVDC_MP.Text == "मोरावाङ  ४" || cmbVDC_MP.Text == "मोरावाङ  ५" || cmbVDC_MP.Text == "मोरावाङ  ६" || cmbVDC_MP.Text == "मोरावाङ  ७" || cmbVDC_MP.Text == "मोरावाङ  ८" || cmbVDC_MP.Text == "मोरावाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO37'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "महत  १" || cmbVDC_MP.Text == "महत  २" || cmbVDC_MP.Text == "महत  ३" || cmbVDC_MP.Text == "महत  ४" || cmbVDC_MP.Text == "महत  ५" || cmbVDC_MP.Text == "महत  ६" || cmbVDC_MP.Text == "महत  ७" || cmbVDC_MP.Text == "महत  ८" || cmbVDC_MP.Text == "महत  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO35'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "कांत्रि  १" || cmbVDC_MP.Text == "कांत्रि  २" || cmbVDC_MP.Text == "कांत्रि  ३" || cmbVDC_MP.Text == "कांत्रि  ४" || cmbVDC_MP.Text == "कांत्रि  ५" || cmbVDC_MP.Text == "कांत्रि  ६" || cmbVDC_MP.Text == "कांत्रि  ७" || cmbVDC_MP.Text == "कांत्रि  ८" || cmbVDC_MP.Text == "कांत्रि  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO38'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }

            #endregion

            #region  Max code FOR कोल
            //Code TO BE GENERATED  for ‍‌कोल ILLAKAS
            if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "कोल  १" || cmbVDC_MP.Text == "कोल  २" || cmbVDC_MP.Text == "कोल  ३" || cmbVDC_MP.Text == "कोल  ४" || cmbVDC_MP.Text == "कोल  ५" || cmbVDC_MP.Text == "कोल  ६" || cmbVDC_MP.Text == "कोल  ७" || cmbVDC_MP.Text == "कोल  ८" || cmbVDC_MP.Text == "कोल  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO40'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "राङसी  १" || cmbVDC_MP.Text == "राङसी  २" || cmbVDC_MP.Text == "राङसी  ३" || cmbVDC_MP.Text == "राङसी  ४" || cmbVDC_MP.Text == "राङसी  ५" || cmbVDC_MP.Text == "राङसी  ६" || cmbVDC_MP.Text == "राङसी  ७" || cmbVDC_MP.Text == "राङसी  ८" || cmbVDC_MP.Text == "राङसी  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO39'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "तकसेरा  १" || cmbVDC_MP.Text == "तकसेरा  २" || cmbVDC_MP.Text == "तकसेरा  ३" || cmbVDC_MP.Text == "तकसेरा  ४" || cmbVDC_MP.Text == "तकसेरा  ५" || cmbVDC_MP.Text == "तकसेरा  ६" || cmbVDC_MP.Text == "तकसेरा  ७" || cmbVDC_MP.Text == "तकसेरा  ८" || cmbVDC_MP.Text == "तकसेरा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO41'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "हुकाम  १" || cmbVDC_MP.Text == "हुकाम  २" || cmbVDC_MP.Text == "हुकाम  ३" || cmbVDC_MP.Text == "हुकाम  ४" || cmbVDC_MP.Text == "हुकाम  ५" || cmbVDC_MP.Text == "हुकाम  ६" || cmbVDC_MP.Text == "हुकाम  ७" || cmbVDC_MP.Text == "हुकाम  ८" || cmbVDC_MP.Text == "हुकाम  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO43'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "रन्मामैकोट  १" || cmbVDC_MP.Text == "रन्मामैकोट  २" || cmbVDC_MP.Text == "रन्मामैकोट  ३" || cmbVDC_MP.Text == "रन्मामैकोट  ४" || cmbVDC_MP.Text == "रन्मामैकोट  ५" || cmbVDC_MP.Text == "रन्मामैकोट  ६" || cmbVDC_MP.Text == "महत  ७" || cmbVDC_MP.Text == "रन्मामैकोट  ८" || cmbVDC_MP.Text == "रन्मामैकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO42'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }


            #endregion
        }

        private void cmbVDC_MP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region code for खलंगा
            if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "खलंगा  १" || cmbVDC_MP.Text == "खलंगा  २" || cmbVDC_MP.Text == "खलंगा  ३" || cmbVDC_MP.Text == "खलंगा  ४" || cmbVDC_MP.Text == "खलंगा  ५" || cmbVDC_MP.Text == "खलंगा  ६" || cmbVDC_MP.Text == "खलंगा  ७" || cmbVDC_MP.Text == "खलंगा  ८" || cmbVDC_MP.Text == "खलंगा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH31'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "साँख  १" || cmbVDC_MP.Text == "साँख  २" || cmbVDC_MP.Text == "साँख  ३" || cmbVDC_MP.Text == "साँख  ४" || cmbVDC_MP.Text == "साँख  ५" || cmbVDC_MP.Text == "साँख  ६" || cmbVDC_MP.Text == "साँख  ७" || cmbVDC_MP.Text == "साँख  ८" || cmbVDC_MP.Text == "साँख  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH30'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }

            else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "स्यालापाखा  १" || cmbVDC_MP.Text == "स्यालापाखा  २" || cmbVDC_MP.Text == "स्यालापाखा  ३" || cmbVDC_MP.Text == "स्यालापाखा  ४" || cmbVDC_MP.Text == "स्यालापाखा  ५" || cmbVDC_MP.Text == "स्यालापाखा  ६" || cmbVDC_MP.Text == "स्यालापाखा  ७" || cmbVDC_MP.Text == "स्यालापाखा  ८" || cmbVDC_MP.Text == "स्यालापाखा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH32'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "चुनवाङ  १" || cmbVDC_MP.Text == "चुनवाङ  २" || cmbVDC_MP.Text == "चुनवाङ  ३" || cmbVDC_MP.Text == "चुनवाङ  ४" || cmbVDC_MP.Text == "चुनवाङ  ५" || cmbVDC_MP.Text == "चुनवाङ  ६" || cmbVDC_MP.Text == "चुनवाङ  ७" || cmbVDC_MP.Text == "चुनवाङ  ८" || cmbVDC_MP.Text == "चुनवाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH33'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "साँख" && cmbVDC_MP.Text == "चौखवाङ  १" || cmbVDC_MP.Text == "चौखवाङ  २" || cmbVDC_MP.Text == "चौखवाङ  ३" || cmbVDC_MP.Text == "चौखवाङ  ४" || cmbVDC_MP.Text == "चौखवाङ  ५" || cmbVDC_MP.Text == "चौखवाङ  ६" || cmbVDC_MP.Text == "चौखवाङ  ७" || cmbVDC_MP.Text == "चौखवाङ  ८" || cmbVDC_MP.Text == "चौखवाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSH29'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region Max code for ‍‌रुंघा

            //Code TO BE GENERATED  for ‍‌रुंघा ILLAKAS
            if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "मूरू  १" || cmbVDC_MP.Text == "मूरू  २" || cmbVDC_MP.Text == "मूरू  ३" || cmbVDC_MP.Text == "मूरू  ४" || cmbVDC_MP.Text == "मूरू  ५" || cmbVDC_MP.Text == "मूरू  ६" || cmbVDC_MP.Text == "मूरू  ७" || cmbVDC_MP.Text == "मूरू  ८" || cmbVDC_MP.Text == "मूरू  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU10'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "रुंघा  १" || cmbVDC_MP.Text == "रुंघा  २" || cmbVDC_MP.Text == "रुंघा  ३" || cmbVDC_MP.Text == "रुंघा  ४" || cmbVDC_MP.Text == "रुंघा  ५" || cmbVDC_MP.Text == "रुंघा  ६" || cmbVDC_MP.Text == "रुंघा  ७" || cmbVDC_MP.Text == "रुंघा  ८" || cmbVDC_MP.Text == "रुंघा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU12'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "खारा  १" || cmbVDC_MP.Text == "खारा  २" || cmbVDC_MP.Text == "खारा  ३" || cmbVDC_MP.Text == "खारा  ४" || cmbVDC_MP.Text == "खारा  ५" || cmbVDC_MP.Text == "खारा  ६" || cmbVDC_MP.Text == "खारा  ७" || cmbVDC_MP.Text == "खारा  ८" || cmbVDC_MP.Text == "खारा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU11'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "नुवाकोट  १" || cmbVDC_MP.Text == "नुवाकोट  २" || cmbVDC_MP.Text == "नुवाकोट  ३" || cmbVDC_MP.Text == "नुवाकोट  ४" || cmbVDC_MP.Text == "नुवाकोट  ५" || cmbVDC_MP.Text == "नुवाकोट  ६" || cmbVDC_MP.Text == "नुवाकोट  ७" || cmbVDC_MP.Text == "नुवाकोट  ८" || cmbVDC_MP.Text == "नुवाकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU07'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "पेउघा  १" || cmbVDC_MP.Text == "पेउघा  २" || cmbVDC_MP.Text == "पेउघा  ३" || cmbVDC_MP.Text == "पेउघा  ४" || cmbVDC_MP.Text == "पेउघा  ५" || cmbVDC_MP.Text == "पेउघा  ६" || cmbVDC_MP.Text == "पेउघा  ७" || cmbVDC_MP.Text == "पेउघा  ८" || cmbVDC_MP.Text == "पेउघा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU08'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "छिवाङ  १" || cmbVDC_MP.Text == "छिवाङ  २" || cmbVDC_MP.Text == "छिवाङ  ३" || cmbVDC_MP.Text == "छिवाङ  ४" || cmbVDC_MP.Text == "छिवाङ  ५" || cmbVDC_MP.Text == "छिवाङ  ६" || cmbVDC_MP.Text == "छिवाङ  ७" || cmbVDC_MP.Text == "छिवाङ  ८" || cmbVDC_MP.Text == "छिवाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU09'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "रुंघा" && cmbVDC_MP.Text == "भलाक्चा  १" || cmbVDC_MP.Text == "भलाक्चा  २" || cmbVDC_MP.Text == "भलाक्चा  ३" || cmbVDC_MP.Text == "भलाक्चा  ४" || cmbVDC_MP.Text == "भलाक्चा  ५" || cmbVDC_MP.Text == "भलाक्चा  ६" || cmbVDC_MP.Text == "भलाक्चा  ७" || cmbVDC_MP.Text == "भलाक्चा  ८" || cmbVDC_MP.Text == "भलाक्चा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKRU13'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }

            #endregion

            #region Max code for खोलागाउँ
            //Code TO BE GENERATED  for ‍‌खोलागाउँ ILLAKAS
            if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "खोलागाउँ  १" || cmbVDC_MP.Text == "खोलागाउँ  २" || cmbVDC_MP.Text == "खोलागाउँ  ३" || cmbVDC_MP.Text == "खोलागाउँ  ४" || cmbVDC_MP.Text == "खोलागाउँ  ५" || cmbVDC_MP.Text == "खोलागाउँ  ६" || cmbVDC_MP.Text == "खोलागाउँ  ७" || cmbVDC_MP.Text == "खोलागाउँ  ८" || cmbVDC_MP.Text == "खोलागाउँ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH04'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "बिजयश्योरी  १" || cmbVDC_MP.Text == "बिजयश्योरी  २" || cmbVDC_MP.Text == "बिजयश्योरी  ३" || cmbVDC_MP.Text == "बिजयश्योरी  ४" || cmbVDC_MP.Text == "बिजयश्योरी  ५" || cmbVDC_MP.Text == "बिजयश्योरी  ६" || cmbVDC_MP.Text == "बिजयश्योरी  ७" || cmbVDC_MP.Text == "बिजयश्योरी  ८" || cmbVDC_MP.Text == "बिजयश्योरी  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH01'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "कोटजहारी  १" || cmbVDC_MP.Text == "कोटजहारी  २" || cmbVDC_MP.Text == "कोटजहारी  ३" || cmbVDC_MP.Text == "कोटजहारी  ४" || cmbVDC_MP.Text == "कोटजहारी  ५" || cmbVDC_MP.Text == "कोटजहारी  ६" || cmbVDC_MP.Text == "कोटजहारी  ७" || cmbVDC_MP.Text == "कोटजहारी  ८" || cmbVDC_MP.Text == "कोटजहारी  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH02'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "पूतिेमकांडा  १" || cmbVDC_MP.Text == "पूतिेमकांडा  २" || cmbVDC_MP.Text == "पूतिेमकांडा  ३" || cmbVDC_MP.Text == "पूतिेमकांडा  ४" || cmbVDC_MP.Text == "पूतिेमकांडा  ५" || cmbVDC_MP.Text == "पूतिेमकांडा  ६" || cmbVDC_MP.Text == "पूतिेमकांडा  ७" || cmbVDC_MP.Text == "पूतिेमकांडा  ८" || cmbVDC_MP.Text == "पूतिेमकांडा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH03'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "अर्मा  १" || cmbVDC_MP.Text == "अर्मा  २" || cmbVDC_MP.Text == "अर्मा  ३" || cmbVDC_MP.Text == "अर्मा  ४" || cmbVDC_MP.Text == "अर्मा  ५" || cmbVDC_MP.Text == "अर्मा  ६" || cmbVDC_MP.Text == "अर्मा  ७" || cmbVDC_MP.Text == "अर्मा  ८" || cmbVDC_MP.Text == "अर्मा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH06'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "खोलागाउँ" && cmbVDC_MP.Text == "सिम्ली  १" || cmbVDC_MP.Text == "सिम्ली  २" || cmbVDC_MP.Text == "सिम्ली  ३" || cmbVDC_MP.Text == "सिम्ली  ४" || cmbVDC_MP.Text == "सिम्ली  ५" || cmbVDC_MP.Text == "सिम्ली  ६" || cmbVDC_MP.Text == "सिम्ली  ७" || cmbVDC_MP.Text == "सिम्ली  ८" || cmbVDC_MP.Text == "सिम्ली  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKH05'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region  Max code for आठविसकोट
            //Code TO BE GENERATED  for ‍‌आठविसकोट ILLAKAS
            if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "आठविसकोट  १" || cmbVDC_MP.Text == "आठविसकोट  २" || cmbVDC_MP.Text == "आठविसकोट  ३" || cmbVDC_MP.Text == "आठविसकोट  ४" || cmbVDC_MP.Text == "आठविसकोट  ५" || cmbVDC_MP.Text == "आठविसकोट  ६" || cmbVDC_MP.Text == "आठविसकोट  ७" || cmbVDC_MP.Text == "आठविसकोट  ८" || cmbVDC_MP.Text == "आठविसकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB20'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "घेत्मा  १" || cmbVDC_MP.Text == "घेत्मा  २" || cmbVDC_MP.Text == "घेत्मा  ३" || cmbVDC_MP.Text == "घेत्मा  ४" || cmbVDC_MP.Text == "घेत्मा  ५" || cmbVDC_MP.Text == "घेत्मा  ६" || cmbVDC_MP.Text == "घेत्मा  ७" || cmbVDC_MP.Text == "घेत्मा  ८" || cmbVDC_MP.Text == "घेत्मा  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB15'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "आठविसडांडा गाऊं  १" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  २" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ३" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ४" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ५" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ६" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ७" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ८" || cmbVDC_MP.Text == "आठविसडांडा गाऊं  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB16'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "गरायला  १" || cmbVDC_MP.Text == "गरायला  २" || cmbVDC_MP.Text == "गरायला  ३" || cmbVDC_MP.Text == "गरायला  ४" || cmbVDC_MP.Text == "गरायला  ५" || cmbVDC_MP.Text == "गरायला  ६" || cmbVDC_MP.Text == "गरायला  ७" || cmbVDC_MP.Text == "गरायला  ८" || cmbVDC_MP.Text == "गरायला  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB14'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "झूला  १" || cmbVDC_MP.Text == "झूला  २" || cmbVDC_MP.Text == "झूला  ३" || cmbVDC_MP.Text == "झूला  ४" || cmbVDC_MP.Text == "झूला  ५" || cmbVDC_MP.Text == "झूला  ६" || cmbVDC_MP.Text == "झूला  ७" || cmbVDC_MP.Text == "झूला  ८" || cmbVDC_MP.Text == "झूला  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB18'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "मग्मा  १" || cmbVDC_MP.Text == "मग्मा  २" || cmbVDC_MP.Text == "मग्मा  ३" || cmbVDC_MP.Text == "मग्मा  ४" || cmbVDC_MP.Text == "मग्मा  ५" || cmbVDC_MP.Text == "मग्मा  ६" || cmbVDC_MP.Text == "मग्मा  ७" || cmbVDC_MP.Text == "मग्मा  ८" || cmbVDC_MP.Text == "मग्मा  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB19'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "आठविसकोट" && cmbVDC_MP.Text == "दूली  १" || cmbVDC_MP.Text == "दूली  २" || cmbVDC_MP.Text == "दूली  ३" || cmbVDC_MP.Text == "दूली  ४" || cmbVDC_MP.Text == "दूली  ५" || cmbVDC_MP.Text == "दूली  ६" || cmbVDC_MP.Text == "दूली  ७" || cmbVDC_MP.Text == "दूली  ८" || cmbVDC_MP.Text == "दूली  ९")
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKAB17'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region  Max code for स्यालाखदी
            //Code TO BE GENERATED  for ‍‌स्यालाखदी ILLAKAS
            if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "स्यालाखदी  १" || cmbVDC_MP.Text == "स्यालाखदी  २" || cmbVDC_MP.Text == "स्यालाखदी  ३" || cmbVDC_MP.Text == "स्यालाखदी  ४" || cmbVDC_MP.Text == "स्यालाखदी  ५" || cmbVDC_MP.Text == "स्यालाखदी  ६" || cmbVDC_MP.Text == "स्यालाखदी  ७" || cmbVDC_MP.Text == "स्यालाखदी  ८" || cmbVDC_MP.Text == "स्यालाखदी  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSA27'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "गोतामकोट  १" || cmbVDC_MP.Text == "गोतामकोट  २" || cmbVDC_MP.Text == "गोतामकोट  ३" || cmbVDC_MP.Text == "गोतामकोट  ४" || cmbVDC_MP.Text == "गोतामकोट  ५" || cmbVDC_MP.Text == "गोतामकोट  ६" || cmbVDC_MP.Text == "गोतामकोट  ७" || cmbVDC_MP.Text == "गोतामकोट  ८" || cmbVDC_MP.Text == "गोतामकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSA26'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "स्यालाखदी" && cmbVDC_MP.Text == "सिस्ने  १" || cmbVDC_MP.Text == "सिस्ने  २" || cmbVDC_MP.Text == "सिस्ने  ३" || cmbVDC_MP.Text == "सिस्ने  ४" || cmbVDC_MP.Text == "सिस्ने  ५" || cmbVDC_MP.Text == "सिस्ने  ६" || cmbVDC_MP.Text == "सिस्ने  ७" || cmbVDC_MP.Text == "सिस्ने  ८" || cmbVDC_MP.Text == "सिस्ने  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKSA28'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region Max code FOR प्वाङ
            //Code TO BE GENERATED  for ‍‌प्वाङ ILLAKAS
            if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "प्वाङ  १" || cmbVDC_MP.Text == "प्वाङ  २" || cmbVDC_MP.Text == "प्वाङ  ३" || cmbVDC_MP.Text == "प्वाङ  ४" || cmbVDC_MP.Text == "प्वाङ  ५" || cmbVDC_MP.Text == "प्वाङ  ६" || cmbVDC_MP.Text == "प्वाङ  ७" || cmbVDC_MP.Text == "प्वाङ  ८" || cmbVDC_MP.Text == "प्वाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW24'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "पोखरा  १" || cmbVDC_MP.Text == "पोखरा  २" || cmbVDC_MP.Text == "पोखरा  ३" || cmbVDC_MP.Text == "पोखरा  ४" || cmbVDC_MP.Text == "पोखरा  ५" || cmbVDC_MP.Text == "पोखरा  ६" || cmbVDC_MP.Text == "पोखरा  ७" || cmbVDC_MP.Text == "पोखरा  ८" || cmbVDC_MP.Text == "पोखरा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW23'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "पिपल  १" || cmbVDC_MP.Text == "पिपल  २" || cmbVDC_MP.Text == "पिपल  ३" || cmbVDC_MP.Text == "पिपल  ४" || cmbVDC_MP.Text == "पिपल  ५" || cmbVDC_MP.Text == "पिपल  ६" || cmbVDC_MP.Text == "पिपल  ७" || cmbVDC_MP.Text == "पिपल  ८" || cmbVDC_MP.Text == "पिपल  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW22'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "बाफिकोट  १" || cmbVDC_MP.Text == "बाफिकोट  २" || cmbVDC_MP.Text == "बाफिकोट  ३" || cmbVDC_MP.Text == "बाफिकोट  ४" || cmbVDC_MP.Text == "बाफिकोट  ५" || cmbVDC_MP.Text == "बाफिकोट  ६" || cmbVDC_MP.Text == "बाफिकोट  ७" || cmbVDC_MP.Text == "बाफिकोट  ८" || cmbVDC_MP.Text == "बाफिकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW21'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "प्वाङ" && cmbVDC_MP.Text == "जाङ  १" || cmbVDC_MP.Text == "जाङ  २" || cmbVDC_MP.Text == "जाङ  ३" || cmbVDC_MP.Text == "जाङ  ४" || cmbVDC_MP.Text == "जाङ  ५" || cmbVDC_MP.Text == "जाङ  ६" || cmbVDC_MP.Text == "जाङ  ७" || cmbVDC_MP.Text == "जाङ  ८" || cmbVDC_MP.Text == "जाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKPW25'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            #endregion

            #region Max code FOR मोरावाङ
            //Code TO BE GENERATED  for ‍‌मोरावाङ ILLAKAS
            if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "शोभा  १" || cmbVDC_MP.Text == "शोभा  २" || cmbVDC_MP.Text == "शोभा  ३" || cmbVDC_MP.Text == "शोभा  ४" || cmbVDC_MP.Text == "शोभा  ५" || cmbVDC_MP.Text == "शोभा  ६" || cmbVDC_MP.Text == "शोभा  ७" || cmbVDC_MP.Text == "शोभा  ८" || cmbVDC_MP.Text == "शोभा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO34'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "रुकूमकोट  १" || cmbVDC_MP.Text == "रुकूमकोट  २" || cmbVDC_MP.Text == "रुकूमकोट  ३" || cmbVDC_MP.Text == "रुकूमकोट  ४" || cmbVDC_MP.Text == "रुकूमकोट  ५" || cmbVDC_MP.Text == "रुकूमकोट  ६" || cmbVDC_MP.Text == "रुकूमकोट  ७" || cmbVDC_MP.Text == "रुकूमकोट  ८" || cmbVDC_MP.Text == "रुकूमकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO34'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "कांडा  १" || cmbVDC_MP.Text == "कांडा  २" || cmbVDC_MP.Text == "कांडा  ३" || cmbVDC_MP.Text == "कांडा  ४" || cmbVDC_MP.Text == "कांडा  ५" || cmbVDC_MP.Text == "कांडा  ६" || cmbVDC_MP.Text == "कांडा  ७" || cmbVDC_MP.Text == "कांडा  ८" || cmbVDC_MP.Text == "कांडा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO36'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "मोरावाङ  १" || cmbVDC_MP.Text == "मोरावाङ  २" || cmbVDC_MP.Text == "मोरावाङ  ३" || cmbVDC_MP.Text == "मोरावाङ  ४" || cmbVDC_MP.Text == "मोरावाङ  ५" || cmbVDC_MP.Text == "मोरावाङ  ६" || cmbVDC_MP.Text == "मोरावाङ  ७" || cmbVDC_MP.Text == "मोरावाङ  ८" || cmbVDC_MP.Text == "मोरावाङ  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO37'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "महत  १" || cmbVDC_MP.Text == "महत  २" || cmbVDC_MP.Text == "महत  ३" || cmbVDC_MP.Text == "महत  ४" || cmbVDC_MP.Text == "महत  ५" || cmbVDC_MP.Text == "महत  ६" || cmbVDC_MP.Text == "महत  ७" || cmbVDC_MP.Text == "महत  ८" || cmbVDC_MP.Text == "महत  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO35'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "मोरावाङ" && cmbVDC_MP.Text == "कांत्रि  १" || cmbVDC_MP.Text == "कांत्रि  २" || cmbVDC_MP.Text == "कांत्रि  ३" || cmbVDC_MP.Text == "कांत्रि  ४" || cmbVDC_MP.Text == "कांत्रि  ५" || cmbVDC_MP.Text == "कांत्रि  ६" || cmbVDC_MP.Text == "कांत्रि  ७" || cmbVDC_MP.Text == "कांत्रि  ८" || cmbVDC_MP.Text == "कांत्रि  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKMO38'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }

            #endregion

            #region  Max code FOR कोल
            //Code TO BE GENERATED  for ‍‌कोल ILLAKAS
            if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "कोल  १" || cmbVDC_MP.Text == "कोल  २" || cmbVDC_MP.Text == "कोल  ३" || cmbVDC_MP.Text == "कोल  ४" || cmbVDC_MP.Text == "कोल  ५" || cmbVDC_MP.Text == "कोल  ६" || cmbVDC_MP.Text == "कोल  ७" || cmbVDC_MP.Text == "कोल  ८" || cmbVDC_MP.Text == "कोल  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO40'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "राङसी  १" || cmbVDC_MP.Text == "राङसी  २" || cmbVDC_MP.Text == "राङसी  ३" || cmbVDC_MP.Text == "राङसी  ४" || cmbVDC_MP.Text == "राङसी  ५" || cmbVDC_MP.Text == "राङसी  ६" || cmbVDC_MP.Text == "राङसी  ७" || cmbVDC_MP.Text == "राङसी  ८" || cmbVDC_MP.Text == "राङसी  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO39'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "तकसेरा  १" || cmbVDC_MP.Text == "तकसेरा  २" || cmbVDC_MP.Text == "तकसेरा  ३" || cmbVDC_MP.Text == "तकसेरा  ४" || cmbVDC_MP.Text == "तकसेरा  ५" || cmbVDC_MP.Text == "तकसेरा  ६" || cmbVDC_MP.Text == "तकसेरा  ७" || cmbVDC_MP.Text == "तकसेरा  ८" || cmbVDC_MP.Text == "तकसेरा  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO41'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "हुकाम  १" || cmbVDC_MP.Text == "हुकाम  २" || cmbVDC_MP.Text == "हुकाम  ३" || cmbVDC_MP.Text == "हुकाम  ४" || cmbVDC_MP.Text == "हुकाम  ५" || cmbVDC_MP.Text == "हुकाम  ६" || cmbVDC_MP.Text == "हुकाम  ७" || cmbVDC_MP.Text == "हुकाम  ८" || cmbVDC_MP.Text == "हुकाम  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO43'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            else if (cmbIllakaName.Text == "कोल" && cmbVDC_MP.Text == "रन्मामैकोट  १" || cmbVDC_MP.Text == "रन्मामैकोट  २" || cmbVDC_MP.Text == "रन्मामैकोट  ३" || cmbVDC_MP.Text == "रन्मामैकोट  ४" || cmbVDC_MP.Text == "रन्मामैकोट  ५" || cmbVDC_MP.Text == "रन्मामैकोट  ६" || cmbVDC_MP.Text == "महत  ७" || cmbVDC_MP.Text == "रन्मामैकोट  ८" || cmbVDC_MP.Text == "रन्मामैकोट  ९")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT MAX(CFCodeNo)from tbl_CFUsrGrp_ActionPlan_Details WHERE TestCode='RUKKO42'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MaxCodeNo.Text = rdr[0].ToString().Trim();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }


            #endregion

        }

       
    }
}
