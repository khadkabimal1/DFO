using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace school_management_system
{
    public partial class frmUserGrants : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        CheckBox HeaderCheckBox1 = null;
        CheckBox HeaderCheckBox2 = null;
        CheckBox HeaderCheckBox3= null;
        bool IsHeaderCheckBoxClicked = false;

       
        public frmUserGrants()
        {
            InitializeComponent();

        }

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dgvSelectAll.Controls.Add(HeaderCheckBox);

          
        }
        private void AddHeaderCheckBox1()  //adding new
        {
            HeaderCheckBox1 = new CheckBox();

            HeaderCheckBox1.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dgvSelectAll.Controls.Add(HeaderCheckBox1);


        }
        private void AddHeaderCheckBox2()  //adding new
        {
            HeaderCheckBox2 = new CheckBox();

            HeaderCheckBox2.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dgvSelectAll.Controls.Add(HeaderCheckBox2);


        }

          private void AddHeaderCheckBox3()  //adding new
        {
            HeaderCheckBox3 = new CheckBox();

            HeaderCheckBox3.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dgvSelectAll.Controls.Add(HeaderCheckBox3);


        }

        private void dgvSelectAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsHeaderCheckBoxClicked)
                RowCheckBoxClick((DataGridViewCheckBoxCell)dgvSelectAll[e.ColumnIndex, e.RowIndex]);
        }

        public void refresh()
        {
           
            forms();
            AddHeaderCheckBox();
            AddHeaderCheckBox1();
            AddHeaderCheckBox2();
            AddHeaderCheckBox3();
            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            dgvSelectAll.CellValueChanged += new DataGridViewCellEventHandler(dgvSelectAll_CellValueChanged);
            dgvSelectAll.CurrentCellDirtyStateChanged += new EventHandler(dgvSelectAll_CurrentCellDirtyStateChanged);
            dgvSelectAll.CellPainting += new DataGridViewCellPaintingEventHandler(dgvSelectAll_CellPainting);

            HeaderCheckBox1.KeyUp += new KeyEventHandler(HeaderCheckBox1_KeyUp); //trial
            HeaderCheckBox1.MouseClick += new MouseEventHandler(HeaderCheckBox1_MouseClick);


            HeaderCheckBox2.KeyUp += new KeyEventHandler(HeaderCheckBox2_KeyUp); //trial
            HeaderCheckBox2.MouseClick += new MouseEventHandler(HeaderCheckBox2_MouseClick);

         HeaderCheckBox3.KeyUp += new KeyEventHandler(HeaderCheckBox3_KeyUp); //trial
            HeaderCheckBox3.MouseClick += new MouseEventHandler(HeaderCheckBox3_MouseClick);
         
        }

        private void frmUserGrants_Load(object sender, EventArgs e)
        {
            Filluser();
            refresh();

         }
     
        private void forms()
        {
            this.dgvSelectAll.Rows.Add("All Master Entry");
            this.dgvSelectAll.Rows.Add("User Setting");
           // this.dgvSelectAll.Rows.Add("All Transactions");
            //this.dgvSelectAll.Rows.Add("All Records");
           // this.dgvSelectAll.Rows.Add("All Reports");
            this.dgvSelectAll.Rows.Add("Backup & Recovery");

            this.dgvSelectAll.Rows.Add("Logs");

            // one by one Rights

            this.dgvSelectAll.Rows.Add("Help and About");
            //this.dgvSelectAll.Rows.Add("School Entry");
            //this.dgvSelectAll.Rows.Add("Class Entry");
            //this.dgvSelectAll.Rows.Add("Section Entry");
            //this.dgvSelectAll.Rows.Add("Departments Entry");
            //this.dgvSelectAll.Rows.Add("Book Entry");
            //this.dgvSelectAll.Rows.Add("Fee Entry");
            //this.dgvSelectAll.Rows.Add("Fee Types");
            //this.dgvSelectAll.Rows.Add("Book Suppliers");
            //this.dgvSelectAll.Rows.Add("Class Fees Entry");
            //this.dgvSelectAll.Rows.Add("Transportation");
            //this.dgvSelectAll.Rows.Add("Hostel Entry");
            //this.dgvSelectAll.Rows.Add("Events");
            //this.dgvSelectAll.Rows.Add("Scholarship Entry");
            //this.dgvSelectAll.Rows.Add("Subject Entry");
            //this.dgvSelectAll.Rows.Add("Marks Entry");
            //this.dgvSelectAll.Rows.Add("Exams Entry");
            // this.dgvSelectAll.Rows.Add("User Registration");
            this.dgvSelectAll.Rows.Add("Login Detail");
           // this.dgvSelectAll.Rows.Add("Employee Entry");
           // this.dgvSelectAll.Rows.Add("Student Entry");
            //this.dgvSelectAll.Rows.Add("Hostelers Entry");
            //this.dgvSelectAll.Rows.Add("Bus Holders");

            //this.dgvSelectAll.Rows.Add("Class Fee Payment");
            //this.dgvSelectAll.Rows.Add("Bus Fee Payment");
            //this.dgvSelectAll.Rows.Add("Hostel Fee Payment");
            //this.dgvSelectAll.Rows.Add("Scholarship Payment");
            //this.dgvSelectAll.Rows.Add("Salary Payment");
            //this.dgvSelectAll.Rows.Add("Book Issue");
            //this.dgvSelectAll.Rows.Add("Book Return");

            //this.dgvSelectAll.Rows.Add("Student Records");

            //this.dgvSelectAll.Rows.Add("Employee Records");
            //this.dgvSelectAll.Rows.Add("Hostelers Records");
            //this.dgvSelectAll.Rows.Add("Bus Holders Records");
            //this.dgvSelectAll.Rows.Add("salary Payment Records");
            //this.dgvSelectAll.Rows.Add("Class Fee Payment Record");
            //this.dgvSelectAll.Rows.Add("Bus Fee Payment Record");
            //this.dgvSelectAll.Rows.Add("Scholarship Payment Record");
            //this.dgvSelectAll.Rows.Add("Hostel Fee Payment Record");
            //this.dgvSelectAll.Rows.Add("Books Record");
            //this.dgvSelectAll.Rows.Add("Student Books Issue Record");
            //this.dgvSelectAll.Rows.Add("Staff Books Issue Record");
            //this.dgvSelectAll.Rows.Add("Book Return Student");
            //this.dgvSelectAll.Rows.Add("Book Return Staff");
            //this.dgvSelectAll.Rows.Add("Event Record");
            //this.dgvSelectAll.Rows.Add("Subject Record");
            //this.dgvSelectAll.Rows.Add("Marks Record");
            //this.dgvSelectAll.Rows.Add("Events Record");

            //this.dgvSelectAll.Rows.Add("Bus Holders Report");
            //this.dgvSelectAll.Rows.Add("Hostelers Report");
            //this.dgvSelectAll.Rows.Add("Class Fee Payment Report");
            //this.dgvSelectAll.Rows.Add("salary Payment Report");
            //this.dgvSelectAll.Rows.Add("Bus Fee Payment Report");
            //this.dgvSelectAll.Rows.Add("Hostel Fee Payment Report");
            //this.dgvSelectAll.Rows.Add("Scholarship Payment Report");
            //this.dgvSelectAll.Rows.Add("Student Report");
            //this.dgvSelectAll.Rows.Add("Employee Report");
            //this.dgvSelectAll.Rows.Add("Student marks Report");
        
        }
       
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dgvSelectAll.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dgvSelectAll.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ControlText;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }
        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modifiy Counter;            
                if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                    TotalCheckedCheckBoxes++;
                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;

                //Change state of the header CheckBox.
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;
            }
        }
       

        private void dgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSelectAll.CurrentCell is DataGridViewCheckBoxCell)
                dgvSelectAll.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

//********* click on header checkbox

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;

        }

        private void HeaderCheckBoxClick1(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect1"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }
        private void HeaderCheckBoxClick2(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect2"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }

        private void HeaderCheckBoxClick3(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect3"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

       
        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }
        private void HeaderCheckBox1_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick1((CheckBox)sender);
        }
        private void HeaderCheckBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick1((CheckBox)sender);
        }

        private void HeaderCheckBox2_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick2((CheckBox)sender);
        }
        private void HeaderCheckBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick2((CheckBox)sender);
        }


        private void HeaderCheckBox3_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick3((CheckBox)sender);
        }
        private void HeaderCheckBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick3((CheckBox)sender);
        }

//************************************************************** locations*********
        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)  //for cell painting event
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }
        private void dgvSelectAll_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) //set location of header
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);

            if (e.RowIndex == -1 && e.ColumnIndex == 2)
                ResetHeaderCheckBoxLocation1(e.ColumnIndex, e.RowIndex);

            if (e.RowIndex == -1 && e.ColumnIndex == 3)
                ResetHeaderCheckBoxLocation2(e.ColumnIndex, e.RowIndex);

             if (e.RowIndex == -1 && e.ColumnIndex == 4)
                ResetHeaderCheckBoxLocation3(e.ColumnIndex, e.RowIndex);
        }
        

      

        private void ResetHeaderCheckBoxLocation1(int ColumnIndex, int RowIndex)  //for cell painting event
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox1.Width) / 2+ 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox1.Height) / 2+1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox1.Location = oPoint;
        }
        private void ResetHeaderCheckBoxLocation2(int ColumnIndex, int RowIndex)  //for cell painting event
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox2.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox2.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox2.Location = oPoint;
        }
private void ResetHeaderCheckBoxLocation3(int ColumnIndex, int RowIndex)  //for cell painting event
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox3.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox3.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox3.Location = oPoint;
        }

public void Filluser()
{
    try
    {

        con = new SqlConnection(cs.DBcon);
        con.Open();
        string ct1 = "SELECT distinct RTRIM(UserID) FROM User_Registration";
        cmd = new SqlCommand(ct1);
        cmd.Connection = con;
        rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            cmbuserRegistration.Items.Add(rdr[0]);

        }
        con.Close();

    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


      
private void btnSave_Click(object sender, EventArgs e)
{
    con = new SqlConnection(cs.DBcon);
    con.Open();
    string ct = "SELECT RTRIM(UserGrants.Forms), RTRIM(UserGrants.Saves), RTRIM(UserGrants.Updates), RTRIM(UserGrants.Deletes), RTRIM(UserGrants.ViewRecord) FROM  User_Registration INNER JOIN UserGrants ON User_Registration.ID = UserGrants.UserID  where User_Registration.userID = '"+cmbuserRegistration.Text+"'";

    cmd = new SqlCommand(ct);
    cmd.Connection = con;
    rdr = cmd.ExecuteReader();

    if (rdr.Read())
    {
        MessageBox.Show("Permissions already saved for this user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        cmbuserRegistration.Text ="";
        textBox1.Text = "";
        dgvSelectAll.Rows.Clear();

        if ((rdr != null))
        {
            rdr.Close();
        }
        return;
    }
    con = new SqlConnection(cs.DBcon);
    con.Open();

    string cb = "insert into Usergrants(Forms,Saves,updates,Deletes,viewRecord,UserID) VALUES (@1,@2,@3,@4,@5,"+ textBox1.Text +")";

    cmd = new SqlCommand(cb);
    cmd.Connection = con;

    cmd.Parameters.Add(new SqlParameter("@1", System.Data.SqlDbType.NChar, 100, "Forms"));

    cmd.Parameters.Add(new SqlParameter("@2", System.Data.SqlDbType.NChar, 10, "Saves"));

    cmd.Parameters.Add(new SqlParameter("@3", System.Data.SqlDbType.NChar, 10, "updates"));

    cmd.Parameters.Add(new SqlParameter("@4", System.Data.SqlDbType.NChar, 10, "deletes"));
    cmd.Parameters.Add(new SqlParameter("@5", System.Data.SqlDbType.NChar, 10, "viewRecords"));
   
     cmd.Prepare();

     foreach (DataGridViewRow row in dgvSelectAll.Rows)
     {
         if (Convert.ToBoolean(row.Cells["chkBxSelect"].Value) == false)
             row.Cells["chkBxSelect"].Value = false;
         else
             row.Cells["chkBxSelect"].Value = true;

         if (Convert.ToBoolean(row.Cells["chkBxSelect1"].Value) == false)
             row.Cells["chkBxSelect1"].Value = false;
         else
             row.Cells["chkBxSelect1"].Value = true;

         if (Convert.ToBoolean(row.Cells["chkBxSelect2"].Value) == false)
             row.Cells["chkBxSelect2"].Value = false;
         else
             row.Cells["chkBxSelect2"].Value = true;

         if (Convert.ToBoolean(row.Cells["chkBxSelect3"].Value) == false)
             row.Cells["chkBxSelect3"].Value = false;
         else
             row.Cells["chkBxSelect3"].Value = true;

         if (!row.IsNewRow)
         {
             
             cmd.Parameters["@1"].Value = row.Cells[0].Value;
             cmd.Parameters["@2"].Value = row.Cells[1].Value;
             cmd.Parameters["@3"].Value = row.Cells[2].Value;
             cmd.Parameters["@4"].Value = row.Cells[3].Value;
             cmd.Parameters["@5"].Value = row.Cells[4].Value;
             cmd.ExecuteNonQuery();
           
       }
     }
    con.Close();

    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
    btnSave.Enabled = false;

 
}

private void cmbuserRegistration_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {

       
        con = new SqlConnection(cs.DBcon);

        con.Open();
        cmd = con.CreateCommand();

        cmd.CommandText = "SELECT distinct ID FROM User_Registration where UserID = '" + cmbuserRegistration.Text + "'";
        rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            textBox1.Text = rdr.GetInt32(0).ToString().Trim();
          
        }
      
      
        if ((rdr != null))
        {
            rdr.Close();
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

public void getrecord()
{
    con = new SqlConnection(cs.DBcon);

    con.Open();
    cmd = new SqlCommand("SELECT RTRIM(UserGrants.Forms), RTRIM(UserGrants.Saves), RTRIM(UserGrants.Updates), RTRIM(UserGrants.Deletes), RTRIM(UserGrants.ViewRecord) FROM  User_Registration INNER JOIN UserGrants ON User_Registration.ID = UserGrants.UserID  where User_Registration.userID = '" + cmbuserRegistration.Text + "'", con);
    rdr = cmd.ExecuteReader();
    dgvSelectAll.Rows.Clear();
    while (rdr.Read())
    {
        dgvSelectAll.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
    }
    con.Close();
   
    btnupdate.Enabled = true;

}
private void button3_Click(object sender, EventArgs e)
{
    try
    {

        getrecord();
        con = new SqlConnection(cs.DBcon);

        con.Open();
        cmd = con.CreateCommand();

        cmd.CommandText = "SELECT distinct UserID FROM Usergrants where UserID = '" + textBox1.Text + "'";
        rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            btnSave.Enabled = false;
            btnupdate.Enabled = true;


        }
        else
        {
            refresh();
            btnSave.Enabled = true;
            btnupdate.Enabled = false;
        }

        if ((rdr != null))
        {
            rdr.Close();
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

private void btnupdate_Click(object sender, EventArgs e)
{
    try
    {
        if (textBox1.Text == "1")
        {
            MessageBox.Show("Super User Can not be Updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox1.Focus();
            return;
        }
    con = new SqlConnection(cs.DBcon);
    con.Open();
    string cb1 = "Delete from usergrants where UserID=" + textBox1.Text+ "";
    cmd = new SqlCommand(cb1);
    cmd.Connection = con;
    cmd.ExecuteReader();
    con.Close();


    con = new SqlConnection(cs.DBcon);
    con.Open();

    string cb = "insert into Usergrants(Forms,Saves,updates,Deletes,viewRecord,UserID) VALUES (@1,@2,@3,@4,@5," + textBox1.Text + ")";

    cmd = new SqlCommand(cb);
    cmd.Connection = con;

    cmd.Parameters.Add(new SqlParameter("@1", System.Data.SqlDbType.NChar, 100, "Forms"));

    cmd.Parameters.Add(new SqlParameter("@2", System.Data.SqlDbType.NChar, 10, "Saves"));

    cmd.Parameters.Add(new SqlParameter("@3", System.Data.SqlDbType.NChar, 10, "updates"));

    cmd.Parameters.Add(new SqlParameter("@4", System.Data.SqlDbType.NChar, 10, "deletes"));
    cmd.Parameters.Add(new SqlParameter("@5", System.Data.SqlDbType.NChar, 10, "viewRecords"));

    cmd.Prepare();

    foreach (DataGridViewRow row in dgvSelectAll.Rows)
    {
        if (Convert.ToBoolean(row.Cells["chkBxSelect"].Value) == false)
            row.Cells["chkBxSelect"].Value = false;
        else
            row.Cells["chkBxSelect"].Value = true;

        if (Convert.ToBoolean(row.Cells["chkBxSelect1"].Value) == false)
            row.Cells["chkBxSelect1"].Value = false;
        else
            row.Cells["chkBxSelect1"].Value = true;

        if (Convert.ToBoolean(row.Cells["chkBxSelect2"].Value) == false)
            row.Cells["chkBxSelect2"].Value = false;
        else
            row.Cells["chkBxSelect2"].Value = true;

        if (Convert.ToBoolean(row.Cells["chkBxSelect3"].Value) == false)
            row.Cells["chkBxSelect3"].Value = false;
        else
            row.Cells["chkBxSelect3"].Value = true;

        if (!row.IsNewRow)
        {

            cmd.Parameters["@1"].Value = row.Cells[0].Value;
            cmd.Parameters["@2"].Value = row.Cells[1].Value;
            cmd.Parameters["@3"].Value = row.Cells[2].Value;
            cmd.Parameters["@4"].Value = row.Cells[3].Value;
            cmd.Parameters["@5"].Value = row.Cells[4].Value;
            cmd.ExecuteNonQuery();

        }
    }
    con.Close();

    MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
    btnupdate.Enabled = false;
}
          catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

}

private void lblUserType_Click(object sender, EventArgs e)
{

}

private void frmUserGrants_FormClosing(object sender, FormClosingEventArgs e)
{
    this.Hide();
    frm_Main_Menu frm = new frm_Main_Menu();
    frm.UserType.Text = lblUserType.Text;
    frm.User.Text = lblUser.Text;
    frm.Show();
}

private void label1_Click(object sender, EventArgs e)
{

}

private void button1_Click(object sender, EventArgs e)
{
    dgvSelectAll.Rows.Clear();
    refresh();
}






       
    }

}