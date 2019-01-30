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


            sum = male + Female + HouseHold;
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

                string cb = "insert into tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails ( FileNo,IllakaName,CFName,VDC_MP_Name,HouldHold,Male,Female,Total,Area,CFGS,AAC,CF_FiscalYear,CFHandOverDate,LastRenewDate,GroupRegnDate,CFCodeNo,MainSpecies,PresentFYEng,PresentFYNep,PresentFYName,Latitude,Longitude,SiteName) VALUES (@FileNo,@IllakaName,@CFName,@VDC_MP_Name,@HouldHold,@Male,@Female,@Total,@Area,@CFGS,@AAC,@CF_FiscalYear, @CFHandOverDate,@LastRenewDate,@GroupRegnDate,@CFCodeNo,@MainSpecies,@PresentFYEng,@PresentFYNep,@PresentFYName,@Latitude,@Longitude,@SiteName)";

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





               // Code TO BE GENERATED  for साँख ILLAKAS
                //string codeNo = "";

                //string code = "select CFCodeNo from  tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails";
                //int LastNumber = 1;
                //string saakh = "साँख";
                //string vdc = "खलंगा  १";
                //string vdc1 = "खलंगा  २"; string vdc2 = "खलंगा  ३";

                //if (cmbIllakaName.Text == saakh && cmbVDC_MP.Text == vdc)
                //{
                //    codeNo = "RUK/" + "SH/" + "31/" + 0 + LastNumber;
                //}

                //if (cmbIllakaName.Text == saakh && cmbVDC_MP.Text == vdc1)
                //{
                //    codeNo = "RUK/" + "SH/" + "31/" + 0 + LastNumber;
                //}

                //if (cmbIllakaName.Text == saakh && cmbVDC_MP.Text == vdc2)
                //{
                //    codeNo = "RUK/" + "SH/" + "31/" + 0 + LastNumber;
                //}
                cmd.Parameters.AddWithValue("@CFCodeNo", txtCodeNo.Text);

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

                string cb = "Update tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails set FileNo=@FileNo,IllakaName=@IllakaName,CFName=@CFName,VDC_MP_Name=@VDC_MP_Name,HouldHold=@HouldHold,Male=@Male,Female=@Female,Total=@Total,Area=@Area,CFGS=@CFGS,AAC=@AAC,CF_FiscalYear=@CF_FiscalYear,CFHandOverDate=@CFHandOverDate,LastRenewDate=@LastRenewDate, GroupRegnDate=@GroupRegnDate,CFCodeNo=@CFCodeNo,MainSpecies=@MainSpecies,PresentFYEng=@PresentFYEng,PresentFYNep=@PresentFYNep, PresentFYName=@PresentFYName,Latitude=@Latitude,Longitude=@Longitude,SiteName=@SiteName where IFOAVDCFUGDtls='" + txtID.Text + "'";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@FileNo", txtFileNo.Text);
                cmd.Parameters.AddWithValue("@CFCodeNo", txtCodeNo.Text);
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

       
    }
}
