using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInformationLib
{
    public class NamespaceInformation
    {
        public string Name { get; set; }
        public List<DataTypeInformation> DataTypeInformation { get; set; } = new List<DataTypeInformation>();
    }
}
