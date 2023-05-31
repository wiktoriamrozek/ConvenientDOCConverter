using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DocumentModel document;
        public DocumentModel Document
        {
            get { return document; }
            set
            {
                document = value;
                OnPropertyChanged(nameof(Document));
            }
        }

        public ICommand ConvertCommand { get; }

        public ICommand SelectFileCommand { get; }

        public MainWindowViewModel()
        {
            Document = new DocumentModel();
            ConvertCommand = new RelayCommand(Convert, CanConvert);
            SelectFileCommand = new RelayCommand(SelectFile);
            ConvertCommand = new RelayCommand(ConvertButton_Click);
        }

        public void ConvertButton_Click(object sender, RoutedEventArgs e)
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

        // Implement the INotifyPropertyChanged interface to notify the view of property changes
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}