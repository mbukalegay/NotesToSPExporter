using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NotesToSharePointExporter
{
    public class Authentication
    {
        public List<string> SPOGetLists(string siteCollectionUrl, string email, string password)
        {
            List<string> siteLists = new List<string>();
            //bool retVal = false;
            using (ClientContext context = new ClientContext(siteCollectionUrl))
            {
                SecureString securePassWord = new SecureString();
                foreach (char c in password.ToCharArray()) securePassWord.AppendChar(c);
                context.Credentials = new SharePointOnlineCredentials(email, securePassWord);

                Web web = context.Web;
                context.Load(web.Lists, lists => lists.Include(list => list.Title));
                context.ExecuteQuery();
                foreach(List list in web.Lists)
                {
                    siteLists.Add(list.Title);
                }


            }
            return siteLists;

        }
    }
}
