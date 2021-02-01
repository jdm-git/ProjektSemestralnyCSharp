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

namespace ProjektSemestralnyCSharp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectContext _context = new ProjectContext();
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
            if(clientDataGrid.SelectedIndex >= 0)
            {
                var cellInfo = clientDataGrid.SelectedItem;
                Client newClient = new Client();

               // newClient.Id = int.Parse(idColumn.GetCellContent(cellInfo);
            }
        }
        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            int clientId = (clientDataGrid.SelectedItem as Client).Id;

            Client client = _context.Clients.Where(c => c.Id == clientId).SingleOrDefault();

            _context.Clients.Remove(client);
            _context.SaveChanges();

            
        }
        private void OpenWindow_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
