using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.DocumentSet;
using NotesToSharePointExporter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
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
                    if (exportParams.IsSPOnline)
                    {
                        SecureString securePassWord = new SecureString();
                        foreach (char c in exportParams.password.ToCharArray()) securePassWord.AppendChar(c);
                        clientContext.Credentials = new SharePointOnlineCredentials(exportParams.username, securePassWord);
                    }
                    else
                    {
                        clientContext.Credentials = new NetworkCredential(exportParams.username, exportParams.password);
                    }
                    
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
                            // UploadBase64FileToFolder(kvp.Key, kvp.Value, "SiteAssets/images", exportParams);
                            Folder _folder = clientContext.Web.GetFolderByServerRelativeUrl("SiteAssets/images");
                            FileCreationInformation fci = new FileCreationInformation();
                            fci.Content = Convert.FromBase64String(kvp.Value);
                            fci.Url = kvp.Key;
                            fci.Overwrite = true;
                            Microsoft.SharePoint.Client.File fileToUpload = _folder.Files.Add(fci);
                            clientContext.Load(fileToUpload);

                            clientContext.ExecuteQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public void CreateDocSetItem(ExportList data, ExportParams exportParams, Dictionary<string, byte[]> filesDictionary)
        {
            try
            {
                using (var clientContext = new ClientContext(exportParams.SiteCollectionUrl))
                {
                    if (exportParams.IsSPOnline)
                    {
                        SecureString securePassWord = new SecureString();
                        foreach (char c in exportParams.password.ToCharArray()) securePassWord.AppendChar(c);
                        clientContext.Credentials = new SharePointOnlineCredentials(exportParams.username, securePassWord);
                    }
                    else
                    {
                        clientContext.Credentials = new NetworkCredential(exportParams.username, exportParams.password);
                    }

                    if (clientContext != null)
                    {
                        // Folder fold = clientContext.Web.GetFolderByServerRelativeUrl("NotesExportDocLib");
                        // fold.Files.Add()
                        List notesList = clientContext.Web.Lists.GetByTitle(exportParams.listName);
                        //// Get the parent folder where the document set has to be created
                        Folder parentFolder = notesList.RootFolder;

                        //// Get the "Document Set" content type by id (Document Set content type Id : 0x0120D520) for the document library
                        ContentType docsetCType = clientContext.Web.ContentTypes.GetById("0x0120D520");
                        clientContext.Load(docsetCType);
                        clientContext.ExecuteQuery();

                        var res = DocumentSet.Create(clientContext, parentFolder, data.Title, docsetCType.Id);

                        clientContext.ExecuteQuery();

                        var docsetFolder = clientContext.Web.GetFolderByServerRelativeUrl(res.Value);
                        docsetFolder.Properties["Subject"] = data.Subject;
                        docsetFolder.Properties["STATUS"] = data.Status;
                        docsetFolder.Properties["SCOPE"] = data.Scope;
                        docsetFolder.Properties["Body"] = data.Body;
                        docsetFolder.Update();
                        notesList.Update();
                        clientContext.ExecuteQuery();

                        foreach (KeyValuePair<string, byte[]> kvp in filesDictionary)
                        {
                            FileCreationInformation newFile = new FileCreationInformation();
                            newFile.ContentStream = new MemoryStream(kvp.Value);
                            newFile.Url = kvp.Key;

                            docsetFolder.Files.Add(newFile);
                            docsetFolder.Update();
                            clientContext.ExecuteQuery();
                            //MemoryStream fileStream = new MemoryStream(kvp.Value);
                            //string relUrl = "/NoteSPDocset/"+ data.Title + "/ "+kvp.Key;
                            //Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext,relUrl, fileStream, true);
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
