namespace NotesToSharePointExporter
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTemFileLoc = new System.Windows.Forms.Button();
            this.btnSourceFileLoc = new System.Windows.Forms.Button();
            this.btnExportToLibray = new System.Windows.Forms.Button();
            this.btnExportToDocSet = new System.Windows.Forms.Button();
            this.btnExportToList = new System.Windows.Forms.Button();
            this.txtListName = new System.Windows.Forms.TextBox();
            this.txtSiteCollectionUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTempSaveFileLoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSourceXml = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblResultMessage = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tempFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnTemFileLoc);
            this.groupBox1.Controls.Add(this.btnSourceFileLoc);
            this.groupBox1.Controls.Add(this.btnExportToLibray);
            this.groupBox1.Controls.Add(this.btnExportToDocSet);
            this.groupBox1.Controls.Add(this.btnExportToList);
            this.groupBox1.Controls.Add(this.txtListName);
            this.groupBox1.Controls.Add(this.txtSiteCollectionUrl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTempSaveFileLoc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSourceXml);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic parameters";
            // 
            // btnTemFileLoc
            // 
            this.btnTemFileLoc.Location = new System.Drawing.Point(471, 51);
            this.btnTemFileLoc.Name = "btnTemFileLoc";
            this.btnTemFileLoc.Size = new System.Drawing.Size(75, 23);
            this.btnTemFileLoc.TabIndex = 12;
            this.btnTemFileLoc.Text = "Browse..";
            this.btnTemFileLoc.UseVisualStyleBackColor = true;
            this.btnTemFileLoc.Click += new System.EventHandler(this.btnTemFileLoc_Click);
            // 
            // btnSourceFileLoc
            // 
            this.btnSourceFileLoc.Location = new System.Drawing.Point(471, 21);
            this.btnSourceFileLoc.Name = "btnSourceFileLoc";
            this.btnSourceFileLoc.Size = new System.Drawing.Size(75, 23);
            this.btnSourceFileLoc.TabIndex = 11;
            this.btnSourceFileLoc.Text = "Browse..";
            this.btnSourceFileLoc.UseVisualStyleBackColor = true;
            this.btnSourceFileLoc.Click += new System.EventHandler(this.btnSourceFileLoc_Click);
            // 
            // btnExportToLibray
            // 
            this.btnExportToLibray.Location = new System.Drawing.Point(307, 112);
            this.btnExportToLibray.Name = "btnExportToLibray";
            this.btnExportToLibray.Size = new System.Drawing.Size(157, 23);
            this.btnExportToLibray.TabIndex = 10;
            this.btnExportToLibray.Text = "Export to Document Library";
            this.btnExportToLibray.UseVisualStyleBackColor = true;
            this.btnExportToLibray.Click += new System.EventHandler(this.btnExportToLibray_Click);
            // 
            // btnExportToDocSet
            // 
            this.btnExportToDocSet.Location = new System.Drawing.Point(471, 112);
            this.btnExportToDocSet.Name = "btnExportToDocSet";
            this.btnExportToDocSet.Size = new System.Drawing.Size(157, 23);
            this.btnExportToDocSet.TabIndex = 9;
            this.btnExportToDocSet.Text = "Export to Document Set";
            this.btnExportToDocSet.UseVisualStyleBackColor = true;
            this.btnExportToDocSet.Click += new System.EventHandler(this.btnExportToDocSet_Click);
            // 
            // btnExportToList
            // 
            this.btnExportToList.Location = new System.Drawing.Point(637, 112);
            this.btnExportToList.Name = "btnExportToList";
            this.btnExportToList.Size = new System.Drawing.Size(109, 23);
            this.btnExportToList.TabIndex = 8;
            this.btnExportToList.Text = "Export to List";
            this.btnExportToList.UseVisualStyleBackColor = true;
            this.btnExportToList.Click += new System.EventHandler(this.btnExportToList_Click);
            // 
            // txtListName
            // 
            this.txtListName.Location = new System.Drawing.Point(164, 115);
            this.txtListName.Name = "txtListName";
            this.txtListName.Size = new System.Drawing.Size(137, 20);
            this.txtListName.TabIndex = 7;
            // 
            // txtSiteCollectionUrl
            // 
            this.txtSiteCollectionUrl.Location = new System.Drawing.Point(164, 81);
            this.txtSiteCollectionUrl.Name = "txtSiteCollectionUrl";
            this.txtSiteCollectionUrl.Size = new System.Drawing.Size(382, 20);
            this.txtSiteCollectionUrl.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "List Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Site Collection Url";
            // 
            // txtTempSaveFileLoc
            // 
            this.txtTempSaveFileLoc.Location = new System.Drawing.Point(164, 51);
            this.txtTempSaveFileLoc.Name = "txtTempSaveFileLoc";
            this.txtTempSaveFileLoc.Size = new System.Drawing.Size(290, 20);
            this.txtTempSaveFileLoc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Temp File Save Location";
            // 
            // txtSourceXml
            // 
            this.txtSourceXml.Location = new System.Drawing.Point(164, 23);
            this.txtSourceXml.Name = "txtSourceXml";
            this.txtSourceXml.Size = new System.Drawing.Size(290, 20);
            this.txtSourceXml.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source XML";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblResultMessage);
            this.groupBox2.Controls.Add(this.lblErrorMessage);
            this.groupBox2.Controls.Add(this.lblResult);
            this.groupBox2.Controls.Add(this.lblError);
            this.groupBox2.Location = new System.Drawing.Point(22, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(751, 63);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // lblResultMessage
            // 
            this.lblResultMessage.AutoSize = true;
            this.lblResultMessage.ForeColor = System.Drawing.Color.Green;
            this.lblResultMessage.Location = new System.Drawing.Point(161, 42);
            this.lblResultMessage.Name = "lblResultMessage";
            this.lblResultMessage.Size = new System.Drawing.Size(13, 13);
            this.lblResultMessage.TabIndex = 3;
            this.lblResultMessage.Text = "..";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(161, 16);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(13, 13);
            this.lblErrorMessage.TabIndex = 2;
            this.lblErrorMessage.Text = "..";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(31, 42);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "Result";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(31, 16);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(74, 13);
            this.lblError.TabIndex = 0;
            this.lblError.Text = "Error message";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(22, 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(752, 164);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parse results";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(28, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(704, 130);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openSourceFileDialog";
            this.openFileDialog1.InitialDirectory = "C:\\temp\\myNotesXMLFiles";
            // 
            // tempFolderBrowserDialog
            // 
            this.tempFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.tempFolderBrowserDialog.SelectedPath = "C:\\temp\\NotesExportDir";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(563, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(563, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(625, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 15;
            this.txtUsername.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(625, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Lotus Notes To SharePoint Exporter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTemFileLoc;
        private System.Windows.Forms.Button btnSourceFileLoc;
        private System.Windows.Forms.Button btnExportToLibray;
        private System.Windows.Forms.Button btnExportToDocSet;
        private System.Windows.Forms.Button btnExportToList;
        private System.Windows.Forms.TextBox txtListName;
        private System.Windows.Forms.TextBox txtSiteCollectionUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTempSaveFileLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSourceXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog tempFolderBrowserDialog;
        private System.Windows.Forms.Label lblResultMessage;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

