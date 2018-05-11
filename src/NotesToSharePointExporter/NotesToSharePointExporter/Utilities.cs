using NotesToSharePointExporter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NotesToSharePointExporter
{
    public class Utilities
    {
        public ExportList ParseXML(string fileName)
        {
            ExportList exportList = new ExportList();
            exportList.Items = new Dictionary<string, string>();
            exportList.Files = new Dictionary<string, string>();
            exportList.RichTextImages = new Dictionary<string, string>();
            int fileCount = 0;
            XmlDocument siteContentXmlDoc = new XmlDocument();
            StringBuilder sb = new StringBuilder();
            StringBuilder fils = new StringBuilder();
            using (StreamReader sr = new StreamReader(fileName))
            {

                siteContentXmlDoc.Load(sr);
                XmlNodeList items = siteContentXmlDoc.SelectNodes("/document/item");
                foreach (XmlNode field in items)
                {
                    string name = field.Attributes["name"].InnerText;
                    if (name != "$FILE")
                    {
                        string fieldXML = field.InnerText;
                        sb.AppendLine(name + " : " + fieldXML + "<br />");
                        if (name == "STATUS")
                        {
                            exportList.Status = fieldXML;
                        }
                        if (name == "SCOPE")
                        {
                            exportList.Scope = fieldXML;
                        }
                        if (name == "Categories")
                        {
                            exportList.Categories = fieldXML;
                        }
                        if (name == "Subject")
                        {
                            exportList.Subject = fieldXML;
                            exportList.Title = fieldXML;
                        }
                        if (name == "Body")
                        {
                            var richtext = field.SelectSingleNode("richtext");
                            if (richtext.HasChildNodes)
                            {
                                foreach (XmlNode richtextParams in richtext.ChildNodes)
                                {
                                    if (richtextParams.Name == "par")
                                    {
                                        foreach (XmlNode richtextParam in richtextParams)
                                        {
                                            if (richtextParam.HasChildNodes)
                                            {
                                                if (richtextParam.Name != "attachmentref")
                                                {
                                                    if (richtextParam.Name == "run")
                                                    {
                                                        exportList.Body += richtextParam.InnerXml + "<br />";
                                                    }
                                                    else
                                                    {
                                                        exportList.Body += richtextParam.InnerXml + "<br />";
                                                    }
                                                }
                                            }
                                        }

                                    }
                                    if (richtextParams.Name == "table")
                                    {
                                        exportList.Body += richtextParams.OuterXml + "<br />";

                                    }
                                }

                            }
                            var attachmenntRefs = field.SelectNodes("richtext/par/attachmentref");
                            string innerCont = "";
                            if (attachmenntRefs.Count > 0)
                            {

                                foreach (XmlNode attach in attachmenntRefs)
                                {
                                    string imgUrl = "<img src=\"data:image/";
                                    if (attach.HasChildNodes)
                                    {
                                        string fname = attach.Attributes["name"].Value.ToString();
                                        string displayname = attach.Attributes["displayname"].Value.ToString();
                                        if (attach.ChildNodes[0].Name == "picture")
                                        {

                                            XmlNode innerPic = attach.ChildNodes[0];
                                            if (innerPic.ChildNodes[0].Name == "gif")
                                            {
                                                //imgUrl += "gif;base64,";
                                                imgUrl = "<img class=\"ms-asset-icon ms-rtePosition-4\" src=\"/_layouts/15/images/icgif.gif\" alt=\"" + displayname + "\"/>";
                                            }
                                            if (innerPic.ChildNodes[0].Name == "notesbitmap")
                                            {
                                                if (fname.EndsWith(".pdf"))
                                                {
                                                    imgUrl = "<img class=\"ms-asset-icon ms-rtePosition-4\" src=\"/_layouts/15/images/icpdf.png\" alt=\"" + displayname + "\"/>";
                                                }
                                                if (fname.EndsWith(".pptx"))
                                                {
                                                    imgUrl = "<img class=\"ms-asset-icon ms-rtePosition-4\" src=\"/_layouts/15/images/icpptx.png\" alt=\"" + displayname + "\"/>";
                                                }

                                            }
                                            string fileInBase64 = innerPic.ChildNodes[0].InnerText;

                                            innerCont = innerCont + "<div><p><a href=\"/SiteAssets/images/" + fname + "\">" + imgUrl + "</a> </div></p>";
                                            exportList.RichTextImages.Add(fname, fileInBase64);

                                        }
                                    }

                                }
                            }
                        }
                        exportList.Items.Add(name, fieldXML);
                    }

                    else
                    {

                    }

                }
                sb.AppendLine("------------------------------");
                //Handle Files
                XmlNodeList fileItems = siteContentXmlDoc.SelectNodes("/document/item/object/file");
                foreach (XmlNode f in fileItems)
                {
                    string fname = f.Attributes["name"].InnerText;
                    fils.AppendLine("FileName - " + fname + "<br />");
                    string fileData = f.ChildNodes[2].InnerXml.Replace("\n", "");
                    exportList.Files.Add(fname, fileData);
                    fileCount++;
                }

            }

            return exportList;

        }

        public string ParseBodyXML(string fileName)
        {
            return "";
        }
    }
}
