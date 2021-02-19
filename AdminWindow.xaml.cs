using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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
    //Main class of AdminWindow
    //including all methods interacting with DB context
    public partial class AdminWindow : Window
    {
        private ProjectContext _context = new ProjectContext();
        private Category categoryToEdit;
        private Product productToEdit;
        private bool isUpdateMode = false;
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
        
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if(productToEdit == null)
            {
                MessageBox.Show("Cannot delete empty record");
            }
            else
            {
                int productId = (productDataGrid.SelectedItem as Product).Id;

                Product product = _context.Products.Where(p => p.Id == productId).SingleOrDefault();

                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            
        }
        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if(categoryToEdit == null)
            {
                MessageBox.Show("Cannot delete empty record");
            }
            else
            {
                int categoryId = (categoryDataGrid.SelectedItem as Category).Id;
                Category category = _context.Categories.Where(c => c.Id == categoryId).SingleOrDefault();

                _context.Categories.Remove(category);
                _context.SaveChanges();
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
                MessageBox.Show("Cannot add an empty product");
            else
            {
                _context.Products.Add(new Product
                {
                    Name = productName.Text,
                    Price = decimal.Parse(productPrice.Text),
                    CategoryId = int.Parse(categoryId.Text),
                    Description = productDescription.Text
                });


                _context.SaveChanges();
            }
            
        }
        private void gridCategory_SelectionChanged(object sender, RoutedEventArgs e)
        {
            categoryToEdit = categoryDataGrid.SelectedItem as Category;
        }
        private void gridProduct_SelectionChanged(object sender, RoutedEventArgs e)
        {
            productToEdit = productDataGrid.SelectedItem as Product;
        }
        private void UpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            if(categoryToEdit == null)
            {
                MessageBox.Show("Cannot edit empty row");
            }
            else
            {
            isUpdateMode = true;
            categoryDataGrid.Columns[1].IsReadOnly = false;
            }
        }
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (productToEdit == null)
            {
                MessageBox.Show("Cannot edit empty row");
            }
            else
            {
                isUpdateMode = true;
                productDataGrid.Columns[2].IsReadOnly = false;
                productDataGrid.Columns[3].IsReadOnly = false;
                productDataGrid.Columns[4].IsReadOnly = false;
            }
            
        }
        private void gridCategory_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (isUpdateMode)
            {
                Category temporaryCategory = _context.Categories.Where(c => c.Id == categoryToEdit.Id).SingleOrDefault();

                FrameworkElement element_1 = categoryDataGrid.Columns[1].GetCellContent(e.Row);
                if(element_1.GetType() == typeof(TextBox))
                {
                    var name = ((TextBox)element_1).Text;
                    categoryToEdit.Name = name;
                }
            }
        }
        private void gridCategory_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            _context.SaveChanges();
            MessageBox.Show("Row updated...");
        }
        private void gridProduct_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (isUpdateMode)
            {
                Product temporaryProduct = _context.Products.Where(p => p.Id == productToEdit.Id).SingleOrDefault();

                FrameworkElement element_1 = productDataGrid.Columns[2].GetCellContent(e.Row);
                if (element_1.GetType() == typeof(TextBox))
                {
                    var description = ((TextBox)element_1).Text;
                    productToEdit.Description = description;
                }
                FrameworkElement element_2 = productDataGrid.Columns[3].GetCellContent(e.Row);
                if (element_2.GetType() == typeof(TextBox))
                {
                    var name = ((TextBox)element_2).Text;
                    productToEdit.Name = name;
                }
                FrameworkElement element_3 = productDataGrid.Columns[4].GetCellContent(e.Row);
                if (element_3.GetType() == typeof(TextBox))
                {
                    var price = Convert.ToDecimal(((TextBox)element_3).Text, CultureInfo.InvariantCulture);
                    
                    productToEdit.Price = price;
                }
            }
        }
        private void gridProduct_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            _context.SaveChanges();
            MessageBox.Show("Row updated...");
        }
    }
}
