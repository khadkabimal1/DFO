using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace school_management_system.DFOForms
{
    public partial class RFRecords : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public RFRecords()
        {
            InitializeComponent();
        }

        private void RFRecords_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(RFId) as [RFId],RTRIM(ReligiousForestName) as [ReligiousForestName], RTRIM(VDC_MP_Name) as [VDC_MP_Name], RTRIM(Location) as [Location], RTRIM(Area) as [Area], RTRIM(SiteName) as [SiteName], RTRIM(Latitude) as [Latitude], RTRIM(Longitude) as [Longitude], Map from tbl_ReligiousForestInfo  ", con);

                SqlDataAdapter myDA = new SqlDataAdapter(cmd);

                DataSet myDataSet = new DataSet();

                myDA.Fill(myDataSet, "ReligiousForest");

                DataGridView1.DataSource = myDataSet.Tables["ReligiousForest"].DefaultView;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                ReligiousForest frm = new ReligiousForest();
                frm.Show();
                frm.txtID.Text = dr.Cells[0].Value.ToString();
                frm.txtRFName.Text = dr.Cells[1].Value.ToString();
                frm.cmbNameOfVDC.Text = dr.Cells[2].Value.ToString();
                frm.txtLocation.Text = dr.Cells[3].Value.ToString();
                frm.txtArea.Text = dr.Cells[4].Value.ToString();
                frm.txtSiteName.Text = dr.Cells[5].Value.ToString();
                frm.txtLatitude.Text = dr.Cells[6].Value.ToString();
                frm.txtLongitude.Text = dr.Cells[7].Value.ToString();

                if (frm.pbMapOfCF.Image == null)
                {
                    frm.pbMapOfCF.Image = null;

                }
                else if (frm.pbMapOfCF.Image != null)
                {
                    byte[] data = (byte[])dr.Cells[8].Value;
                    MemoryStream ms = new MemoryStream(data);
                    frm.pbMapOfCF.Image = Image.FromStream(ms);
                }
                frm.lblUser.Text = lblUser.Text;
                frm.lblUserType.Text = lblUserType.Text;
                frm.btnSave.Enabled = false;
                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='Religious Forest' and User_Registration.UserID='" + lblUser.Text + "'";
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

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ControlText;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            foreach (DataGridViewRow Myrow in DataGridView1.Rows)
            {
                Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

            }
        }

        private void RFRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            ReligiousForest frm = new ReligiousForest();
            frm.lblUserType.Text = lblUserType.Text;
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }
    }
}
