using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTestApp.Models
{
    public class File
    {
        public FileItem[] variables { get; set; }
    }
    public class FileItem
    {
        public string var1 { get; set; }
        public string var2 { get; set; }
    }
}
