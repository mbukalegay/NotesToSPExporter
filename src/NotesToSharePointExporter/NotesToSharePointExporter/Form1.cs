using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesToSharePointExporter
{
    public partial class Form1 : Form
    {
        public string appKeys = "";
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

        private void btnExportToList_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming up!", "Export Dialog Result");
        }
    }
}
