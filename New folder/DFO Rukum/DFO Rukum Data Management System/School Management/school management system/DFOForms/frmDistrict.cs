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
    public partial class frmDistrict : Form
    {
        SqlDataReader rdr;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmDistrict()
        {
            InitializeComponent();
        }

        private void frmDistrict_Load(object sender, EventArgs e)
        {
            GetData();
            dataGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           
        }

        private void func()
        {
            con = new SqlConnection(cs.DBcon);

            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='District Information Entry' and User_Registration.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                lblSet1.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblSet1.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;

        }

        private void Reset()
        {
            txtDistrictName. Text = "";
            txtLandArea. Text = "";
            txtArea.Text  = "";
            txtLatitude. Text = "";
            txtLocation.Text = "";
            txtLongitude.Text = "";
            txtNoOfIllaka.Text = "";
            txtNoOfVDC.Text = "";
            txtNameOfIllakasall.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            func();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtDistrictName. Text == "")
                {
                    MessageBox.Show("Please enter District name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDistrictName.Focus();
                    return;
                }
               
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into tbl_DistrictInformation(DistrictName,Area,Location,LandArea,NoOfVDC,NoOfIllaka,Latitude,Longitude,NameOfIllaka) VALUES (@DistrictName,@Area,@Location,@LandArea,@NoOfVDC,@NoOfIllaka,@Latitude,@Longitude,@NameOfIllaka)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@DistrictName", txtDistrictName.Text);
                cmd.Parameters.AddWithValue("@NoOfVDC", txtNoOfVDC.Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@LandArea", txtLandArea.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@NoOfIllaka", txtNoOfIllaka.Text);
                cmd.Parameters.AddWithValue("@NameOfIllaka", txtNameOfIllakasall.Text);
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Added the District='" +txtDistrictName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void delete_records()
        {

            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from tbl_DistrictInformation  where DId='" + txtID. Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Deleted the District='" + txtDistrictName. Text + "'";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb2 = "Update tbl_DistrictInformation set DistrictName=@DistrictName,Area=@Area,Location=@Location,LandArea=@LandArea,NoOfVDC=@NoOfVDC,NoOfIllaka=@NoOfIllaka,Latitude=@Latitude,Longitude=@Longitude,NameOfIllaka=@NameOfIllaka    where DId='" + txtID.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@DistrictName",txtDistrictName.Text);
                cmd.Parameters.AddWithValue("@NoOfVDC",txtNoOfVDC. Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@LandArea",txtLandArea.Text);
                cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                cmd.Parameters.AddWithValue("@NoOfIllaka",txtNoOfIllaka.Text);
                cmd.Parameters.AddWithValue("@NameOfIllaka", txtNameOfIllakasall.Text);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Updated the District='" +txtDistrictName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                btnUpdate.Enabled = false;

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

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(DId), RTRIM(DistrictName),RTRIM(Area),RTRIM(Location),RTRIM(LandArea),RTRIM(NoOfVDC),RTRIM(NoOfIllaka),RTRIM(Latitude),RTRIM(Longitude),RTRIM(NameOfIllaka) from tbl_DistrictInformation ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                txtDistrictName. Text = dr.Cells[1].Value.ToString();
                txtArea. Text = dr.Cells[2].Value.ToString();
                txtLandArea.Text = dr.Cells[3].Value.ToString();
                txtNoOfVDC.Text = dr.Cells[4].Value.ToString();
                txtNoOfIllaka.Text = dr.Cells[5].Value.ToString();
                txtLocation.Text = dr.Cells[6].Value.ToString();
                txtLatitude.Text = dr.Cells[7].Value.ToString();
                txtLongitude. Text = dr.Cells[8].Value.ToString();
                txtNameOfIllakasall.Text = dr.Cells[9].Value.ToString();               
      
                btnSave.Enabled = false;

                con = new SqlConnection(cs.DBcon);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(updates),rtrim(deletes) from UserGrants inner join User_Registration on UserGrants.UserId=User_Registration.ID where Forms='District Information' and User_Registration.UserID='" + lblUser.Text + "'";
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
                    btnUpdate.Enabled = true;
                else
                    btnUpdate.Enabled = true;


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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            {
                Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

            }
        }

        private void frmDistrict_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }
       
    }
}
