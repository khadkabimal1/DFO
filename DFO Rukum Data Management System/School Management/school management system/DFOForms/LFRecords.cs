using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System;

namespace school_management_system.DFOForms
{
    public partial class LFRecords : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public LFRecords()
        {
            InitializeComponent();
        }

        private void LFRecords_Load(object sender, EventArgs e)
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

                cmd = new SqlCommand("SELECT  LFId,rtrim(LeisureForestName) [LeisureForestName],rtrim(VDC_MP_Name) [VDC_MP_Name] , rtrim(HandOverFY) [HandOverFY],rtrim(Area) [Area],rtrim(HouseHoldNo) [HouseHoldNo],rtrim(VeryPoor) [VeryPoor] ,rtrim(MediumPoor) [MediumPoor],rtrim(Poor) [Poor],rtrim(Remarks) [Remarks] from tbl_LeisureForestInfo ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //dgvVDC_MPViewRecords.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dgvVDC_MPViewRecords.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LFRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            LeisureForest frm = new LeisureForest();
            frm.lblUserType.Text = lblUserType.Text;
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }

        private void dgvVDC_MPViewRecords_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvVDC_MPViewRecords.SelectedRows[0];
                this.Hide();
                LeisureForest frm = new LeisureForest();
                frm.Show();
                frm.txtID.Text = dr.Cells[0].Value.ToString();
                frm.txtLFName.Text = dr.Cells[1].Value.ToString();
                frm.cmbNameOfVDC.Text = dr.Cells[2].Value.ToString();
                frm.txtHandOverFY.Text = dr.Cells[3].Value.ToString();
                frm.txtArea.Text = dr.Cells[4].Value.ToString();
                frm.txtHouseHold.Text = dr.Cells[5].Value.ToString();
                frm.txtVeryPoor.Text = dr.Cells[6].Value.ToString();
                frm.txtMediumPoor.Text = dr.Cells[7].Value.ToString();
                frm.txtpoor.Text = dr.Cells[8].Value.ToString();
                frm.txtRemarks.Text = dr.Cells[9].Value.ToString();

                frm.lblUser.Text = lblUser.Text;
                frm.lblUserType.Text = lblUserType.Text;
                frm.btnSave.Enabled = false;
                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Leisure Forest' and User_Registration.UserID='" + lblUser.Text + "'";
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
        }

        private void dgvVDC_MPViewRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvVDC_MPViewRecords.Rows)
            {
                Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

            }
        }
    }
}
