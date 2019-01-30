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
    public partial class C : Form
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
        public C()
        {
            InitializeComponent();
        }

        private void C_Load(object sender, EventArgs e)
        {
            AutocompleteCommunityForest();
            AutocompleteVDCMPName();
            AutocompleteIllakaName();
            FiscalYearName();
            GetData();
            dgvProgramDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        private void func()
        {
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='CF User Group Constitution and Action Plan Details Entry' and User_Registration.UserID='" + lblUser.Text + "' ";
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

        private void AutocompleteVDCMPName()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string ct = "select distinct  RTRIM( VDC_MP_Name) from tbl_CommunityForestInfo ";
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
            //       cmbVDC_MP.Items.Add(rdr[0]);
            //    }
            //    con.Close();

            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void C_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
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

                string cb = "insert into tbl_CFUserGroupConstitutionandActionPlanDetails(FileNo, CFCode, CFGS, AAC, Area, Latitude, Longitude,IllakaName,CFName,VDC_MP_Name,SiteName,CF_FiscalYear,  HandOverDateNepali,  GroupRegnDateNepali, HouseHoldNo, NoOfMale, NoOfFemale, Total,East,West,North,South, NameOfProgram, Amount,Benificiary, Remarks,FiscalYearPgmDtlNepali,FiscalYearPresentEnglish,FiscalYearPresentNepali,fiscal_name) VALUES (@FileNo, @CFCode, @CFGS, @AAC, @Area, @Latitude, @Longitude,@IllakaName,@CFName,@VDC_MP_Name,@SiteName,@CF_FiscalYear, @HandOverDateNepali, @GroupRegnDateNepali, @HouseHoldNo,@NoOfMale, @NoOfFemale, @Total,@East,@West,@North,@South, @NameOfProgram, @Amount,@Benificiary, @Remarks,@FiscalYearPgmDtlNepali,@FiscalYearPresentEnglish,@FiscalYearPresentNepali,@fiscal_name)"; 

                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@FileNo",txtFileNo.Text);
                cmd.Parameters.AddWithValue("@CFCode",txtCFCode.Text);
                cmd.Parameters.AddWithValue("@CFGS",txtCFGS.Text);
                cmd.Parameters.AddWithValue("@AAC",txtAAC.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@IllakaName", cmbIllakaName.Text);
                cmd.Parameters.AddWithValue("@CFName",cmbCFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name",cmbVDC_MP.Text);
                cmd.Parameters.AddWithValue("@SiteName", txtSiteName.Text);
                cmd.Parameters.AddWithValue("@CF_FiscalYear",txtCF_FiscalYear.Text);
                cmd.Parameters.AddWithValue("@HandOverDateNepali", txtHandOverDateNepali.Text);
                cmd.Parameters.AddWithValue("@GroupRegnDateNepali",txtGroupRegnDateNepali.Text);
                cmd.Parameters.AddWithValue("@HouseHoldNo", txtHouseHoldNo.Text);
                if (txtNoOfMale.Text == "")
                    cmd.Parameters.AddWithValue("@NoOfMale", 0);
                else
                    cmd.Parameters.AddWithValue("@NoOfMale", txtNoOfMale.Text);


                if (txtNoOfFemale.Text == "")
                    cmd.Parameters.AddWithValue("@NoOfFemale", 0);
                else
                    cmd.Parameters.AddWithValue("@NoOfFemale", txtNoOfFemale.Text);


                if (txtTotal.Text == "")
                    cmd.Parameters.AddWithValue("@Total", 0);
                else
                    cmd.Parameters.AddWithValue("@Total", txtTotal.Text);

                cmd.Parameters.AddWithValue("@East", txtEast.Text);
                cmd.Parameters.AddWithValue("@West", txtWest.Text);
                cmd.Parameters.AddWithValue("@North", txtNorth.Text);
                cmd.Parameters.AddWithValue("@South", txtSouth.Text);
                cmd.Parameters.AddWithValue("@FiscalYearPgmDtlNepali", txtFiscalYearPrgm.Text);
                cmd.Parameters.AddWithValue("@NameOfProgram", txtNameOfProgram.Text);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@Benificiary", txtBenificiary.Text);
                cmd.Parameters.AddWithValue("@Remarks", rchtxtRemarks.Text);
                cmd.Parameters.AddWithValue("@FiscalYearPresentEnglish", txtPresentFiscalYearEng.Text);
                cmd.Parameters.AddWithValue("@FiscalYearPresentNepali", txtPresentFiscalYearNepali.Text);
                cmd.Parameters.AddWithValue("@fiscal_name", txtfiscalYearName.Text);
 
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "added the new FileNo '" + txtCFCode.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "CF User Group Constitution and ActionPlan Details", MessageBoxButtons.OK, MessageBoxIcon.Information);


                btnSave.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();
        }

        private void delete_records()
        {

            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();

                if (txtFileNo.Text != "")
                {
                    string cq1 = "delete from tbl_CFUserGroupConstitutionandActionPlanDetails where FileNo='" + txtFileNo.Text + "'";
                    cmd = new SqlCommand(cq1);
                    cmd.Connection = con;
                    RowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (RowsAffected > 0)
                    {
                        st1 = lblUser.Text;
                        st2 = "deleted the CFUserGroupConstitutionandActionPlanDetails '" + txtFileNo.Text + "'";
                        cf.LogFunc(st1, System.DateTime.Now, st2);
                        MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }

                    else
                    {
                        MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                }
                if (txtFileNo.Text == "" && txtNameOfProgram.Text != "")
                {
                    string cq1 = "delete from tbl_CFUserGroupConstitutionandActionPlanDetails where NameOfProgram='" + txtNameOfProgram.Text + "'";
                    cmd = new SqlCommand(cq1);
                    cmd.Connection = con;
                    RowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (RowsAffected > 0)
                    {
                        st1 = lblUser.Text;
                        st2 = "deleted the CFUserGroupConstitutionandActionPlanDetails '" + txtNameOfProgram.Text + "'";
                        cf.LogFunc(st1, System.DateTime.Now, st2);
                        MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }

                    else
                    {
                        MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                // GetData(); 


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

                string cb = "Update tbl_CFUserGroupConstitutionandActionPlanDetails set FileNo= @FileNo, CFCode=@CFCode, CFGS=@CFGS, AAC=@AAC, Area=@Area, Latitude=@Latitude, Longitude=@Longitude,IllakaName=IllakaName,CFName=@CFName,VDC_MP_Name=@VDC_MP_Name,SiteName=@SiteName,CF_FiscalYear=@CF_FiscalYear, HandOverDateNepali=@HandOverDateNepali, GroupRegnDateNepali=@GroupRegnDateNepali, HouseHoldNo=@HouseHoldNo,NoOfMale=@NoOfMale, NoOfFemale=@NoOfFemale, Total=@Total,East=@East,West=@West,North=@North,South=@South, NameOfProgram=@NameOfProgram, Amount=@Amount,Benificiary=@Benificiary, Remarks=@Remarks,FiscalYearPgmDtlNepali=@FiscalYearPgmDtlNepali,FiscalYearPresentEnglish=@FiscalYearPresentEnglish,FiscalYearPresentNepali=@FiscalYearPresentNepali,fiscal_name=@fiscal_name where CFUGCAPId='" + txtID.Text + "'";
                
                cmd = new SqlCommand(cb);
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@FileNo", txtFileNo.Text);
                cmd.Parameters.AddWithValue("@CFCode", txtCFCode.Text);
                cmd.Parameters.AddWithValue("@CFGS", txtCFGS.Text);
                cmd.Parameters.AddWithValue("@AAC", txtAAC.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@IllakaName", cmbIllakaName.Text);
                cmd.Parameters.AddWithValue("@CFName", cmbCFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbVDC_MP.Text);
                cmd.Parameters.AddWithValue("@SiteName", txtSiteName.Text);
                cmd.Parameters.AddWithValue("@CF_FiscalYear", txtCF_FiscalYear.Text);
                cmd.Parameters.AddWithValue("@HandOverDateNepali", txtHandOverDateNepali.Text);
                cmd.Parameters.AddWithValue("@GroupRegnDateNepali", txtGroupRegnDateNepali.Text);
                cmd.Parameters.AddWithValue("@HouseHoldNo", txtHouseHoldNo.Text);

                if (txtNoOfMale.Text == "")
                    cmd.Parameters.AddWithValue("@NoOfMale",0);
                else
                    cmd.Parameters.AddWithValue("@NoOfMale", txtNoOfMale.Text);


                if (txtNoOfFemale.Text == "")
                    cmd.Parameters.AddWithValue("@NoOfFemale", 0);
                else
                    cmd.Parameters.AddWithValue("@NoOfFemale", txtNoOfFemale.Text);


                if (txtTotal.Text == "")
                    cmd.Parameters.AddWithValue("@Total", 0);
                else
                    cmd.Parameters.AddWithValue("@Total", txtTotal.Text);

                cmd.Parameters.AddWithValue("@East", txtEast.Text);
                cmd.Parameters.AddWithValue("@West", txtWest.Text);
                cmd.Parameters.AddWithValue("@North", txtNorth.Text);
                cmd.Parameters.AddWithValue("@South", txtSouth.Text);
                cmd.Parameters.AddWithValue("@FiscalYearPgmDtlNepali", txtFiscalYearPrgm.Text);
                cmd.Parameters.AddWithValue("@NameOfProgram", txtNameOfProgram.Text);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@Benificiary", txtBenificiary.Text);
                cmd.Parameters.AddWithValue("@Remarks", rchtxtRemarks.Text);
                cmd.Parameters.AddWithValue("@FiscalYearPresentEnglish", txtPresentFiscalYearEng.Text);
                cmd.Parameters.AddWithValue("@FiscalYearPresentNepali", txtPresentFiscalYearNepali.Text);
                cmd.Parameters.AddWithValue("@fiscal_name", txtfiscalYearName.Text);

                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "CF User Group Constitution and ActionPlan Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the tbl_CFUserGroupConstitutionandActionPlanDetails ='" + txtFileNo.Text + "'";
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

        private void Reset()
        {
            txtAAC.Text = "";
            txtAmount.Text = "";
            txtArea.Text = "";
            txtBenificiary.Text = "";
            txtCF_FiscalYear.Text = "";
            txtCFCode.Text = "";
            txtCFGS.Text = "";
            txtEast.Text = "";
            txtFileNo.Text = "";
            txtFileNo.Text = "";
            txtfiscalYearName.Text = "";
            txtFiscalYearPrgm.Text = "";
            txtGroupRegnDateNepali.Text = "";
            txtHandOverDateNepali.Text = "";
            txtHouseHoldNo.Text = "";
            txtID.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtNameOfProgram.Text = "";
            txtNoOfFemale.Text = "";
            txtNoOfMale.Text = "";
            txtNorth.Text = "";
            txtPresentFiscalYearEng.Text = "";
            txtPresentFiscalYearNepali.Text = "";
            txtSiteName.Text = "";
            txtSouth.Text = "";
            txtTotal.Text = "";
            txtWest.Text = "";
            cmbCFName.Text = "";
            cmbIllakaName.Text = "";
            cmbVDC_MP.Text = "";

        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
            btnSave.Enabled = true;
        }


        //For Program Details

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(CFUGCAPId), RTRIM(FiscalYearPgmDtlNepali),RTRIM(NameOfProgram),RTRIM(Amount),RTRIM(Benificiary),RTRIM(Remarks) from tbl_CFUserGroupConstitutionandActionPlanDetails order by NameOfProgram", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgvProgramDetails.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dgvProgramDetails.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProgramDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvProgramDetails.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                txtFiscalYearPrgm.Text = dr.Cells[1].Value.ToString();
                txtNameOfProgram.Text = dr.Cells[2].Value.ToString();
                txtAmount.Text = dr.Cells[3].Value.ToString();
                txtBenificiary.Text = dr.Cells[4].Value.ToString();
                rchtxtRemarks.Text = dr.Cells[5].Value.ToString();

                btnSave.Enabled = false;

                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='CF User Group Constitution and ActionPlan Details' and User_Registration.UserID='" + lblUser.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    labelset.Text = rdr[0].ToString().Trim();
                    labelset2.Text = rdr[1].ToString().Trim();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (labelset.Text == "True")
                    btnUpdate_record.Enabled = true;
                else
                    btnUpdate_record.Enabled = true;


                if (labelset2.Text == "True")
                    btnDelete.Enabled = true;
                else
                    btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProgramDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dgvProgramDetails.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dgvProgramDetails.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

        }

        private void txtNoOfMale_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text =  total().ToString();
        }

        private double total()
        {
            int sum = 0;
            int total = 0;
            int male = 0;
            int Female  = 0;

            if (txtTotal.Text == "")
                total = Convert.ToInt32(0);
            else
                total = Convert.ToInt32(txtTotal.Text);

            if (txtNoOfMale.Text == "")
                male = Convert.ToInt32(0);
            else
                male = Convert.ToInt32(txtNoOfMale.Text);


            if (txtNoOfFemale.Text == "")

                Female = Convert.ToInt32(0.00M);
            else
                Female = Convert.ToInt32(txtNoOfFemale.Text);

            sum = male + Female;
            return sum;

        }

        private void txtNoOfMale_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtNoOfMale, ref e);
        }

        private void txtNoOfFemale_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtNoOfFemale, ref e);
        }

        private void txtNoOfFemale_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text =total().ToString();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFiscalYearPrgm_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref  txtFiscalYearPrgm, ref e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CFUGCAPRecords frm = new CFUGCAPRecords();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            frm.set.Text = "VDC/MP View Records";
            frm.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtPresentFiscalYearNepali_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
    }
}
