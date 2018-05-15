using NotesToSharePointExporter.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesToSharePointExporter
{
    public partial class Form1 : Form
    {
        public string appKeys = "";
        private string sourceXmFilePath = "";
        private string tempExportFolder = "";
        private string siteCollection = "";
        private string listName = "";
        private bool isSPOnline = false;
        private string docSetName = "";
        private string docLibName = "";
        ExportParams exportParams = new ExportParams();
        NameValueCollection appSettings = ConfigurationManager.AppSettings;
        public Form1()
        {
            InitializeComponent();
            setDefaults();
            //GetConfigs();
           // MessageBox.Show(appKeys);
        }

        private void setDefaults()
        {
            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                if (appSettings.Count > 0)
                {
                    txtSiteCollectionUrl.Text = appSettings.Get(Constants.SITECOLLECTIONURL);
                    txtListName.Text = appSettings.Get(Constants.DEFAULTLIBRARY);
                    txtTempSaveFileLoc.Text = appSettings.Get(Constants.TEMPLOCATION) + txtListName.Text;
                    txtPassword.Text = appSettings.Get(Constants.PASSWORD);
                    txtUsername.Text = appSettings.Get(Constants.USERNAME);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading settings " + ex.Message);
            }
        }

        public void GetConfigs()
        {
            
            if(appSettings.Count > 0)
            {
                for(int i= 0; i<appSettings.Count; i++)
                {
                    string key = appSettings.GetKey(i);
                    appKeys = appKeys + key + " : " + appSettings.Get(key)+"\r\n";
                }
            }

        }

        private void btnExportToLibray_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, Not yet implemented!", "Export Dialog Result");
        }

        private void btnExportToDocSet_Click(object sender, EventArgs e)
        {
            resetMessages();
            setVariablesFromForm();
            List<string> res = HandleExport(true);
            if (res.Count > 0)
            {
                int i = 0;
                int startPoint = 10;
                int endPoint = 0;
                foreach (string param in res)
                {
                    if ((i % 10 == 0) && (i != 0))
                    {
                        startPoint = startPoint += 210;
                        endPoint = 0;
                    }
                    CheckBox dynamicCheckBox = new CheckBox();
                    dynamicCheckBox.Text = param;
                    dynamicCheckBox.Width = 200;
                    dynamicCheckBox.Name = "param" + i;
                    dynamicCheckBox.Location = new Point(startPoint, endPoint * 20);
                    endPoint++;
                    i++;
                    this.panelParameters.Controls.Add(dynamicCheckBox);
                }
            }
        }

        private void setVariablesFromForm()
        {
            siteCollection = txtSiteCollectionUrl.Text;
            tempExportFolder = txtTempSaveFileLoc.Text;
            listName = txtListName.Text;
            sourceXmFilePath = txtSourceXml.Text;
            
            exportParams.SiteCollectionUrl = txtSiteCollectionUrl.Text;
            exportParams.listName = txtListName.Text;
            exportParams.ImportFilePath = txtSourceXml.Text;
            exportParams.ExportFileLocation = txtTempSaveFileLoc.Text;
            exportParams.username = txtUsername.Text;
            exportParams.password = txtPassword.Text;

        }

        private void btnExportToList_Click(object sender, EventArgs e)
        {
            resetMessages();
            setVariablesFromForm();
            List<string> res = HandleExport(false);
            if (res.Count > 0)
            {
                int i = 0;
                int startPoint = 10;
                int endPoint = 0;
                foreach (string param in res)
                {
                    if ((i % 10 == 0) && (i != 0))
                    {
                        startPoint = startPoint += 210;
                        endPoint = 0;
                    }
                    CheckBox dynamicCheckBox = new CheckBox();
                    dynamicCheckBox.Text = param;
                    dynamicCheckBox.Width = 200;
                    dynamicCheckBox.Name = "param"+i;
                    dynamicCheckBox.Location = new Point(startPoint, endPoint * 20);
                    endPoint++;
                    i++;
                    this.panelParameters.Controls.Add(dynamicCheckBox);
                }
            }
            //MessageBox.Show("Export completed!");
        }

        public void resetMessages()
        {
            richTextBox1.Text = "";
            lblErrorMessage.Text = "";
            lblResultMessage.Text = "";
        }

        public List<string> HandleExport(bool ExportToDocSet)
        {
            List<string> _params = new List<string>();
            exportParams.IsSPOnline = isSPOnline;
            try
            {
                if (exportParams.ImportFilePath != "")
                {

                    if (!Directory.Exists(exportParams.ExportFileLocation))
                    {
                        Directory.CreateDirectory(exportParams.ExportFileLocation);
                    }

                    Utilities util = new Utilities();
                    ExportList exportResult = util.ParseXML(exportParams.ImportFilePath);

                    string exportPath = exportParams.ExportFileLocation + "\\"+exportResult.Title + "\\";
                    exportParams.ExportFileLocation = exportPath;
                    //if (!Directory.Exists(exportPath))
                    {
                        Directory.CreateDirectory(exportPath);
                    }

                    string its = "--------------------------------------\r\n";
                    foreach (KeyValuePair<string, string> kvp in exportResult.Items)
                    {

                        if (kvp.Key != "Body")
                        {
                            _params.Add(kvp.Key);
                            its = its + kvp.Key + " -  " + kvp.Value + "\r\n";
                        }
                    }
                    its = its + "---------------------------------------";

                    string res = its;
                    List<byte[]> bList = new List<byte[]>();
                    Dictionary<string, byte[]> fileDictionary = new Dictionary<string, byte[]>();
                    string fls = "--------------------------------------\r\n";
                    foreach (KeyValuePair<string, string> kvp in exportResult.Files)
                    {
                        fls = fls + kvp.Key + "\r\n";

                        //Read base file and add to List of files
                        byte[] fileBytes = Convert.FromBase64String(kvp.Value);
                        fileDictionary.Add(kvp.Key, fileBytes);
                        string newFilePath = exportPath + Path.GetFileName(kvp.Key);
                        FileStream fs = new FileStream(newFilePath, FileMode.OpenOrCreate);
                        fs.Write(fileBytes, 0, fileBytes.Length);
                        fs.Close();
                    }
                    SPManager spManager = new SPManager();
                    if (ExportToDocSet)
                    {
                        spManager.CreateDocSetItem(exportResult, exportParams, fileDictionary);
                    }
                    else
                    {
                        spManager.CreateSharePointListItem(exportResult, exportParams, fileDictionary);
                    }
                   

                    fls = fls + "---------------------------------------";
                    res = res + "\r\n -------------- FILES -------------\r\n"+ fls+"\r\n Export Successful.";
                    richTextBox1.Text = res;
                    lblResultMessage.Text = "Successful";
                }
            }
            catch (Exception ex)
            {
               lblErrorMessage.Text = "Error "+ex.Message;
               return _params;
            }
            finally
            {

            }
            return _params;

        }


        private void btnSourceFileLoc_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSourceXml.Text = openFileDialog1.FileName;
            }
        }

        private void btnTemFileLoc_Click(object sender, EventArgs e)
        {
            if(tempFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtTempSaveFileLoc.Text = tempFolderBrowserDialog.SelectedPath;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIsSharePointOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIsSharePointOnline.Checked)
            {
                txtSiteCollectionUrl.Text = appSettings.Get(Constants.SPOSITECOLLECTIONURL);
                txtUsername.Text = appSettings.Get(Constants.SPOEMAIL);
                txtPassword.Text = appSettings.Get(Constants.SPOPASS);
                isSPOnline = true;
            }
            else
            {
                txtSiteCollectionUrl.Text = appSettings.Get(Constants.SITECOLLECTIONURL);
                txtUsername.Text = appSettings.Get(Constants.USERNAME);
                txtPassword.Text = appSettings.Get(Constants.PASSWORD);
                isSPOnline = false;
            }
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            Authentication auth = new Authentication();
            string url = appSettings.Get(Constants.SPOSITECOLLECTIONURL);
            string email = appSettings.Get(Constants.SPOEMAIL);
            string pass = appSettings.Get(Constants.SPOPASS);
            List<string> res = auth.SPOGetLists(url, email, pass);
            string x = "";
        }
    }
}
