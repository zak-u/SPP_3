using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using AssemblyInformationLib; 


namespace WPFAssemblyBrowser
{
    class MembersCollectionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string name = values[0] as string;
            Type type = values[1] as Type;
            Type returnType = values[2] as Type;

            List<ObjectInformation> parameters = values[3] as List<ObjectInformation>;

            string result = "";
            if (returnType != null)
            {
                result += returnType.Name + " ";
            }

             if (type != null)
             {
                 result += type.Name + " ";
             }

            if (name != null)
            {
                result += name + " ";
            }

            if (parameters != null)
            {
                result += "(";
                foreach (ObjectInformation methodParametersInformation in parameters)
                {
                    result += $"{methodParametersInformation.Type.Name} {methodParametersInformation.Name}";
                }
                result += ")";
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
