using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesToSharePointExporter.Models
{
    public class ExportList
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string Scope { get; set; }
        public string Categories { get; set; }
        public string Body { get; set; }
        public string ParsedInfo { get; set; }
        public Dictionary<string, string> RichTextImages { get; set; }
        public Dictionary<string, string> Items { get; set; }
        public Dictionary<string, string> Files { get; set; }
    }
}
