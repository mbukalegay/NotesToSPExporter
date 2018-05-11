using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesToSharePointExporter.Models
{
    public class ExportParams
    {
        public string SiteCollectionUrl { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string listName { get; set; }
        public string ImportFilePath { get; set; }
        public string ExportFileLocation { get; set; }
    }
}
