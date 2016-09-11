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
			this.lblSQLRecurring = new System.Windows.Forms.Label();
			this.txtSQLFirstLine = new System.Windows.Forms.TextBox();
			this.txtSQLRecur = new System.Windows.Forms.TextBox();
			this.pnlColumn = new System.Windows.Forms.Panel();
			this.lblHeaderName = new System.Windows.Forms.Label();
			this.btnSaveAs = new System.Windows.Forms.Button();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.dlgSaveAs = new System.Windows.Forms.SaveFileDialog();
			this.btnHelp = new System.Windows.Forms.Button();
			this.pnlFile.SuspendLayout();
			this.pnlSettings.SuspendLayout();
			this.pnlColumn.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(16, 15);
			this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(100, 28);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// lstColumns
			// 
			this.lstColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lstColumns.FormattingEnabled = true;
			this.lstColumns.Location = new System.Drawing.Point(15, 52);
			this.lstColumns.Margin = new System.Windows.Forms.Padding(4);
			this.lstColumns.Name = "lstColumns";
			this.lstColumns.Size = new System.Drawing.Size(197, 212);
			this.lstColumns.TabIndex = 0;
			this.lstColumns.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstColumns_DrawItem);
			this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
			// 
			// lblSQLFirstLine
			// 
			this.lblSQLFirstLine.AutoSize = true;
			this.lblSQLFirstLine.Location = new System.Drawing.Point(3, 17);
			this.lblSQLFirstLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSQLFirstLine.Name = "lblSQLFirstLine";
			this.lblSQLFirstLine.Size = new System.Drawing.Size(102, 17);
			this.lblSQLFirstLine.TabIndex = 5;
			this.lblSQLFirstLine.Text = "SQL First Line:";
			// 
			// cmbBlankBehavior
			// 
			this.cmbBlankBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBlankBehavior.FormattingEnabled = true;
			this.cmbBlankBehavior.Location = new System.Drawing.Point(188, 110);
			this.cmbBlankBehavior.Margin = new System.Windows.Forms.Padding(4);
			this.cmbBlankBehavior.Name = "cmbBlankBehavior";
			this.cmbBlankBehavior.Size = new System.Drawing.Size(160, 24);
			this.cmbBlankBehavior.TabIndex = 6;
			// 
			// lblBlankBehavior
			// 
			this.lblBlankBehavior.AutoSize = true;
			this.lblBlankBehavior.Location = new System.Drawing.Point(31, 113);
			this.lblBlankBehavior.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBlankBehavior.Name = "lblBlankBehavior";
			this.lblBlankBehavior.Size = new System.Drawing.Size(147, 17);
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
			this.pnlFile.Location = new System.Drawing.Point(0, 0);
			this.pnlFile.Margin = new System.Windows.Forms.Padding(4);
			this.pnlFile.MinimumSize = new System.Drawing.Size(879, 271);
			this.pnlFile.Name = "pnlFile";
			this.pnlFile.Size = new System.Drawing.Size(879, 271);
			this.pnlFile.TabIndex = 8;
			// 
			// lblProgress
			// 
			this.lblProgress.Location = new System.Drawing.Point(231, 16);
			this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(347, 28);
			this.lblProgress.TabIndex = 15;
			// 
			// pnlSettings
			// 
			this.pnlSettings.BackColor = System.Drawing.Color.Transparent;
			this.pnlSettings.Controls.Add(this.lblSQLRecurring);
			this.pnlSettings.Controls.Add(this.txtSQLFirstLine);
			this.pnlSettings.Controls.Add(this.txtSQLRecur);
			this.pnlSettings.Controls.Add(this.lblSQLFirstLine);
			this.pnlSettings.Location = new System.Drawing.Point(585, 5);
			this.pnlSettings.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSettings.Name = "pnlSettings";
			this.pnlSettings.Size = new System.Drawing.Size(291, 266);
			this.pnlSettings.TabIndex = 13;
			// 
			// lblSQLRecurring
			// 
			this.lblSQLRecurring.AutoSize = true;
			this.lblSQLRecurring.Location = new System.Drawing.Point(5, 135);
			this.lblSQLRecurring.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSQLRecurring.Name = "lblSQLRecurring";
			this.lblSQLRecurring.Size = new System.Drawing.Size(106, 17);
			this.lblSQLRecurring.TabIndex = 8;
			this.lblSQLRecurring.Text = "SQL Recurring:";
			// 
			// txtSQLFirstLine
			// 
			this.txtSQLFirstLine.Location = new System.Drawing.Point(7, 37);
			this.txtSQLFirstLine.Margin = new System.Windows.Forms.Padding(4);
			this.txtSQLFirstLine.Multiline = true;
			this.txtSQLFirstLine.Name = "txtSQLFirstLine";
			this.txtSQLFirstLine.Size = new System.Drawing.Size(272, 94);
			this.txtSQLFirstLine.TabIndex = 7;
			// 
			// txtSQLRecur
			// 
			this.txtSQLRecur.Location = new System.Drawing.Point(7, 156);
			this.txtSQLRecur.Margin = new System.Windows.Forms.Padding(4);
			this.txtSQLRecur.Multiline = true;
			this.txtSQLRecur.Name = "txtSQLRecur";
			this.txtSQLRecur.Size = new System.Drawing.Size(272, 100);
			this.txtSQLRecur.TabIndex = 6;
			// 
			// pnlColumn
			// 
			this.pnlColumn.BackColor = System.Drawing.Color.Silver;
			this.pnlColumn.Controls.Add(this.lblHeaderName);
			this.pnlColumn.Controls.Add(this.cmbBlankBehavior);
			this.pnlColumn.Controls.Add(this.lblBlankBehavior);
			this.pnlColumn.Location = new System.Drawing.Point(221, 52);
			this.pnlColumn.Margin = new System.Windows.Forms.Padding(4);
			this.pnlColumn.Name = "pnlColumn";
			this.pnlColumn.Size = new System.Drawing.Size(361, 219);
			this.pnlColumn.TabIndex = 12;
			// 
			// lblHeaderName
			// 
			this.lblHeaderName.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.lblHeaderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHeaderName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.lblHeaderName.Location = new System.Drawing.Point(4, 4);
			this.lblHeaderName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblHeaderName.Name = "lblHeaderName";
			this.lblHeaderName.Size = new System.Drawing.Size(353, 28);
			this.lblHeaderName.TabIndex = 14;
			this.lblHeaderName.Text = "lblHeaderName";
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Location = new System.Drawing.Point(123, 16);
			this.btnSaveAs.Margin = new System.Windows.Forms.Padding(4);
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(100, 28);
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
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(507, 18);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 9;
			this.btnHelp.Text = "Help";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// frmMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(883, 276);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.pnlFile);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
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
		private System.Windows.Forms.Button btnHelp;
	}
}

