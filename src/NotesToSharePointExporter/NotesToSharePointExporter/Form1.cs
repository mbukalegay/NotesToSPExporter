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
        private string docSetName = "";
        private string docLibName = "";
        ExportParams exportParams = new ExportParams();
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
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
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
            MessageBox.Show("Sorry, Not yet implemented!","Export Dialog Result");           
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
            HandleExport();
            //MessageBox.Show("Export completed!");
        }

        public void resetMessages()
        {
            richTextBox1.Text = "";
            lblErrorMessage.Text = "";
            lblResultMessage.Text = "";
        }

        public void HandleExport()
        {
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
                    //{
                        Directory.CreateDirectory(exportPath);
                    }

                    string its = "--------------------------------------\r\n";
                    foreach (KeyValuePair<string, string> kvp in exportResult.Items)
                    {

                        if (kvp.Key != "Body")
                        {
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
                   spManager.CreateSharePointListItem(exportResult, exportParams, fileDictionary);

                    fls = fls + "---------------------------------------";
                    res = res + "\r\n -------------- FILES -------------\r\n"+ fls+"\r\n Export Successful.";
                    richTextBox1.Text = res;
                    lblResultMessage.Text = "Successful";
                }
            }
            catch (Exception ex)
            {
               lblErrorMessage.Text = "Error "+ex.Message;
            }

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
    }
}
