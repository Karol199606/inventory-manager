using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InventoryManager.Database;
using InventoryManager.Models;

namespace InventoryManager
{
    /// <summary>
    /// Logika interakcji dla klasy AddProduct.xaml
    /// </summary>
    public partial class AddProduct
    {
        /// <summary>
        /// Konstruktor klasy inicjalizujący komponent dodająćy przedmiot do bazy
        /// </summary>
        public AddProduct()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda wykonująca się po załadowaniu się komponentu
        /// W tym przypadku pobiera nam jedynie dane do ComboBox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLoad(object sender, RoutedEventArgs e)
        {
            TypeComboBox.ItemsSource = Enum.GetValues(typeof(ProductType)).Cast<ProductType>();
        }

        /// <summary>
        /// Metoda wykonywana po kliknięciu przycisku "Doda przedmiot"
        /// która dodaje nam produkt do bazy danych i wyświetla informację o że przedmiot się dodał
        /// po czym zamyka okno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var product = new Product
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecId = Guid.NewGuid(),
                Name = Name.Text,
                Description = Description.Text,
                Id = Id.Text,
                Brand = Brand.Text,
                Model = Model.Text,
                Owner = Owner.Text,
                Type = (ProductType)TypeComboBox.SelectedItem
            };

            using (var context = new InventoryManagerContext())
            {
                context.Products.Add(product);
                context.SaveChanges();

                MessageBox.Show("Pomyślnie dodano produkt!", "Dodawanie produktu", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Close();
        }
    }
}
