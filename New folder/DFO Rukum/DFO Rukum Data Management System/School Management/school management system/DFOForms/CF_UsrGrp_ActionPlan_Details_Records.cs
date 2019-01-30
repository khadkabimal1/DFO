using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System;

namespace school_management_system.DFOForms
{
    public partial class CF_UsrGrp_ActionPlan_Details_Records : Form
    {
        DataTable dtable = new DataTable();
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public CF_UsrGrp_ActionPlan_Details_Records()
        {
            InitializeComponent();
        }

        private void CF_UsrGrp_ActionPlan_Details_Records_Load(object sender, EventArgs e)
        {
         dgvVDC_MPViewRecords.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
         GetData();
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT  CFUGACDtls,rtrim(IllakaName) [IllakaName],rtrim(FileNo) [FileNo],rtrim(CFName) [CFName],rtrim(VDC_MP_Name) [VDC_MP_Name],rtrim(LastRenewDate) [LastRenewDate],rtrim(CFCodeNo) [CFCodeNo] ,rtrim(KhandaCount) [KhandaCount], rtrim(HouldHold) [HouldHold],rtrim(Area) [Area] ,rtrim(MainSpecies) [MainSpecies] from tbl_CFUsrGrp_ActionPlan_Details ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //dgvVDC_MPViewRecords.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dgvVDC_MPViewRecords.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVDC_MPViewRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvVDC_MPViewRecords.Rows)
            {
                Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

            }
        }

        private void dgvVDC_MPViewRecords_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Hide();
                DataGridViewRow dr = dgvVDC_MPViewRecords.SelectedRows[0];
                CF_UsrGrp_ActionPlanDetails frm = new CF_UsrGrp_ActionPlanDetails();
                frm.Show();
                frm.txtID.Text = dr.Cells[0].Value.ToString();
                frm.cmbIllakaName.Text = dr.Cells[1].Value.ToString();
                frm.txtFileNo.Text = dr.Cells[2].Value.ToString();
                frm.cmbCFName.Text = dr.Cells[3].Value.ToString();
                frm.cmbVDC_MP.Text = dr.Cells[4].Value.ToString();
                frm.txtLatRenewDate.Text = dr.Cells[5].Value.ToString();
                frm.txtCodeNo.Text = dr.Cells[6].Value.ToString();

                frm.txtkhandacount.Text = dr.Cells[7].Value.ToString();

                frm.txtHouseHold.Text = dr.Cells[8].Value.ToString();
                
                frm.txtArea.Text = dr.Cells[9].Value.ToString();

                frm.rchtxtSpecies.Text = dr.Cells[10].Value.ToString();
                
              

                frm.lblUser.Text = lblUser.Text;
                frm.lblUserType.Text = lblUserType.Text;

                frm.btnSave.Enabled = false;
                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='CF_UserGroup Action Plan Details Records' and User_Registration.UserID='" + lblUser.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    lblupdate.Text = rdr[0].ToString().Trim();
                    lbldelete.Text = rdr[1].ToString().Trim();

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
                    frm.btnUpdate_record.Enabled = true;
                else
                    frm.btnUpdate_record.Enabled = true;


                if (lbldelete.Text == "True")
                    frm.btnDelete.Enabled = true;
                else
                    frm.btnDelete.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvVDC_MPViewRecords_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dgvVDC_MPViewRecords.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dgvVDC_MPViewRecords.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void CF_UsrGrp_ActionPlan_Details_Records_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            CF_UsrGrp_ActionPlanDetails frm = new CF_UsrGrp_ActionPlanDetails();
            frm.lblUserType.Text = lblUserType.Text;
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }
    }
}
