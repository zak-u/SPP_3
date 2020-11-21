using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInformationLib
{
    public class AssemblyInformation
    {
        public string Name { get; set; }
        public List<NamespaceInformation> NamespaceInformation { get; set; } = new List<NamespaceInformation>();
    }
}
