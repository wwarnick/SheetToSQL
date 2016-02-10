namespace SheetToSQL
{
	partial class frmMain
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
			this.btnOpen = new System.Windows.Forms.Button();
			this.lstColumns = new System.Windows.Forms.ListBox();
			this.lblSQLFirstLine = new System.Windows.Forms.Label();
			this.cmbBlankBehavior = new System.Windows.Forms.ComboBox();
			this.lblBlankBehavior = new System.Windows.Forms.Label();
			this.pnlFile = new System.Windows.Forms.Panel();
			this.lblProgress = new System.Windows.Forms.Label();
			this.pnlSettings = new System.Windows.Forms.Panel();
			this.txtSQLFirstLine = new System.Windows.Forms.TextBox();
			this.txtSQLRecur = new System.Windows.Forms.TextBox();
			this.pnlColumn = new System.Windows.Forms.Panel();
			this.lblHeaderName = new System.Windows.Forms.Label();
			this.btnSaveAs = new System.Windows.Forms.Button();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.dlgSaveAs = new System.Windows.Forms.SaveFileDialog();
			this.lblSQLRecurring = new System.Windows.Forms.Label();
			this.pnlFile.SuspendLayout();
			this.pnlSettings.SuspendLayout();
			this.pnlColumn.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(12, 12);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// lstColumns
			// 
			this.lstColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lstColumns.FormattingEnabled = true;
			this.lstColumns.Location = new System.Drawing.Point(11, 42);
			this.lstColumns.Name = "lstColumns";
			this.lstColumns.Size = new System.Drawing.Size(149, 173);
			this.lstColumns.TabIndex = 0;
			this.lstColumns.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstColumns_DrawItem);
			this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
			// 
			// lblSQLFirstLine
			// 
			this.lblSQLFirstLine.AutoSize = true;
			this.lblSQLFirstLine.Location = new System.Drawing.Point(2, 14);
			this.lblSQLFirstLine.Name = "lblSQLFirstLine";
			this.lblSQLFirstLine.Size = new System.Drawing.Size(76, 13);
			this.lblSQLFirstLine.TabIndex = 5;
			this.lblSQLFirstLine.Text = "SQL First Line:";
			// 
			// cmbBlankBehavior
			// 
			this.cmbBlankBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBlankBehavior.FormattingEnabled = true;
			this.cmbBlankBehavior.Location = new System.Drawing.Point(141, 89);
			this.cmbBlankBehavior.Name = "cmbBlankBehavior";
			this.cmbBlankBehavior.Size = new System.Drawing.Size(121, 21);
			this.cmbBlankBehavior.TabIndex = 6;
			// 
			// lblBlankBehavior
			// 
			this.lblBlankBehavior.AutoSize = true;
			this.lblBlankBehavior.Location = new System.Drawing.Point(23, 92);
			this.lblBlankBehavior.Name = "lblBlankBehavior";
			this.lblBlankBehavior.Size = new System.Drawing.Size(112, 13);
			this.lblBlankBehavior.TabIndex = 7;
			this.lblBlankBehavior.Text = "Blank Value Behavior:";
			// 
			// pnlFile
			// 
			this.pnlFile.BackColor = System.Drawing.SystemColors.Control;
			this.pnlFile.Controls.Add(this.lblProgress);
			this.pnlFile.Controls.Add(this.pnlSettings);
			this.pnlFile.Controls.Add(this.pnlColumn);
			this.pnlFile.Controls.Add(this.btnSaveAs);
			this.pnlFile.Controls.Add(this.lstColumns);
			this.pnlFile.Location = new System.Drawing.Point(1, -1);
			this.pnlFile.Name = "pnlFile";
			this.pnlFile.Size = new System.Drawing.Size(659, 220);
			this.pnlFile.TabIndex = 8;
			// 
			// lblProgress
			// 
			this.lblProgress.Location = new System.Drawing.Point(173, 13);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(260, 23);
			this.lblProgress.TabIndex = 15;
			// 
			// pnlSettings
			// 
			this.pnlSettings.BackColor = System.Drawing.Color.Transparent;
			this.pnlSettings.Controls.Add(this.lblSQLRecurring);
			this.pnlSettings.Controls.Add(this.txtSQLFirstLine);
			this.pnlSettings.Controls.Add(this.txtSQLRecur);
			this.pnlSettings.Controls.Add(this.lblSQLFirstLine);
			this.pnlSettings.Location = new System.Drawing.Point(439, 4);
			this.pnlSettings.Name = "pnlSettings";
			this.pnlSettings.Size = new System.Drawing.Size(218, 216);
			this.pnlSettings.TabIndex = 13;
			// 
			// txtSQLFirstLine
			// 
			this.txtSQLFirstLine.Location = new System.Drawing.Point(5, 30);
			this.txtSQLFirstLine.Multiline = true;
			this.txtSQLFirstLine.Name = "txtSQLFirstLine";
			this.txtSQLFirstLine.Size = new System.Drawing.Size(205, 77);
			this.txtSQLFirstLine.TabIndex = 7;
			// 
			// txtSQLRecur
			// 
			this.txtSQLRecur.Location = new System.Drawing.Point(5, 127);
			this.txtSQLRecur.Multiline = true;
			this.txtSQLRecur.Name = "txtSQLRecur";
			this.txtSQLRecur.Size = new System.Drawing.Size(205, 82);
			this.txtSQLRecur.TabIndex = 6;
			// 
			// pnlColumn
			// 
			this.pnlColumn.BackColor = System.Drawing.Color.Silver;
			this.pnlColumn.Controls.Add(this.lblHeaderName);
			this.pnlColumn.Controls.Add(this.cmbBlankBehavior);
			this.pnlColumn.Controls.Add(this.lblBlankBehavior);
			this.pnlColumn.Location = new System.Drawing.Point(166, 42);
			this.pnlColumn.Name = "pnlColumn";
			this.pnlColumn.Size = new System.Drawing.Size(271, 178);
			this.pnlColumn.TabIndex = 12;
			// 
			// lblHeaderName
			// 
			this.lblHeaderName.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.lblHeaderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHeaderName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.lblHeaderName.Location = new System.Drawing.Point(3, 3);
			this.lblHeaderName.Name = "lblHeaderName";
			this.lblHeaderName.Size = new System.Drawing.Size(265, 23);
			this.lblHeaderName.TabIndex = 14;
			this.lblHeaderName.Text = "lblHeaderName";
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Location = new System.Drawing.Point(92, 13);
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
			this.btnSaveAs.TabIndex = 9;
			this.btnSaveAs.Text = "Save As...";
			this.btnSaveAs.UseVisualStyleBackColor = true;
			this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
			// 
			// dlgOpen
			// 
			this.dlgOpen.Filter = "All Supported Types [*.xlsx, *.csv]|*.xlsx;*.csv|Excel Files|*.xlsx|CSV Files|*.c" +
    "sv";
			// 
			// dlgSaveAs
			// 
			this.dlgSaveAs.DefaultExt = "sql";
			this.dlgSaveAs.Filter = "SQL Files|*.sql";
			// 
			// lblSQLRecurring
			// 
			this.lblSQLRecurring.AutoSize = true;
			this.lblSQLRecurring.Location = new System.Drawing.Point(4, 110);
			this.lblSQLRecurring.Name = "lblSQLRecurring";
			this.lblSQLRecurring.Size = new System.Drawing.Size(80, 13);
			this.lblSQLRecurring.TabIndex = 8;
			this.lblSQLRecurring.Text = "SQL Recurring:";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 224);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.pnlFile);
			this.Name = "frmMain";
			this.Text = "SQLBuilder";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.pnlFile.ResumeLayout(false);
			this.pnlSettings.ResumeLayout(false);
			this.pnlSettings.PerformLayout();
			this.pnlColumn.ResumeLayout(false);
			this.pnlColumn.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.ListBox lstColumns;
		private System.Windows.Forms.Label lblSQLFirstLine;
		private System.Windows.Forms.ComboBox cmbBlankBehavior;
		private System.Windows.Forms.Label lblBlankBehavior;
		private System.Windows.Forms.Panel pnlFile;
		private System.Windows.Forms.Button btnSaveAs;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.SaveFileDialog dlgSaveAs;
		private System.Windows.Forms.Panel pnlColumn;
		private System.Windows.Forms.Panel pnlSettings;
		private System.Windows.Forms.Label lblHeaderName;
		private System.Windows.Forms.TextBox txtSQLRecur;
		private System.Windows.Forms.TextBox txtSQLFirstLine;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Label lblSQLRecurring;
	}
}

