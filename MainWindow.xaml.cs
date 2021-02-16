using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ProjektSemestralnyCSharp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectContext _context = new ProjectContext();
        private bool isUpdateMode = false;
        private Client objCLientToEdit;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));

            _context.Clients.Load();
            clientViewSource.Source = _context.Clients.Local;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _context.Dispose();
        }
        private void UpdateClient_Click(object sender, RoutedEventArgs e)
        {
            objCLientToEdit = clientDataGrid.SelectedItem as Client;
            if(objCLientToEdit == null)
            {
                MessageBox.Show("Cannot Edit the blank Entry");
            }
            else
            {
                isUpdateMode = true;
                clientDataGrid.Columns[1].IsReadOnly = false;
                clientDataGrid.Columns[3].IsReadOnly = false;
                clientDataGrid.Columns[4].IsReadOnly = false;
                clientDataGrid.Columns[7].IsReadOnly = false;
                clientDataGrid.Columns[8].IsReadOnly = false;
                clientDataGrid.Columns[9].IsReadOnly = false;
            }

        }
        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            objCLientToEdit = clientDataGrid.SelectedItem as Client;
            if(objCLientToEdit == null)
            {
                MessageBox.Show("Cannot delete the blank Entry");
            }
            else
            {
                _context.Clients.Remove(objCLientToEdit);
                _context.SaveChanges();
            }
        }
        private void OpenWindow_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }
        private void gridClient_SelectionChanged(object sender, RoutedEventArgs e)
        {
           objCLientToEdit = clientDataGrid.SelectedItem as Client;
        }
        private void gridClient_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (isUpdateMode)
            {
                Client temporaryClient = _context.Clients.Where(c => c.Id == objCLientToEdit.Id).SingleOrDefault();

                FrameworkElement element_1 = clientDataGrid.Columns[1].GetCellContent(e.Row);
                if(element_1.GetType() == typeof(TextBox))
                {
                var adress = ((TextBox)element_1).Text;
                objCLientToEdit.Adress = adress;
                }

                FrameworkElement element_2 = clientDataGrid.Columns[3].GetCellContent(e.Row);
                if (element_2.GetType() == typeof(TextBox))
                {
                var newName = ((TextBox)element_2).Text;
                objCLientToEdit.FirstName = newName;
                }

                FrameworkElement element_3 = clientDataGrid.Columns[4].GetCellContent(e.Row);
                if (element_3.GetType() == typeof(TextBox))
                {
                    var newSurname = ((TextBox)element_3).Text;
                    objCLientToEdit.LastName = newSurname;
                }

                FrameworkElement element_4 = clientDataGrid.Columns[7].GetCellContent(e.Row);
                if (element_4.GetType() == typeof(TextBox))
                {
                    var newPhone = ((TextBox)element_4).Text;
                    objCLientToEdit.Phone = newPhone;
                }


                FrameworkElement element_5 = clientDataGrid.Columns[8].GetCellContent(e.Row);
                if (element_5.GetType() == typeof(TextBox))
                {
                    var newState = ((TextBox)element_5).Text;
                    objCLientToEdit.State = newState;
                }


                FrameworkElement element_6 = clientDataGrid.Columns[9].GetCellContent(e.Row);
                if(element_6.GetType() == typeof(TextBox))
                {
                    var newZipCode = ((TextBox)element_6).Text;
                    objCLientToEdit.ZipCode = newZipCode;
                }
            }
        }
        private void clientGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            _context.SaveChanges();
            MessageBox.Show("Row updated...");
        }
    }
}
