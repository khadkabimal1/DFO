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
    public partial class PrivateForestRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public PrivateForestRecord()
        {
            InitializeComponent();
        }

        private void PrivateForestRecord_Load(object sender, EventArgs e)
        {
            GetData();
            dgvVDC_MPViewRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvVDC_MPViewRecords.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();

                cmd = new SqlCommand("SELECT  PFId,rtrim(OwnerName) [OwnerName],rtrim(VDC_MP_Name) [VDC_MP_Name] ,rtrim(RegnDateEng) [RegnDateEng],rtrim(Area) [Area],rtrim(Vegegations) [Vegegations],rtrim(Latitude) [Latitude],rtrim(Longitude) [Longitude] ,rtrim(PrivateForestName) [PrivateForestName] from tbl_PrivateForestInfo ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //dgvVDC_MPViewRecords.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dgvVDC_MPViewRecords.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVDC_MPViewRecords_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Hide();
                DataGridViewRow dr = dgvVDC_MPViewRecords.SelectedRows[0];
                PrivateForest frm = new PrivateForest();
                frm.Show();

                frm.txtID.Text = dr.Cells[0].Value.ToString();
                frm.txtOwnerName.Text = dr.Cells[1].Value.ToString();
                frm.cmbNameOfVDC.Text = dr.Cells[2].Value.ToString();
                frm.txtNepaliDate.Text = dr.Cells[3].Value.ToString();
                frm.txtArea.Text = dr.Cells[4].Value.ToString();
                frm.txtNameOfSpeciesandNo.Text = dr.Cells[5].Value.ToString();
                frm.txtLatitude.Text = dr.Cells[6].Value.ToString();
                frm.txtLongitude.Text = dr.Cells[7].Value.ToString();  
                frm.txtPFName.Text = dr.Cells[8].Value.ToString();
                frm.lblUser.Text = lblUser.Text;
                frm.lblUserType.Text = lblUserType.Text;

                frm.btnSave.Enabled = false;
                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Private Forest Entry' and User_Registration.UserID='" + lblUser.Text + "'";
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

        private void dgvVDC_MPViewRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvVDC_MPViewRecords.Rows)
            {
                Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

            }
        }

        private void PrivateForestRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            PrivateForest frm = new PrivateForest();
            frm.lblUserType.Text = lblUserType.Text;
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }
    }
}
