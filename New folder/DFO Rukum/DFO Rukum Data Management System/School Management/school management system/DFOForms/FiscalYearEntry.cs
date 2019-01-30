using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace school_management_system.Inventory
{
    public partial class FiscalYearEntry : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;

        public FiscalYearEntry()
        {
            InitializeComponent();
        }

        private void dpstartdate_eng_Leave(object sender, EventArgs e)
        {
            NepaliDate date = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dpstartdate_eng.Text));
            txtstartdate_nep.Text = date.npDate;
        }

        private void dpenddate_eng_Leave(object sender, EventArgs e)
        {
            NepaliDate date = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dpenddate_eng.Text));
            txtenddate_nep.Text = date.npDate;
        }

        private void dpstartdate_eng_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate date = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dpstartdate_eng.Text));
            txtstartdate_nep.Text = date.npDate;
        }

        private void dpenddate_eng_ValueChanged(object sender, EventArgs e)
        {
            NepaliDate date = Convert2NepaliDate.GetNepaliDate(DateTime.Parse(dpenddate_eng.Text));
            txtenddate_nep.Text = date.npDate;
        }

        private void FiscalYearEntry_Load(object sender, EventArgs e)
        {

            GetData();
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(fy_Id),RTRIM(fiscal_name),RTRIM(startdate_eng),RTRIM(startdate_nep),RTRIM(enddate_eng),RTRIM(enddate_nep),RTRIM(isActive) from tbl_FiscalYear", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgvFiscalYear.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dgvFiscalYear.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5],rdr[6]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int isactivefiscal;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFiscal.Text == "")
                {
                    MessageBox.Show("Please enter Fiscal Year name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFiscal.Focus();
                    return;
                }
                if (txtenddate_nep.Text == "")
                {
                    MessageBox.Show("Please enter Nepali End Dtae", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtenddate_nep.Focus();
                    return;
                }
                if (txtstartdate_nep.Text == "")
                {
                    MessageBox.Show("Please enter Neoali Start Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtstartdate_nep.Focus();
                    return;
                }


                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select fiscal_name from tbl_FiscalYear where fiscal_name='" + txtFiscal.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Fiscal Year Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFiscal.Text = "";
                    txtFiscal.Focus();



                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBcon);
                con.Open();
               
                if (IsActive.Checked)
                {
                        isactivefiscal = 1;
                }
                else if (IsActive.Checked)
                {
                    isactivefiscal = 0;
                
                }


                string cb = "insert into tbl_FiscalYear(fiscal_name,startdate_eng,startdate_nep,enddate_eng,enddate_nep,isActive) VALUES ('" + txtFiscal.Text + "','" + dpstartdate_eng.Value + "','" + txtstartdate_nep.Text + "','" + dpenddate_eng.Value + "','" + txtenddate_nep.Text + "','" + isactivefiscal + "')";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                GetData();
                st1 = lblUser.Text;
                st2 = "Added New Fiscal Year '" + txtFiscal.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);


                btnSave.Enabled = true;

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

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='FiscalYearEntry' and User_Registration.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {

                lblSaves.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblSaves.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = true;

        }

        private void Reset()
        {

            txtFiscal.Text = "";
            textBox1.Text = "";
            txtenddate_nep.Text = "";
            txtstartdate_nep.Text = "";
            func();
            Delete.Enabled = true;
            Update_record.Enabled = true;
        }

        private void Delete_Click(object sender, EventArgs e)
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
                string cq1 = "delete from tbl_FiscalYear where fy_Id = '" + textBox1.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)                {

                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Deleted Exam '" +txtFiscal.Text + "'";
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
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                if (IsActive.Checked==true )
                {
                    isactivefiscal = 1;
                }
                else if (IsActive.Checked== false)
                {
                    isactivefiscal = 0;

                }

                string cb = "update tbl_FiscalYear set fiscal_name='" + txtFiscal.Text + "',startdate_eng='" + dpstartdate_eng.Value + "',startdate_nep='" + txtstartdate_nep.Text + "',enddate_eng='" + dpenddate_eng.Value + "',enddate_nep='" + txtenddate_nep.Text + "',isActive='" + isactivefiscal + "' where  fy_Id='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                GetData();
                MessageBox.Show("Successfully updated", "FiscalYearEntry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Updated Fiscal Year'" + txtFiscal.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                Update_record.Enabled = false;


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

        private void dgvFiscalYear_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dgvFiscalYear.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dgvFiscalYear.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ControlText;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

       private void dgvFiscalYear_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvFiscalYear.SelectedRows[0];
                textBox1.Text = dr.Cells[0].Value.ToString();
                txtFiscal.Text = dr.Cells[1].Value.ToString();
                dpstartdate_eng.Value = Convert.ToDateTime(dr.Cells[2].Value);
                dpenddate_eng.Value = Convert.ToDateTime(dr.Cells[4].Value);
                txtstartdate_nep.Text = dr.Cells[3].Value.ToString();
                txtenddate_nep.Text = dr.Cells[5].Value.ToString();
                IsActive.Text= dr.Cells[6].Value.ToString();
                
                btnSave.Enabled = false;

                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(updates), RTRIM(deletes) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='FiscalYearEntry' and User_Registration.UserID='" + lblUser.Text + "' ";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    lblupdate.Text = rdr[0].ToString().Trim();
                    lbldel.Text = rdr[1].ToString().Trim();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (lblupdate.Text == "True")
                    this.Update_record.Enabled = true;
                else
                    this.Update_record.Enabled = true;

                if (lbldel.Text == "True")
                    this.Delete.Enabled = true;
                else
                    this.Delete.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void FiscalYearEntry_FormClosing(object sender, FormClosingEventArgs e)
       {
           this.Hide();
           frm_Main_Menu frm = new frm_Main_Menu();
           frm.UserType.Text = lblUserType.Text;
           frm.User.Text = lblUser.Text;
           frm.Show();
       }

       private void NewRecord_Click(object sender, EventArgs e)
       {
           Reset();   
       }

       private void dgvFiscalYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {

       }
       
    }
}
