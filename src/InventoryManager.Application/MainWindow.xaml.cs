using InventoryManager.Database;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
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

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Konstruktor głównego okna zawierający grid z przedmiotami
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda wykonująca się po załadowaniu komponentu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            GetProducts();
        }

        /// <summary>
        /// Metoda pokazująca okienko do dodania nowego projektu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProduct();
            addProductWindow.Show();
        }

        /// <summary>
        /// Metoda która usuwa nam wybrany na gridzie produkt z bazy danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProductClick(object sender, RoutedEventArgs e)
        {
            var selectedProduct = (Product)ProductsDataGrid.SelectedItem;
            if (selectedProduct == null)
            {
                return;
            }

            using (var context = new InventoryManagerContext())
            {
                var product = context.Products.FirstOrDefault<Product>(x => x.RecId == selectedProduct.RecId);
                context.Remove(product);
                context.SaveChanges();

                MessageBox.Show("Pomyślnie usunięto produkt!", "Usuwanie produktu", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Metoda pobierająca nam wszystkie produkty z bazy danych
        /// </summary>
        /// <returns></returns>
        private List<Product> GetProducts()
        {
            var products = new List<Product>();

            using (var context = new InventoryManagerContext())
            {
                products = context.Products.ToList();
            }
            ProductsDataGrid.ItemsSource = products;

            return products;
        }

        /// <summary>
        /// Handler przycisku odświeżającego nam grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            GetProducts();
        }
    }
}
