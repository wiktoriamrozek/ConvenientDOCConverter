using System;
using System.Diagnostics;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel();
        }

        private void OpenFolder(string folderPath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                Arguments = folderPath.Substring(0, folderPath.LastIndexOf('\\')),
                FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (pathTexBox.Text == String.Empty)
            {
                MessageBox.Show("Please select a file");
                return;
            }

            switch (conversionDropDown.SelectedIndex)
            {
                case 0:
                    ConvertDocToPDF(pathTexBox.Text);
                    break;
                case 1:
                    ConvertPDFToDoc(pathTexBox.Text);
                    break;
                case 2:
                    ConvertPNGToPDF(pathTexBox.Text);
                    break;
                default:
                    MessageBox.Show("Please select an option");
                    return;
            }

            OpenFolder(pathTexBox.Text);
        }
    }
}