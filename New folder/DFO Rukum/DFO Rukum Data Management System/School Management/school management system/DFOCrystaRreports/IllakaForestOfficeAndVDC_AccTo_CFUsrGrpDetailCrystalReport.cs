﻿using System;
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
using school_management_system.DFOCrystaRreports;

namespace school_management_system.DFOCrystaRreports
{
    public partial class IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetailCrystalReport : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetailCrystalReport()
        {
            InitializeComponent();
        }
        public void AutocompleFiscalYear()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();


                string ct = "select distinct RTRIM(PresentFYName) from tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbFiscalYear.Items.Add(rdr[0]);

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AutocompleFileNo()
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();


                string ct = "select distinct RTRIM(FileNo) from tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbFileNo.Items.Add(rdr[0]);

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getdata()
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                RptIllakaFOFNVDC_AccTo_CFUGDtls rpt = new RptIllakaFOFNVDC_AccTo_CFUGDtls();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                //The DataSet you created.


                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select *  from tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails ";

                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "IllakaFOFNVDC_AccTo_CFUGDtls");
                rpt.SetDataSource(myDS);

                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetailCrystalReport_Load(object sender, EventArgs e)
        {
            getdata();
            AutocompleFiscalYear();
            AutocompleFileNo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                RptIllakaFOFNVDC_AccTo_CFUGDtls rpt = new RptIllakaFOFNVDC_AccTo_CFUGDtls();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                //The DataSet you created.


                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;


                MyCommand.CommandText = "select *  from tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails where  tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails.FileNo = '" + cmbFileNo.Text + "' or tbl_IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetails.PresentFYName = '" + cmbFiscalYear.Text + "'";

                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "IllakaFOFNVDC_AccTo_CFUGDtls");
                rpt.SetDataSource(myDS);

                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                cmbFileNo.Text = "";
                cmbFiscalYear.Text = "";
                crystalReportViewer1.ReportSource = null;
                getdata();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IllakaForestOfficeAndVDC_AccTo_CFUsrGrpDetailCrystalReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm_Main_Menu frm = new frm_Main_Menu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }
    }
}
