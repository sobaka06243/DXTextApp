using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTestApp.Models
{
    public class File
    {
        public FileItem[] files { get; set; }
    }
    public class FileItem
    {
        public string name { get; set; }
        public string text { get; set; }
    }
}
