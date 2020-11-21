using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyInformationLib;
using System.Windows;
using Microsoft.Win32;

namespace WPFAssemblyBrowser
{
    class ViewModel : INotifyPropertyChanged
    {
        private AssemblyInformationGetter assemblyInformationGetter;
        private ObservableCollection<AssemblyInformation> assembliesInformation;
        private MyCommand openCommand;

        public ViewModel() 
        {
            assemblyInformationGetter = new AssemblyInformationGetter();
            assembliesInformation = new ObservableCollection<AssemblyInformation>();
        }

        public ObservableCollection<AssemblyInformation> AssembliesInformation
        {
            get
            {
                return assembliesInformation;
            }
            set
            {
                assembliesInformation = value;
                onPropertyChanged("NamespaceInformation");
            }
        }

        
        public MyCommand OpenCommand
        {
            get
            {
                
                openCommand = new MyCommand(obj =>
                {
                    string fileName = null;
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.Filter = "Library files (*.dll)|*.dll";

                    if (fileDialog.ShowDialog() == true)
                    {
                        fileName = fileDialog.FileName;
                    }

                    try
                    {
                        AssemblyInformation assemblyInformation = assemblyInformationGetter.GetAssemblyInformation(fileName);
                        assembliesInformation.Add(assemblyInformation);
                    }
                    catch
                    {
                        MessageBox.Show($"Failed to load or parse assembly");
                    }
                });

                return openCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;//метод, который обрабатывает события
        void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
