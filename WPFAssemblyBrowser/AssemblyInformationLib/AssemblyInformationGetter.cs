using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInformationLib
{
    public class AssemblyInformationGetter
    {
        public AssemblyInformationGetter() { }

        private NamespaceInformation DetectNamespace(AssemblyInformation assemblyInformation, string namespaceName)
        {
            foreach (NamespaceInformation namespaceInformation in assemblyInformation.NamespaceInformation)
            {
                if (namespaceInformation.Name == namespaceName)
                {
                    return namespaceInformation;
                }
            }

            return null;
        }

        public AssemblyInformation GetAssemblyInformation(string fileName)
        {
            Assembly loadedAssembly = Assembly.LoadFrom(fileName);
            AssemblyInformation assemblyInformation = new AssemblyInformation();

            assemblyInformation.Name = loadedAssembly.FullName;
            NamespaceInformation namespaceInformation;
            foreach (Type type in loadedAssembly.GetTypes())
            {
                namespaceInformation = DetectNamespace(assemblyInformation, type.Namespace);
                if (namespaceInformation == null)
                {
                    namespaceInformation = new NamespaceInformation();
                    namespaceInformation.Name = type.Namespace;
                    assemblyInformation.NamespaceInformation.Add(namespaceInformation);
                }

                DataTypeInformation dataTypeInformation = new DataTypeInformation();
                dataTypeInformation.Name = type.Name;

                foreach (FieldInfo fieldInfo in type.GetFields())
                {
                    ObjectInformation fieldInformation = new ObjectInformation();
                    fieldInformation.Name = fieldInfo.Name;
                    fieldInformation.Type = fieldInfo.FieldType;
                    dataTypeInformation.Fields.Add(fieldInformation);
                }

                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    ObjectInformation propertyInformation = new ObjectInformation();
                    propertyInformation.Name = propertyInfo.Name;
                    propertyInformation.Type = propertyInfo.PropertyType;
                    dataTypeInformation.Properties.Add(propertyInformation);
                }

                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    MethodInformation methodInformation = new MethodInformation();
                    methodInformation.Name = methodInfo.Name;
                    methodInformation.ReturnType = methodInfo.ReturnType;
                    foreach (var parameter in methodInfo.GetParameters())
                    {
                        ObjectInformation methodParametersInformation = new ObjectInformation();
                        methodParametersInformation.Name = parameter.Name;
                        methodParametersInformation.Type = parameter.ParameterType;
                        methodInformation.MethodParametersInformation.Add(methodParametersInformation);
                    }
                    dataTypeInformation.Methods.Add(methodInformation);
                }

                namespaceInformation.DataTypeInformation.Add(dataTypeInformation);
            }

            return assemblyInformation;
        }
    }
}
