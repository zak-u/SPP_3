using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AssemblyInformationLib
{
    public class DataTypeInformation 
    {
        public string Name { get; set; }
        public List<ObjectInformation> Fields { get; set; } = new List<ObjectInformation>();
        public List<ObjectInformation> Properties { get; set; } = new List<ObjectInformation>();
        public List<MethodInformation> Methods { get; set; } = new List<MethodInformation>();

        public IList CommonMembersCollection
        {
            get
            {
                return new CompositeCollection()
                {
                    new CollectionContainer(){Collection = Fields},
                    new CollectionContainer(){Collection = Properties},
                    new CollectionContainer(){Collection = Methods}
                };
            }
        }
    }
}
