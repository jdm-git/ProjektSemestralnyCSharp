using System;
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
    /// Logika interakcji dla klasy AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private ProjectContext _context = new ProjectContext();
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));

            _context.Categories.Load();
            categoryViewSource.Source = _context.Categories.Local;


            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));

            _context.Products.Load();
            productViewSource.Source = _context.Products.Local;

        }
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (productDataGrid.SelectedIndex >= 0)
            {
                
            }
        }
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            int productId = (productDataGrid.SelectedItem as Product).Id;

            Product product = _context.Products.Where(p => p.Id == productId).SingleOrDefault();

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            int categoryId = (categoryDataGrid.SelectedItem as Category).Id;
            Category category = _context.Categories.Where(c => c.Id == categoryId).SingleOrDefault();

            _context.Categories.Remove(category);
            _context.SaveChanges();

        }
        private void UpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            if (productDataGrid.SelectedIndex >= 0)
            {

            }
        }
        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(categoryName.Text))
                MessageBox.Show("Cannot add an empty category");
            else
            {
            _context.Categories.Add(new Category
            {
                Name = categoryName.Text
            });

            _context.SaveChanges();
            }
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(productName.Text) || String.IsNullOrEmpty(productPrice.Text) || String.IsNullOrEmpty(categoryId.Text) || String.IsNullOrEmpty(productDescription.Text))
                _context.Products.Add(new Product
            {
                Name = productName.Text,
                Price = int.Parse(productPrice.Text),
                CategoryId = int.Parse(categoryId.Text),
                Description = productDescription.Text
            });


            _context.SaveChanges();
            
        }
        public void RemoveText(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
