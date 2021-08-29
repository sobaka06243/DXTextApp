using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTestApp.Models
{
    public class Variable
    {
        public string NameVar { get; set; }
        public string ValVar { get; set; }

        public Variable(string nameVar, string valVar)
        {
            NameVar = nameVar;
            ValVar = valVar;
        }
    }
}
