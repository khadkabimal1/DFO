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
    public partial class CF_Forest_UserGroup_Constitution_Details : Form
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
        public CF_Forest_UserGroup_Constitution_Details()
        {
            InitializeComponent();
        }

        private void CF_Forest_UserGroup_Constitution_Details_Load(object sender, EventArgs e)
        {
            AutocompleteCommunityForest();
            AutocompleteVDCMPName();
            AutocompleteIllakaName();
            FiscalYearName();
        }

        private void func()
        {
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='CF User Group Constitution Details Entry' and User_Registration.UserID='" + lblUser.Text + "' ";
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

        private void Reset()
        {
            txtID.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtDalit.Text = "";
            txtFemaleDalit.Text = "";
            txtFemaleJanjati.Text = "";
            txtFemaleOtherCaste.Text = "";
            txtFemaleTotal.Text = "";
            txtfiscalYearName.Text = "";
            txtGrandTotal.Text = "";
            txtJanjati.Text = "";
            txtMaleDalit.Text = "";
            txtMaleJanjati.Text = "";
            txtMaleOtherscaste.Text = "";
            txtMaleTotal.Text = "";
            txtOthersCaste.Text = "";
            txtTotalHouseHold.Text = "";
            txtPresentFiscalYearEng.Text = "";
            txtPresentFiscalYearNepali.Text = "";       
            cmbCFName.Text = "";
            cmbIllakaName.Text = "";
            cmbVDC_MP.Text = "";

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
                string cq1 = "delete from tbl_CFUsrGrpConstitutionDtls where CFUsrGrpCDtl='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "CFUsrGrpConstitutionDtls is deleted CommunityForestName='" +cmbCFName.Text + "'";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

               
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

                string cb = "insert into tbl_CFUsrGrpConstitutionDtls(IllakaName,CFName,VDC_MP_Name,FYName,PresentFYNepali,  PresentFYEng,  HhDalit, HhJanjati, HhOthersCaste, HhTotal, SDalitM,SDalitF,SJanjatiM,SJanjatiF,SOthersM, SOthersF, STotalM,STotalF, GrandTotal,BA,BB,BC,BD) VALUES (@IllakaName,@CFName,@VDC_MP_Name,@FYName,@PresentFYNepali,  @PresentFYEng, @HhDalit, @HhJanjati, @HhOthersCaste, @HhTotal, @SDalitM,@SDalitF,@SJanjatiM,@SJanjatiF,@SOthersM, @SOthersF, @STotalM,@STotalF, @GrandTotal,@BA,@BB,@BC,@BD)";
              
                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@IllakaName", cmbIllakaName.Text);
                  cmd.Parameters.AddWithValue("@CFName", cmbCFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbVDC_MP.Text);
                cmd.Parameters.AddWithValue("@FYName",txtfiscalYearName.Text);
                cmd.Parameters.AddWithValue("@PresentFYNepali",txtPresentFiscalYearNepali.Text);
                cmd.Parameters.AddWithValue("@PresentFYEng",txtPresentFiscalYearEng.Text);

                if (txtDalit.Text == "")
                    cmd.Parameters.AddWithValue("@HhDalit", 0);
                else
                    cmd.Parameters.AddWithValue("@HhDalit", txtDalit.Text);


                if (txtJanjati.Text == "")
                    cmd.Parameters.AddWithValue("@HhJanjati", 0);
                else
                    cmd.Parameters.AddWithValue("@HhJanjati", txtJanjati.Text);


                if (txtOthersCaste.Text == "")
                    cmd.Parameters.AddWithValue("@HhOthersCaste", 0);
                else
                    cmd.Parameters.AddWithValue("@HhOthersCaste", txtOthersCaste.Text);


                if (txtTotalHouseHold.Text == "")
                    cmd.Parameters.AddWithValue("@HhTotal", 0);
                else
                    cmd.Parameters.AddWithValue("@HhTotal", txtTotalHouseHold.Text);

                //............
                if (txtMaleDalit.Text == "")
                    cmd.Parameters.AddWithValue("@SDalitM", 0);
                else
                    cmd.Parameters.AddWithValue("@SDalitM", txtMaleDalit.Text);

                if (txtFemaleDalit.Text == "")
                    cmd.Parameters.AddWithValue("@SDalitF", 0);
                else
                    cmd.Parameters.AddWithValue("@SDalitF", txtFemaleDalit.Text);

                if (txtMaleJanjati.Text == "")
                    cmd.Parameters.AddWithValue("@SJanjatiM", 0);
                else
                    cmd.Parameters.AddWithValue("@SJanjatiM", txtMaleJanjati.Text);

                if (txtFemaleJanjati.Text == "")
                    cmd.Parameters.AddWithValue("@SJanjatiF", 0);
                else
                    cmd.Parameters.AddWithValue("@SJanjatiF", txtFemaleJanjati.Text);

                if (txtMaleOtherscaste.Text == "")
                    cmd.Parameters.AddWithValue("@SOthersM", 0);
                else
                    cmd.Parameters.AddWithValue("@SOthersM", txtMaleOtherscaste.Text);

                if (txtFemaleOtherCaste.Text == "")
                    cmd.Parameters.AddWithValue("@SOthersF", 0);
                else
                    cmd.Parameters.AddWithValue("@SOthersF", txtFemaleOtherCaste.Text);

                if (txtMaleTotal.Text == "")
                    cmd.Parameters.AddWithValue("@STotalM", 0);
                else
                    cmd.Parameters.AddWithValue("@STotalM", txtMaleTotal.Text);

                if (txtFemaleTotal.Text == "")
                    cmd.Parameters.AddWithValue("@STotalF", 0);
                else
                    cmd.Parameters.AddWithValue("@STotalF", txtFemaleTotal.Text);

                if (txtGrandTotal.Text == "")
                    cmd.Parameters.AddWithValue("@GrandTotal", 0);
                else
                    cmd.Parameters.AddWithValue("@GrandTotal", txtGrandTotal.Text);

                cmd.Parameters.AddWithValue("@BA",txtA.Text);
                cmd.Parameters.AddWithValue("@BB",txtB.Text);
                cmd.Parameters.AddWithValue("@BC",txtC.Text);
                cmd.Parameters.AddWithValue("@BD",txtD.Text);
             
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "added the new CFUserGroupConstitution Details '" + cmbIllakaName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "CF User Group Constitution  Details", MessageBoxButtons.OK, MessageBoxIcon.Information);


                btnSave.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Reset();
      
        }

        private void txtDalit_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtDalit, ref e);
        }

        private void txtJanjati_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtJanjati, ref e);
        }

        private void txtOthersCaste_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtOthersCaste, ref e);
        }

        private void txtTotalHouseHold_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtTotalHouseHold, ref e);
        }

        private void txtMaleDalit_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtMaleDalit, ref e);
        }

        private void txtFemaleDalit_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtFemaleDalit, ref e);
        }

        private void txtMaleJanjati_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtMaleJanjati, ref e);
        }

        private void txtFemaleJanjati_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtFemaleJanjati, ref e);
        }

        private void txtMaleOtherscaste_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtMaleOtherscaste, ref e);
        }

        private void txtFemaleOtherCaste_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtFemaleOtherCaste, ref e);
        }

        private void txtMaleTotal_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtMaleTotal, ref e);
        }

        private void txtFemaleTotal_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtFemaleTotal, ref e);
        }

        private void txtGrandTotal_KeyDown(object sender, KeyEventArgs e)
        {
            Class1.NumberOnly(ref txtGrandTotal, ref e);
        }

        private void txtDalit_TextChanged(object sender, EventArgs e)
        {
            txtTotalHouseHold.Text = total().ToString();
        }

        private double total()
        {
            int sum = 0;
            int total = 0;
            int male = 0;
            int Female = 0;
            int others = 0;

            if (txtTotalHouseHold. Text == "")
                total = Convert.ToInt32(0);
            else
                total = Convert.ToInt32(txtTotalHouseHold.Text);

            if (txtDalit.Text == "")
                male = Convert.ToInt32(0);
            else
                male = Convert.ToInt32(txtDalit.Text);


            if (txtJanjati.Text == "")

                Female = Convert.ToInt32(0.00M);
            else
                Female = Convert.ToInt32(txtJanjati.Text);


            if (txtOthersCaste.Text == "")

                others = Convert.ToInt32(0.00M);
            else
                others = Convert.ToInt32(txtOthersCaste.Text);


            sum = male + Female + others;
            return sum;

        }

        private void txtJanjati_TextChanged(object sender, EventArgs e)
        {
            txtTotalHouseHold.Text = total().ToString();
        }

        private void txtOthersCaste_TextChanged(object sender, EventArgs e)
        {
            txtTotalHouseHold.Text = total().ToString();
        }

        private double Ftotal()
        {
            int sum2 = 0;
            int totalF = 0;
            int DFemale = 0;
            int JFemale = 0;
            int OFemale = 0;

            if (txtFemaleTotal.Text == "")
                totalF = Convert.ToInt32(0);
            else
                totalF = Convert.ToInt32(txtFemaleTotal.Text);

            if (txtFemaleDalit.Text == "")
                DFemale = Convert.ToInt32(0);
            else
                DFemale = Convert.ToInt32(txtFemaleDalit.Text);


            if (txtFemaleJanjati. Text == "")

                JFemale = Convert.ToInt32(0.00M);
            else
                JFemale = Convert.ToInt32(txtFemaleJanjati.Text);

            if (txtFemaleOtherCaste.Text == "")

                OFemale = Convert.ToInt32(0.00M);
            else
                OFemale = Convert.ToInt32(txtFemaleOtherCaste.Text);

            sum2 = DFemale + JFemale + OFemale;
            return sum2;
        }

        private double Mtotal()
        {
            int sum1 = 0;
            int totalM = 0;
            int Dmale = 0;
            int Jmale = 0;
            int Omale = 0;

            if (txtMaleTotal.Text == "")
                totalM = Convert.ToInt32(0);
            else
                totalM = Convert.ToInt32(txtMaleTotal.Text);     

            if (txtMaleDalit.Text == "")
                Dmale = Convert.ToInt32(0);
            else
                Dmale = Convert.ToInt32(txtMaleDalit.Text);

            if (txtMaleOtherscaste.Text == "")

                Omale = Convert.ToInt32(0.00M);
            else
                Omale = Convert.ToInt32(txtMaleOtherscaste.Text);

            if (txtMaleJanjati.Text == "")

               Jmale  = Convert.ToInt32(0.00M);
            else
               Jmale  = Convert.ToInt32(txtMaleJanjati.Text);

            sum1 = Dmale + Jmale + Omale;
            return sum1;

        }


        private double GrandTotal()
        {
            int sumGrand = 0;
            int totalF = 0;
            int totalMale = 0;
            int totalFemale = 0;

            if (txtGrandTotal.Text == "")
                totalF = Convert.ToInt32(0);
            else
                totalF = Convert.ToInt32(txtGrandTotal.Text);

            if (txtMaleTotal.Text == "")
                totalMale = Convert.ToInt32(0);
            else
                totalMale = Convert.ToInt32(txtMaleTotal.Text);


            if (txtFemaleTotal.Text == "")

                totalFemale = Convert.ToInt32(0.00M);
            else
                totalFemale = Convert.ToInt32(txtFemaleTotal.Text);



            sumGrand = totalMale + totalFemale ;
            return sumGrand;
        }


        private void txtMaleDalit_TextChanged(object sender, EventArgs e)
        {
            txtMaleTotal.Text = Mtotal().ToString();
        }

        private void txtFemaleDalit_TextChanged(object sender, EventArgs e)
        {
            txtFemaleTotal.Text = Ftotal().ToString();
        }

        private void txtMaleJanjati_TextChanged(object sender, EventArgs e)
        {
            txtMaleTotal.Text = Mtotal().ToString();
        }

        private void txtFemaleJanjati_TextChanged(object sender, EventArgs e)
        {
            txtFemaleTotal.Text = Ftotal().ToString();
        }

        private void txtMaleOtherscaste_TextChanged(object sender, EventArgs e)
        {
            txtMaleTotal.Text = Mtotal().ToString();
        }

        private void txtFemaleOtherCaste_TextChanged(object sender, EventArgs e)
        {
            txtFemaleTotal.Text = Ftotal().ToString();
        }

        private void txtMaleTotal_TextChanged(object sender, EventArgs e)
        {
            txtGrandTotal.Text = GrandTotal().ToString();
        }

        private void txtFemaleTotal_TextChanged(object sender, EventArgs e)
        {
            txtGrandTotal.Text = GrandTotal().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CF_Forest_UserGroup_Constitution_DetailsRecords frm = new CF_Forest_UserGroup_Constitution_DetailsRecords();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            frm.set.Text = "VDC/MP View Records";
            frm.Show();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "Update tbl_CFUsrGrpConstitutionDtls set IllakaName=@IllakaName,CFName=@CFName,VDC_MP_Name=@VDC_MP_Name,FYName=@FYName,PresentFYNepali=@PresentFYNepali,  PresentFYEng=@PresentFYEng, HhDalit=@HhDalit, HhJanjati=@HhJanjati, HhOthersCaste=@HhOthersCaste, HhTotal=@HhTotal, SDalitM=@SDalitM,SDalitF=@SDalitF,SJanjatiM=@SJanjatiM, SJanjatiF=@SJanjatiF,SOthersM=@SOthersM,SOthersF=@SOthersF, STotalM=@STotalM,STotalF=@STotalF, GrandTotal=@GrandTotal,BA=@BA,BB=@BB,BC=@BC,BD=@BD   where CFUsrGrpCDtl='" + txtID.Text + "'";

                

                cmd = new SqlCommand(cb);
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@IllakaName", cmbIllakaName.Text);
                cmd.Parameters.AddWithValue("@CFName", cmbCFName.Text);
                cmd.Parameters.AddWithValue("@VDC_MP_Name", cmbVDC_MP.Text);
                cmd.Parameters.AddWithValue("@FYName", txtfiscalYearName.Text);
                cmd.Parameters.AddWithValue("@PresentFYNepali", txtPresentFiscalYearNepali.Text);
                cmd.Parameters.AddWithValue("@PresentFYEng", txtPresentFiscalYearEng.Text);

                if (txtDalit.Text == "")
                    cmd.Parameters.AddWithValue("@HhDalit", 0);
                else
                    cmd.Parameters.AddWithValue("@HhDalit", txtDalit.Text);


                if (txtJanjati.Text == "")
                    cmd.Parameters.AddWithValue("@HhJanjati", 0);
                else
                    cmd.Parameters.AddWithValue("@HhJanjati", txtJanjati.Text);


                if (txtOthersCaste.Text == "")
                    cmd.Parameters.AddWithValue("@HhOthersCaste", 0);
                else
                    cmd.Parameters.AddWithValue("@HhOthersCaste", txtOthersCaste.Text);


                if (txtTotalHouseHold.Text == "")
                    cmd.Parameters.AddWithValue("@HhTotal", 0);
                else
                    cmd.Parameters.AddWithValue("@HhTotal", txtTotalHouseHold.Text);

                //............
                if (txtMaleDalit.Text == "")
                    cmd.Parameters.AddWithValue("@SDalitM", 0);
                else
                    cmd.Parameters.AddWithValue("@SDalitM", txtMaleDalit.Text);

                if (txtFemaleDalit.Text == "")
                    cmd.Parameters.AddWithValue("@SDalitF", 0);
                else
                    cmd.Parameters.AddWithValue("@SDalitF", txtFemaleDalit.Text);

                if (txtMaleJanjati.Text == "")
                    cmd.Parameters.AddWithValue("@SJanjatiM", 0);
                else
                    cmd.Parameters.AddWithValue("@SJanjatiM", txtMaleJanjati.Text);

                if (txtFemaleJanjati.Text == "")
                    cmd.Parameters.AddWithValue("@SJanjatiF", 0);
                else
                    cmd.Parameters.AddWithValue("@SJanjatiF", txtFemaleJanjati.Text);

                if (txtMaleOtherscaste.Text == "")
                    cmd.Parameters.AddWithValue("@SOthersM", 0);
                else
                    cmd.Parameters.AddWithValue("@SOthersM", txtMaleOtherscaste.Text);

                if (txtFemaleOtherCaste.Text == "")
                    cmd.Parameters.AddWithValue("@SOthersF", 0);
                else
                    cmd.Parameters.AddWithValue("@SOthersF", txtFemaleOtherCaste.Text);

                if (txtMaleTotal.Text == "")
                    cmd.Parameters.AddWithValue("@STotalM", 0);
                else
                    cmd.Parameters.AddWithValue("@STotalM", txtMaleTotal.Text);

                if (txtFemaleTotal.Text == "")
                    cmd.Parameters.AddWithValue("@STotalF", 0);
                else
                    cmd.Parameters.AddWithValue("@STotalF", txtFemaleTotal.Text);

                if (txtGrandTotal.Text == "")
                    cmd.Parameters.AddWithValue("@GrandTotal", 0);
                else
                    cmd.Parameters.AddWithValue("@GrandTotal", txtGrandTotal.Text);

                cmd.Parameters.AddWithValue("@BA", txtA.Text);
                cmd.Parameters.AddWithValue("@BB", txtB.Text);
                cmd.Parameters.AddWithValue("@BC", txtC.Text);
                cmd.Parameters.AddWithValue("@BD", txtD.Text);
             

                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "CF User Group Constitution and ActionPlan Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Update the tbl_CFUserGroupConstitutionDetails ='" +cmbCFName.Text + "'";
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

        private void CF_Forest_UserGroup_Constitution_Details_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }
       
    }
}
