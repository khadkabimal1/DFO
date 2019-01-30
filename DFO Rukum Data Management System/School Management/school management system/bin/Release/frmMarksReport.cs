using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace school_management_system
{
    public partial class frmMarksReport : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
      
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmMarksReport()
        {
            InitializeComponent();
        }
        public void AutocompleSession()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();


                string ct = "select distinct RTRIM(student.Session) from MarksEntry,student where student.admissionNo=marksentry.admissionNo ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSession.Items.Add(rdr[0]);

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        public void AutocompleExam()
        {
            try
            {
                
                
                con = new SqlConnection(cs.DBcon);
                con.Open();


                string ct = "select distinct RTRIM(Exams.ExamName) from Exams,marksentry where exams.id = marksentry.examid "; 

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbExam.Items.Add(rdr[0]);

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmMarksReport_Load(object sender, EventArgs e)
        {
            AutocompleExam();
            AutocompleSession();
            cmbSession.Enabled = true;
       
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCourse.Items.Clear();
            cmbCourse.Text = "";
            cmbCourse.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select distinct RTRIM(Student.class) from MarksEntry,student where student.admissionNo = marksentry.admissionNo and student.session = '" + cmbSession.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCourse.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbSection.Items.Clear();
            cmbSection.Text = "";
            cmbSection.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();


                string ct = "select distinct RTRIM(student.Section) from MarksEntry,student where student.admissionNo=marksentry.admissionNo and student.class = '" + cmbCourse.Text + "' and student.session='" + cmbSession.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSection.Items.Add(rdr[0]);
                }
                con.Close();
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCourse.Text = "";
           
            cmbSession.Text = "";
            cmbCourse.Enabled = false;
            cmbSection.Text = "";
            cmbSection.Enabled = false;
            cmbExam.Text = "";
            cmbExam.Enabled = false;
            crystalReportViewer1.ReportSource = null;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbCourse.Text == "")
            {
                MessageBox.Show("Please select course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCourse.Focus();
                return;
            }
          

            if (cmbSection.Text == "")
            {
                MessageBox.Show("Please select section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSection.Focus();
                return;
            }
            try
            {
                
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptmarks rpt = new  rptmarks();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                Marks myDS = new Marks();
                //The DataSet you created.


                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT Exams.ID, Exams.ExamName, Exams.ExamType, MarksEntry.AdmissionNo, MarksEntry.SubjectCode, MarksEntry.ExamDate, MarksEntry.MinMarks, MarksEntry.Maxmarks, MarksEntry.MarksObtained,MarksEntry.Statuss, MarksEntry.ID AS Expr1, MarksEntry.ExamID, Subject.SubjectCode AS Expr2, Subject.SubjectName, Subject.ClassName, Student.AdmissionNo AS Expr3, Student.EnrollmentNo,Student.StudentName, Student.FatherName, Student.MotherName, Student.FatherCN, Student.PermanentAddress, Student.TemporaryAddress, Student.ContactNo, Student.EmailID, Student.DOB, Student.Gender,Student.AdmissionDate, Student.Session, Student.Caste, Student.Religion, Student.Photo, Student.Status, Student.Nationality, Student.Class, Student.Section, Student.SchoolID FROM Exams INNER JOIN MarksEntry ON Exams.ID = MarksEntry.ExamID INNER JOIN Subject ON MarksEntry.SubjectCode = Subject.SubjectCode INNER JOIN Student ON MarksEntry.AdmissionNo = Student.AdmissionNo where student.Class= '" + cmbCourse.Text + "'and student.Section='" + cmbSection.Text + "' and Exams.ExamName='" + cmbExam.Text + "' order by ExamDate";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "MarksEntry");
                myDA.Fill(myDS, "Student");
                myDA.Fill(myDS, "Subject");
                myDA.Fill(myDS, "Exams");
       
                    rpt.SetDataSource(myDS);
                    crystalReportViewer1.ReportSource = rpt;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbExam.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void frmMarksReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbCourse.Text == "")
            {
                MessageBox.Show("Please select course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCourse.Focus();
                return;
            }


            if (cmbSection.Text == "")
            {
                MessageBox.Show("Please select section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSection.Focus();
                return;
            }
            try
            {

                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptstudentmarks rpt = new  rptstudentmarks();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                Marks myDS = new  Marks();
                //The DataSet you created.


                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT Exams.ID, Exams.ExamName, Exams.ExamType, MarksEntry.AdmissionNo, MarksEntry.SubjectCode, MarksEntry.ExamDate, MarksEntry.MinMarks, MarksEntry.Maxmarks, MarksEntry.MarksObtained,MarksEntry.Statuss, MarksEntry.ID AS Expr1, MarksEntry.ExamID, Subject.SubjectCode AS Expr2, Subject.SubjectName, Subject.ClassName, Student.AdmissionNo AS Expr3, Student.EnrollmentNo,Student.StudentName, Student.FatherName, Student.MotherName, Student.FatherCN, Student.PermanentAddress, Student.TemporaryAddress, Student.ContactNo, Student.EmailID, Student.DOB, Student.Gender,Student.AdmissionDate, Student.Session, Student.Caste, Student.Religion, Student.Photo, Student.Status, Student.Nationality, Student.Class, Student.Section, Student.SchoolID FROM Exams INNER JOIN MarksEntry ON Exams.ID = MarksEntry.ExamID INNER JOIN Subject ON MarksEntry.SubjectCode = Subject.SubjectCode INNER JOIN Student ON MarksEntry.AdmissionNo = Student.AdmissionNo where student.Class= '" + cmbCourse.Text + "'and student.Section='" + cmbSection.Text + "' and Exams.ExamName='" + cmbExam.Text + "' order by ExamDate";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "MarksEntry");
                myDA.Fill(myDS, "Student");
                myDA.Fill(myDS, "Subject");
                myDA.Fill(myDS, "Exams");

                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
