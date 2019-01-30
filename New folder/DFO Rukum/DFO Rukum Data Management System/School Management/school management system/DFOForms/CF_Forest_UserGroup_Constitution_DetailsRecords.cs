using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace school_management_system.DFOForms
{
    public partial class CF_Forest_UserGroup_Constitution_DetailsRecords : Form
    {
        DataTable dtable = new DataTable();
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public CF_Forest_UserGroup_Constitution_DetailsRecords()
        {
            InitializeComponent();
        }

        private void CF_Forest_UserGroup_Constitution_DetailsRecords_Load(object sender, EventArgs e)
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
                cmd = new SqlCommand("SELECT  CFUsrGrpCDtl,rtrim(IllakaName) [IllakaName],rtrim(CFName) [CFName],rtrim(VDC_MP_Name) [VDC_MP_Name] ,rtrim(HhDalit) [HhDalit],rtrim(HhJanjati) [HhJanjati],rtrim(HhOthersCaste) [HhOthersCaste] ,rtrim(HhTotal) [HhTotal],rtrim(SDalitM) [SDalitM],rtrim(SDalitF) [SDalitF] ,rtrim(SJanjatiM) [SJanjatiM],rtrim(SJanjatiF) [SJanjatiF] ,rtrim(SOthersM) [SOthersM],rtrim(SOthersF) [SOthersF],rtrim(STotalM) [STotalM] ,rtrim(STotalF) [STotalF],rtrim(GrandTotal) [GrandTotal] ,rtrim(BA) [BA],rtrim(BB) [BB] ,rtrim(BC) [BC],rtrim(BD) [BD]  from tbl_CFUsrGrpConstitutionDtls ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //dgvVDC_MPViewRecords.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dgvVDC_MPViewRecords.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20]);
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
                CF_Forest_UserGroup_Constitution_Details frm = new CF_Forest_UserGroup_Constitution_Details();
                frm.Show();
                frm.txtID.Text = dr.Cells[0].Value.ToString();
                frm.cmbIllakaName.Text = dr.Cells[1].Value.ToString();
                frm.cmbCFName.Text = dr.Cells[2].Value.ToString();
                frm.cmbVDC_MP.Text = dr.Cells[3].Value.ToString();
                frm.txtDalit.Text = dr.Cells[4].Value.ToString();
                frm.txtJanjati.Text = dr.Cells[5].Value.ToString();
                frm.txtOthersCaste.Text = dr.Cells[6].Value.ToString();
                frm.txtTotalHouseHold.Text = dr.Cells[7].Value.ToString();
                frm.txtMaleDalit.Text = dr.Cells[8].Value.ToString();
                frm.txtFemaleDalit.Text = dr.Cells[9].Value.ToString();
                frm.txtMaleJanjati.Text = dr.Cells[10].Value.ToString();
                frm.txtFemaleJanjati.Text = dr.Cells[11].Value.ToString();
                frm.txtMaleOtherscaste.Text = dr.Cells[12].Value.ToString();
                frm.txtFemaleOtherCaste.Text = dr.Cells[13].Value.ToString();
                frm.txtMaleTotal.Text = dr.Cells[14].Value.ToString();
                frm.txtFemaleTotal.Text = dr.Cells[15].Value.ToString();
                frm.txtGrandTotal.Text = dr.Cells[16].Value.ToString();
                frm.txtA.Text = dr.Cells[17].Value.ToString();
                frm.txtB.Text = dr.Cells[18].Value.ToString();
                frm.txtC.Text = dr.Cells[19].Value.ToString();
                frm.txtD.Text = dr.Cells[20].Value.ToString();
                frm.lblUser.Text = lblUser.Text;
                frm.lblUserType.Text = lblUserType.Text;

                frm.btnSave.Enabled = false;
                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='C.F User Group Constitution  Details Entry' and User_Registration.UserID='" + lblUser.Text + "'";
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

        private void CF_Forest_UserGroup_Constitution_DetailsRecords_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Hide();
            CF_Forest_UserGroup_Constitution_Details frm = new CF_Forest_UserGroup_Constitution_Details();
            frm.lblUserType.Text = lblUserType.Text;
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }
    }
}
