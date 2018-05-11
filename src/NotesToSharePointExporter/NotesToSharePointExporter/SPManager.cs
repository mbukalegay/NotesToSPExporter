using Microsoft.SharePoint.Client;
using NotesToSharePointExporter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NotesToSharePointExporter
{
    public class SPManager
    {
        private ClientContext ctx = null;
        public void CreateSharePointListItem(ExportList data, ExportParams exportParams, Dictionary<string, byte[]> filesDictionary)
        {
            //var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            try
            {
                using (var clientContext = new ClientContext(exportParams.SiteCollectionUrl))
                {
                    clientContext.Credentials = new NetworkCredential (exportParams.username, exportParams.password);
                    if (clientContext != null)
                    {
                        List notesList = clientContext.Web.Lists.GetByTitle(exportParams.listName);
                        ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                        ListItem newItem = notesList.AddItem(itemCreateInfo);
                        newItem["Title"] = data.Title;
                        newItem["Subject"] = data.Subject;
                        newItem["Categories"] = data.Categories;
                        newItem["STATUS"] = data.Status;
                        newItem["SCOPE"] = data.Scope;
                        newItem["Body"] = data.Body;
                        newItem.Update();

                        clientContext.ExecuteQuery();

                        //Add attachments
                        foreach (KeyValuePair<string, byte[]> kvp in filesDictionary)
                        {
                            var newFile = new AttachmentCreationInformation();
                            newFile.ContentStream = new MemoryStream(kvp.Value);
                            newFile.FileName = kvp.Key;

                            Attachment attach = newItem.AttachmentFiles.Add(newFile); //Add to File

                            clientContext.Load(attach);
                            notesList.Update();
                            clientContext.ExecuteQuery();
                        }

                        foreach (KeyValuePair<string, string> kvp in data.RichTextImages)
                        {
                            UploadBase64FileToFolder(kvp.Key, kvp.Value, "SiteAssets/images", exportParams);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;

            }

        }


        public void UploadBase64FileToFolder(string fileName, string FileContent,  string folder, ExportParams exportParams)
        {

            using (var clientContext = new ClientContext(exportParams.SiteCollectionUrl))
            {
                if (clientContext != null)
                {
                    Folder _folder = clientContext.Web.GetFolderByServerRelativeUrl(folder);
                    FileCreationInformation fci = new FileCreationInformation();
                    fci.Content = Convert.FromBase64String(FileContent);
                    fci.Url = fileName;
                    fci.Overwrite = true;
                    Microsoft.SharePoint.Client.File fileToUpload = _folder.Files.Add(fci);
                    clientContext.Load(fileToUpload);

                    clientContext.ExecuteQuery();

                }
            }
        }
    }
}
