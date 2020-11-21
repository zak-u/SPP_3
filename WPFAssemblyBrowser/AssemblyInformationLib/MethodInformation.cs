using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInformationLib
{
    public class MethodInformation
    {
        public string Name { get; set; }
        public Type ReturnType { get; set; }
        public List<ObjectInformation> MethodParametersInformation { get; set; } = new List<ObjectInformation>();
    }
}
