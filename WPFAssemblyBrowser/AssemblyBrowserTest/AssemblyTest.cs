using System;
using System.Reflection;
using AssemblyInformationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyBrowserTest
{
    [TestClass]
    public class AssemblyTest
    {
        AssemblyInformationGetter assemblyInformationGetter;
        AssemblyInformation assemblyInformation;

        private void GetTestAssemblyInfo()
        {
            assemblyInformationGetter = new AssemblyInformationGetter();
            assemblyInformation = assemblyInformationGetter.GetAssemblyInformation("AssemblyBrowserTest.dll");
        }

        [TestMethod]
        public void TestMethodAssemblyName()
        {
            GetTestAssemblyInfo();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Assert.AreEqual(assembly.FullName, assemblyInformation.Name);
        }

        [TestMethod]
        public void TestMethodDataType()
        {
            GetTestAssemblyInfo();

            Assert.AreEqual("AssemblyTest", assemblyInformation.NamespaceInformation[0].DataTypeInformation[0].Name);
        }

        [TestMethod]
        public void TestMethodMethodName()
        {
            GetTestAssemblyInfo();

            Assert.AreEqual("TestMethodMethodName", assemblyInformation.NamespaceInformation[0].DataTypeInformation[0].Methods[2].Name);
        }

        [TestMethod]
        public void TestMethodMethodReturnType()
        {
            GetTestAssemblyInfo();

            Assert.AreEqual(typeof(void), assemblyInformation.NamespaceInformation[0].DataTypeInformation[0].Methods[3].ReturnType);
        }
    }
}
