namespace school_management_system.Inventory
{
    partial class FiscalYearEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiscalYearEntry));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtenddate_nep = new System.Windows.Forms.TextBox();
            this.dpenddate_eng = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtstartdate_nep = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dpstartdate_eng = new System.Windows.Forms.DateTimePicker();
            this.IsActive = new System.Windows.Forms.CheckBox();
            this.txtFiscal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblview = new System.Windows.Forms.Label();
            this.lblset1 = new System.Windows.Forms.Label();
            this.lblSet3 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblupdate = new System.Windows.Forms.Label();
            this.lbldel = new System.Windows.Forms.Label();
            this.lblSaves = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Update_record = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.NewRecord = new System.Windows.Forms.Button();
            this.dgvFiscalYear = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiscalYear)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtenddate_nep);
            this.groupBox2.Controls.Add(this.dpenddate_eng);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(3, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 75);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "BS";
            // 
            // txtenddate_nep
            // 
            this.txtenddate_nep.Location = new System.Drawing.Point(162, 28);
            this.txtenddate_nep.Name = "txtenddate_nep";
            this.txtenddate_nep.Size = new System.Drawing.Size(122, 21);
            this.txtenddate_nep.TabIndex = 10;
            // 
            // dpenddate_eng
            // 
            this.dpenddate_eng.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpenddate_eng.Location = new System.Drawing.Point(18, 28);
            this.dpenddate_eng.Name = "dpenddate_eng";
            this.dpenddate_eng.Size = new System.Drawing.Size(126, 21);
            this.dpenddate_eng.TabIndex = 9;
            this.dpenddate_eng.ValueChanged += new System.EventHandler(this.dpenddate_eng_ValueChanged);
            this.dpenddate_eng.Leave += new System.EventHandler(this.dpenddate_eng_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "AD";
            // 
            // txtstartdate_nep
            // 
            this.txtstartdate_nep.Location = new System.Drawing.Point(162, 28);
            this.txtstartdate_nep.Name = "txtstartdate_nep";
            this.txtstartdate_nep.Size = new System.Drawing.Size(122, 21);
            this.txtstartdate_nep.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "BS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtstartdate_nep);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dpstartdate_eng);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(3, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 75);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "AD";
            // 
            // dpstartdate_eng
            // 
            this.dpstartdate_eng.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpstartdate_eng.Location = new System.Drawing.Point(18, 28);
            this.dpstartdate_eng.Name = "dpstartdate_eng";
            this.dpstartdate_eng.Size = new System.Drawing.Size(126, 21);
            this.dpstartdate_eng.TabIndex = 8;
            this.dpstartdate_eng.ValueChanged += new System.EventHandler(this.dpstartdate_eng_ValueChanged);
            this.dpstartdate_eng.Leave += new System.EventHandler(this.dpstartdate_eng_Leave);
            // 
            // IsActive
            // 
            this.IsActive.AutoSize = true;
            this.IsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsActive.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.IsActive.Location = new System.Drawing.Point(10, 200);
            this.IsActive.Name = "IsActive";
            this.IsActive.Size = new System.Drawing.Size(78, 19);
            this.IsActive.TabIndex = 18;
            this.IsActive.Text = "Is Active";
            this.IsActive.UseVisualStyleBackColor = true;
            // 
            // txtFiscal
            // 
            this.txtFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiscal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFiscal.Location = new System.Drawing.Point(96, 6);
            this.txtFiscal.Name = "txtFiscal";
            this.txtFiscal.Size = new System.Drawing.Size(191, 21);
            this.txtFiscal.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(11, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fiscal Year";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 131);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 103;
            this.textBox1.Visible = false;
            // 
            // lblview
            // 
            this.lblview.AutoSize = true;
            this.lblview.Location = new System.Drawing.Point(459, 131);
            this.lblview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblview.Name = "lblview";
            this.lblview.Size = new System.Drawing.Size(29, 13);
            this.lblview.TabIndex = 102;
            this.lblview.Text = "view";
            this.lblview.Visible = false;
            // 
            // lblset1
            // 
            this.lblset1.AutoSize = true;
            this.lblset1.Location = new System.Drawing.Point(404, 135);
            this.lblset1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblset1.Name = "lblset1";
            this.lblset1.Size = new System.Drawing.Size(35, 13);
            this.lblset1.TabIndex = 101;
            this.lblset1.Text = "label1";
            this.lblset1.Visible = false;
            // 
            // lblSet3
            // 
            this.lblSet3.AutoSize = true;
            this.lblSet3.Location = new System.Drawing.Point(414, 118);
            this.lblSet3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSet3.Name = "lblSet3";
            this.lblSet3.Size = new System.Drawing.Size(29, 13);
            this.lblSet3.TabIndex = 100;
            this.lblSet3.Text = "Set3";
            this.lblSet3.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(402, 101);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 99;
            this.lblUser.Text = "User";
            this.lblUser.Visible = false;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(402, 137);
            this.lblUserType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(53, 13);
            this.lblUserType.TabIndex = 98;
            this.lblUserType.Text = "UserType";
            this.lblUserType.Visible = false;
            // 
            // lblupdate
            // 
            this.lblupdate.AutoSize = true;
            this.lblupdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblupdate.Location = new System.Drawing.Point(435, 109);
            this.lblupdate.Name = "lblupdate";
            this.lblupdate.Size = new System.Drawing.Size(19, 13);
            this.lblupdate.TabIndex = 107;
            this.lblupdate.Text = "up";
            this.lblupdate.Visible = false;
            // 
            // lbldel
            // 
            this.lbldel.AutoSize = true;
            this.lbldel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbldel.Location = new System.Drawing.Point(422, 122);
            this.lbldel.Name = "lbldel";
            this.lbldel.Size = new System.Drawing.Size(21, 13);
            this.lbldel.TabIndex = 106;
            this.lbldel.Text = "del";
            this.lbldel.Visible = false;
            // 
            // lblSaves
            // 
            this.lblSaves.AutoSize = true;
            this.lblSaves.Location = new System.Drawing.Point(422, 90);
            this.lblSaves.Name = "lblSaves";
            this.lblSaves.Size = new System.Drawing.Size(32, 13);
            this.lblSaves.TabIndex = 105;
            this.lblSaves.Text = "Save";
            this.lblSaves.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(422, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "UserType";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Update_record);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.NewRecord);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(363, 206);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 44);
            this.panel1.TabIndex = 108;
            // 
            // Update_record
            // 
            this.Update_record.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Update_record.Enabled = false;
            this.Update_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_record.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_record.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Update_record.Location = new System.Drawing.Point(351, 3);
            this.Update_record.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Update_record.Name = "Update_record";
            this.Update_record.Size = new System.Drawing.Size(96, 35);
            this.Update_record.TabIndex = 3;
            this.Update_record.Text = "&Update";
            this.Update_record.UseVisualStyleBackColor = false;
            this.Update_record.Click += new System.EventHandler(this.Update_record_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Red;
            this.Delete.Enabled = false;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Delete.Location = new System.Drawing.Point(240, 3);
            this.Delete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(96, 35);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "&Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(129, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // NewRecord
            // 
            this.NewRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.NewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewRecord.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRecord.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewRecord.Location = new System.Drawing.Point(19, 3);
            this.NewRecord.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.NewRecord.Name = "NewRecord";
            this.NewRecord.Size = new System.Drawing.Size(96, 35);
            this.NewRecord.TabIndex = 0;
            this.NewRecord.Text = "&New";
            this.NewRecord.UseVisualStyleBackColor = false;
            this.NewRecord.Click += new System.EventHandler(this.NewRecord_Click);
            // 
            // dgvFiscalYear
            // 
            this.dgvFiscalYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiscalYear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvFiscalYear.Location = new System.Drawing.Point(303, 6);
            this.dgvFiscalYear.Name = "dgvFiscalYear";
            this.dgvFiscalYear.Size = new System.Drawing.Size(640, 192);
            this.dgvFiscalYear.TabIndex = 109;
            this.dgvFiscalYear.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiscalYear_CellContentClick);
            this.dgvFiscalYear.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFiscalYear_RowHeaderMouseClick_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "fy_Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Fiscal Year";
            this.Column7.Name = "Column7";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Start Date Eng";
            this.Column2.Name = "Column2";
            this.Column2.Width = 110;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Start Date Nep";
            this.Column3.Name = "Column3";
            this.Column3.Width = 110;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "End Date Eng";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "End Date Nep";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "IsActive";
            this.Column6.Name = "Column6";
            // 
            // FiscalYearEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(955, 258);
            this.Controls.Add(this.dgvFiscalYear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblupdate);
            this.Controls.Add(this.lbldel);
            this.Controls.Add(this.lblSaves);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblview);
            this.Controls.Add(this.lblset1);
            this.Controls.Add(this.lblSet3);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IsActive);
            this.Controls.Add(this.txtFiscal);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FiscalYearEntry";
            this.Text = "FiscalYearEntry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiscalYearEntry_FormClosing);
            this.Load += new System.EventHandler(this.FiscalYearEntry_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiscalYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtenddate_nep;
        private System.Windows.Forms.DateTimePicker dpenddate_eng;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtstartdate_nep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dpstartdate_eng;
        private System.Windows.Forms.CheckBox IsActive;
        private System.Windows.Forms.TextBox txtFiscal;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label lblview;
        public System.Windows.Forms.Label lblset1;
        public System.Windows.Forms.Label lblSet3;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblUserType;
        public System.Windows.Forms.Label lblupdate;
        public System.Windows.Forms.Label lbldel;
        public System.Windows.Forms.Label lblSaves;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button Update_record;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button NewRecord;
        private System.Windows.Forms.DataGridView dgvFiscalYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}