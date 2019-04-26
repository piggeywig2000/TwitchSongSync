namespace TwitchSongSync
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTitle2 = new System.Windows.Forms.Label();
            this.groupBoxConnect = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.radioButtonGuest = new System.Windows.Forms.RadioButton();
            this.radioButtonHost = new System.Windows.Forms.RadioButton();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.labelIp = new System.Windows.Forms.Label();
            this.groupBoxUsers = new System.Windows.Forms.GroupBox();
            this.buttonChangeName = new System.Windows.Forms.Button();
            this.textBoxNickname = new System.Windows.Forms.TextBox();
            this.buttonUserDown = new System.Windows.Forms.Button();
            this.buttonUserUp = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.groupBoxScript = new System.Windows.Forms.GroupBox();
            this.buttonImportCSV = new System.Windows.Forms.Button();
            this.labelImportInstructions = new System.Windows.Forms.Label();
            this.dataGridViewScript = new System.Windows.Forms.DataGridView();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialogCSV = new System.Windows.Forms.OpenFileDialog();
            this.timerForm = new System.Windows.Forms.Timer(this.components);
            this.groupBoxMouseSetup = new System.Windows.Forms.GroupBox();
            this.buttonMouseTest = new System.Windows.Forms.Button();
            this.labelMouseTest = new System.Windows.Forms.Label();
            this.buttonMouseWizard = new System.Windows.Forms.Button();
            this.groupBoxRun = new System.Windows.Forms.GroupBox();
            this.labelRun = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.pictureBoxCSV = new System.Windows.Forms.PictureBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.labelTextPreview = new System.Windows.Forms.Label();
            this.textBoxSuffix = new System.Windows.Forms.TextBox();
            this.groupBoxConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.groupBoxUsers.SuspendLayout();
            this.groupBoxScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScript)).BeginInit();
            this.groupBoxMouseSetup.SuspendLayout();
            this.groupBoxRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCSV)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(298, 42);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "TwitchSongSync";
            // 
            // labelTitle2
            // 
            this.labelTitle2.AutoSize = true;
            this.labelTitle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle2.Location = new System.Drawing.Point(316, 28);
            this.labelTitle2.Name = "labelTitle2";
            this.labelTitle2.Size = new System.Drawing.Size(134, 20);
            this.labelTitle2.TabIndex = 1;
            this.labelTitle2.Text = "by piggeywig2000";
            // 
            // groupBoxConnect
            // 
            this.groupBoxConnect.Controls.Add(this.buttonConnect);
            this.groupBoxConnect.Controls.Add(this.radioButtonGuest);
            this.groupBoxConnect.Controls.Add(this.radioButtonHost);
            this.groupBoxConnect.Controls.Add(this.numericUpDownPort);
            this.groupBoxConnect.Controls.Add(this.labelPort);
            this.groupBoxConnect.Controls.Add(this.textBoxIp);
            this.groupBoxConnect.Controls.Add(this.labelIp);
            this.groupBoxConnect.Location = new System.Drawing.Point(12, 54);
            this.groupBoxConnect.Name = "groupBoxConnect";
            this.groupBoxConnect.Size = new System.Drawing.Size(327, 96);
            this.groupBoxConnect.TabIndex = 2;
            this.groupBoxConnect.TabStop = false;
            this.groupBoxConnect.Text = "Connection";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(118, 67);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(97, 23);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // radioButtonGuest
            // 
            this.radioButtonGuest.AutoSize = true;
            this.radioButtonGuest.Checked = true;
            this.radioButtonGuest.Location = new System.Drawing.Point(59, 70);
            this.radioButtonGuest.Name = "radioButtonGuest";
            this.radioButtonGuest.Size = new System.Drawing.Size(53, 17);
            this.radioButtonGuest.TabIndex = 5;
            this.radioButtonGuest.TabStop = true;
            this.radioButtonGuest.Text = "Guest";
            this.radioButtonGuest.UseVisualStyleBackColor = true;
            // 
            // radioButtonHost
            // 
            this.radioButtonHost.AutoSize = true;
            this.radioButtonHost.Location = new System.Drawing.Point(6, 70);
            this.radioButtonHost.Name = "radioButtonHost";
            this.radioButtonHost.Size = new System.Drawing.Size(47, 17);
            this.radioButtonHost.TabIndex = 4;
            this.radioButtonHost.Text = "Host";
            this.radioButtonHost.UseVisualStyleBackColor = true;
            this.radioButtonHost.CheckedChanged += new System.EventHandler(this.radioButtonHost_CheckedChanged);
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(242, 41);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(79, 20);
            this.numericUpDownPort.TabIndex = 3;
            this.numericUpDownPort.Value = new decimal(new int[] {
            1273,
            0,
            0,
            0});
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(239, 25);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Port";
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(6, 41);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(230, 20);
            this.textBoxIp.TabIndex = 1;
            this.textBoxIp.TextChanged += new System.EventHandler(this.textBoxIp_TextChanged);
            // 
            // labelIp
            // 
            this.labelIp.AutoSize = true;
            this.labelIp.Location = new System.Drawing.Point(3, 25);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(17, 13);
            this.labelIp.TabIndex = 0;
            this.labelIp.Text = "IP";
            // 
            // groupBoxUsers
            // 
            this.groupBoxUsers.Controls.Add(this.buttonChangeName);
            this.groupBoxUsers.Controls.Add(this.textBoxNickname);
            this.groupBoxUsers.Controls.Add(this.buttonUserDown);
            this.groupBoxUsers.Controls.Add(this.buttonUserUp);
            this.groupBoxUsers.Controls.Add(this.listBoxUsers);
            this.groupBoxUsers.Enabled = false;
            this.groupBoxUsers.Location = new System.Drawing.Point(12, 156);
            this.groupBoxUsers.Name = "groupBoxUsers";
            this.groupBoxUsers.Size = new System.Drawing.Size(327, 212);
            this.groupBoxUsers.TabIndex = 3;
            this.groupBoxUsers.TabStop = false;
            this.groupBoxUsers.Text = "Connected Users";
            // 
            // buttonChangeName
            // 
            this.buttonChangeName.Enabled = false;
            this.buttonChangeName.Location = new System.Drawing.Point(217, 183);
            this.buttonChangeName.Name = "buttonChangeName";
            this.buttonChangeName.Size = new System.Drawing.Size(104, 23);
            this.buttonChangeName.TabIndex = 4;
            this.buttonChangeName.Text = "Change Nickname";
            this.buttonChangeName.UseVisualStyleBackColor = true;
            this.buttonChangeName.Click += new System.EventHandler(this.buttonChangeName_Click);
            // 
            // textBoxNickname
            // 
            this.textBoxNickname.Location = new System.Drawing.Point(6, 185);
            this.textBoxNickname.MaxLength = 32;
            this.textBoxNickname.Name = "textBoxNickname";
            this.textBoxNickname.Size = new System.Drawing.Size(205, 20);
            this.textBoxNickname.TabIndex = 3;
            this.textBoxNickname.TextChanged += new System.EventHandler(this.textBoxNickname_TextChanged);
            // 
            // buttonUserDown
            // 
            this.buttonUserDown.Location = new System.Drawing.Point(246, 156);
            this.buttonUserDown.Name = "buttonUserDown";
            this.buttonUserDown.Size = new System.Drawing.Size(75, 23);
            this.buttonUserDown.TabIndex = 2;
            this.buttonUserDown.Text = "Move Down";
            this.buttonUserDown.UseVisualStyleBackColor = true;
            this.buttonUserDown.Click += new System.EventHandler(this.buttonUserDown_Click);
            // 
            // buttonUserUp
            // 
            this.buttonUserUp.Location = new System.Drawing.Point(246, 127);
            this.buttonUserUp.Name = "buttonUserUp";
            this.buttonUserUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUserUp.TabIndex = 1;
            this.buttonUserUp.Text = "Move Up";
            this.buttonUserUp.UseVisualStyleBackColor = true;
            this.buttonUserUp.Click += new System.EventHandler(this.buttonUserUp_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(7, 19);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(233, 160);
            this.listBoxUsers.TabIndex = 0;
            // 
            // groupBoxScript
            // 
            this.groupBoxScript.Controls.Add(this.buttonImportCSV);
            this.groupBoxScript.Controls.Add(this.pictureBoxCSV);
            this.groupBoxScript.Controls.Add(this.labelImportInstructions);
            this.groupBoxScript.Controls.Add(this.dataGridViewScript);
            this.groupBoxScript.Location = new System.Drawing.Point(345, 54);
            this.groupBoxScript.Name = "groupBoxScript";
            this.groupBoxScript.Size = new System.Drawing.Size(327, 381);
            this.groupBoxScript.TabIndex = 4;
            this.groupBoxScript.TabStop = false;
            this.groupBoxScript.Text = "Lyrics";
            // 
            // buttonImportCSV
            // 
            this.buttonImportCSV.Location = new System.Drawing.Point(214, 295);
            this.buttonImportCSV.Name = "buttonImportCSV";
            this.buttonImportCSV.Size = new System.Drawing.Size(107, 80);
            this.buttonImportCSV.TabIndex = 3;
            this.buttonImportCSV.Text = "Import CSV";
            this.buttonImportCSV.UseVisualStyleBackColor = true;
            this.buttonImportCSV.Click += new System.EventHandler(this.buttonImportCSV_Click);
            // 
            // labelImportInstructions
            // 
            this.labelImportInstructions.AutoSize = true;
            this.labelImportInstructions.Location = new System.Drawing.Point(6, 279);
            this.labelImportInstructions.Name = "labelImportInstructions";
            this.labelImportInstructions.Size = new System.Drawing.Size(74, 13);
            this.labelImportInstructions.TabIndex = 1;
            this.labelImportInstructions.Text = "Example CSV:";
            // 
            // dataGridViewScript
            // 
            this.dataGridViewScript.AllowUserToAddRows = false;
            this.dataGridViewScript.AllowUserToDeleteRows = false;
            this.dataGridViewScript.AllowUserToResizeRows = false;
            this.dataGridViewScript.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScript.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTime,
            this.ColumnUser,
            this.ColumnContent});
            this.dataGridViewScript.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewScript.MultiSelect = false;
            this.dataGridViewScript.Name = "dataGridViewScript";
            this.dataGridViewScript.ReadOnly = true;
            this.dataGridViewScript.RowHeadersVisible = false;
            this.dataGridViewScript.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewScript.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScript.Size = new System.Drawing.Size(315, 257);
            this.dataGridViewScript.TabIndex = 0;
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTime.HeaderText = "Time";
            this.ColumnTime.MinimumWidth = 40;
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            this.ColumnTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnTime.Width = 40;
            // 
            // ColumnUser
            // 
            this.ColumnUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnUser.HeaderText = "User";
            this.ColumnUser.MinimumWidth = 80;
            this.ColumnUser.Name = "ColumnUser";
            this.ColumnUser.ReadOnly = true;
            this.ColumnUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnUser.Width = 80;
            // 
            // ColumnContent
            // 
            this.ColumnContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnContent.HeaderText = "Content";
            this.ColumnContent.MinimumWidth = 192;
            this.ColumnContent.Name = "ColumnContent";
            this.ColumnContent.ReadOnly = true;
            this.ColumnContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnContent.Width = 192;
            // 
            // openFileDialogCSV
            // 
            this.openFileDialogCSV.DefaultExt = "csv";
            this.openFileDialogCSV.Filter = "CSV|*.csv";
            this.openFileDialogCSV.Title = "Import CSV";
            // 
            // timerForm
            // 
            this.timerForm.Tick += new System.EventHandler(this.timerForm_Tick);
            // 
            // groupBoxMouseSetup
            // 
            this.groupBoxMouseSetup.Controls.Add(this.buttonMouseTest);
            this.groupBoxMouseSetup.Controls.Add(this.labelMouseTest);
            this.groupBoxMouseSetup.Controls.Add(this.buttonMouseWizard);
            this.groupBoxMouseSetup.Enabled = false;
            this.groupBoxMouseSetup.Location = new System.Drawing.Point(12, 374);
            this.groupBoxMouseSetup.Name = "groupBoxMouseSetup";
            this.groupBoxMouseSetup.Size = new System.Drawing.Size(132, 125);
            this.groupBoxMouseSetup.TabIndex = 5;
            this.groupBoxMouseSetup.TabStop = false;
            this.groupBoxMouseSetup.Text = "Setup Mouse";
            // 
            // buttonMouseTest
            // 
            this.buttonMouseTest.Location = new System.Drawing.Point(7, 96);
            this.buttonMouseTest.Name = "buttonMouseTest";
            this.buttonMouseTest.Size = new System.Drawing.Size(119, 23);
            this.buttonMouseTest.TabIndex = 2;
            this.buttonMouseTest.Text = "Test Mouse Position";
            this.buttonMouseTest.UseVisualStyleBackColor = true;
            this.buttonMouseTest.Click += new System.EventHandler(this.buttonMouseTest_Click);
            // 
            // labelMouseTest
            // 
            this.labelMouseTest.Location = new System.Drawing.Point(6, 62);
            this.labelMouseTest.Name = "labelMouseTest";
            this.labelMouseTest.Size = new System.Drawing.Size(120, 31);
            this.labelMouseTest.TabIndex = 1;
            this.labelMouseTest.Text = "Mouse will go to\r\n(0, 0)";
            this.labelMouseTest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonMouseWizard
            // 
            this.buttonMouseWizard.Location = new System.Drawing.Point(6, 19);
            this.buttonMouseWizard.Name = "buttonMouseWizard";
            this.buttonMouseWizard.Size = new System.Drawing.Size(120, 40);
            this.buttonMouseWizard.TabIndex = 0;
            this.buttonMouseWizard.Text = "Run Mouse Setup Wizard";
            this.buttonMouseWizard.UseVisualStyleBackColor = true;
            this.buttonMouseWizard.Click += new System.EventHandler(this.buttonKeyboardWizard_Click);
            // 
            // groupBoxRun
            // 
            this.groupBoxRun.Controls.Add(this.labelRun);
            this.groupBoxRun.Controls.Add(this.buttonRun);
            this.groupBoxRun.Enabled = false;
            this.groupBoxRun.Location = new System.Drawing.Point(150, 374);
            this.groupBoxRun.Name = "groupBoxRun";
            this.groupBoxRun.Size = new System.Drawing.Size(189, 125);
            this.groupBoxRun.TabIndex = 6;
            this.groupBoxRun.TabStop = false;
            this.groupBoxRun.Text = "Run";
            // 
            // labelRun
            // 
            this.labelRun.Location = new System.Drawing.Point(6, 16);
            this.labelRun.Name = "labelRun";
            this.labelRun.Size = new System.Drawing.Size(177, 55);
            this.labelRun.TabIndex = 1;
            this.labelRun.Text = "Before starting make sure that the Twitch chat is visible, and that the mouse pos" +
    "ition is correct, and that everyone else is ready.";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(6, 74);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(177, 45);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "Start";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // pictureBoxCSV
            // 
            this.pictureBoxCSV.BackgroundImage = global::TwitchSongSync.Properties.Resources.CSV;
            this.pictureBoxCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCSV.Location = new System.Drawing.Point(6, 295);
            this.pictureBoxCSV.Name = "pictureBoxCSV";
            this.pictureBoxCSV.Size = new System.Drawing.Size(202, 80);
            this.pictureBoxCSV.TabIndex = 2;
            this.pictureBoxCSV.TabStop = false;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.textBoxSuffix);
            this.groupBoxSettings.Controls.Add(this.labelTextPreview);
            this.groupBoxSettings.Controls.Add(this.textBoxPrefix);
            this.groupBoxSettings.Location = new System.Drawing.Point(345, 441);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(327, 58);
            this.groupBoxSettings.TabIndex = 7;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Enabled = false;
            this.textBoxPrefix.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxPrefix.Location = new System.Drawing.Point(6, 19);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(154, 20);
            this.textBoxPrefix.TabIndex = 0;
            this.textBoxPrefix.Text = "Prefix";
            this.textBoxPrefix.Enter += new System.EventHandler(this.textBoxPrefix_Enter);
            this.textBoxPrefix.Leave += new System.EventHandler(this.textBoxPrefix_Leave);
            // 
            // labelTextPreview
            // 
            this.labelTextPreview.Location = new System.Drawing.Point(6, 42);
            this.labelTextPreview.Name = "labelTextPreview";
            this.labelTextPreview.Size = new System.Drawing.Size(315, 13);
            this.labelTextPreview.TabIndex = 1;
            this.labelTextPreview.Text = "Preview: %LINE%";
            this.labelTextPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSuffix
            // 
            this.textBoxSuffix.Enabled = false;
            this.textBoxSuffix.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxSuffix.Location = new System.Drawing.Point(167, 19);
            this.textBoxSuffix.Name = "textBoxSuffix";
            this.textBoxSuffix.Size = new System.Drawing.Size(154, 20);
            this.textBoxSuffix.TabIndex = 2;
            this.textBoxSuffix.Text = "Suffix";
            this.textBoxSuffix.Enter += new System.EventHandler(this.textBoxSuffix_Enter);
            this.textBoxSuffix.Leave += new System.EventHandler(this.textBoxSuffix_Leave);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxRun);
            this.Controls.Add(this.groupBoxMouseSetup);
            this.Controls.Add(this.groupBoxScript);
            this.Controls.Add(this.groupBoxUsers);
            this.Controls.Add(this.groupBoxConnect);
            this.Controls.Add(this.labelTitle2);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "TwitchSongSync";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxConnect.ResumeLayout(false);
            this.groupBoxConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.groupBoxUsers.ResumeLayout(false);
            this.groupBoxUsers.PerformLayout();
            this.groupBoxScript.ResumeLayout(false);
            this.groupBoxScript.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScript)).EndInit();
            this.groupBoxMouseSetup.ResumeLayout(false);
            this.groupBoxRun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCSV)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTitle2;
        private System.Windows.Forms.GroupBox groupBoxConnect;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.RadioButton radioButtonGuest;
        private System.Windows.Forms.RadioButton radioButtonHost;
        private System.Windows.Forms.GroupBox groupBoxUsers;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button buttonChangeName;
        private System.Windows.Forms.TextBox textBoxNickname;
        private System.Windows.Forms.Button buttonUserDown;
        private System.Windows.Forms.Button buttonUserUp;
        private System.Windows.Forms.GroupBox groupBoxScript;
        private System.Windows.Forms.DataGridView dataGridViewScript;
        private System.Windows.Forms.Label labelImportInstructions;
        private System.Windows.Forms.PictureBox pictureBoxCSV;
        private System.Windows.Forms.Button buttonImportCSV;
        private System.Windows.Forms.OpenFileDialog openFileDialogCSV;
        private System.Windows.Forms.Timer timerForm;
        private System.Windows.Forms.GroupBox groupBoxMouseSetup;
        private System.Windows.Forms.Button buttonMouseTest;
        private System.Windows.Forms.Label labelMouseTest;
        private System.Windows.Forms.Button buttonMouseWizard;
        private System.Windows.Forms.GroupBox groupBoxRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContent;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label labelRun;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TextBox textBoxSuffix;
        private System.Windows.Forms.Label labelTextPreview;
        private System.Windows.Forms.TextBox textBoxPrefix;
    }
}

