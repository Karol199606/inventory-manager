using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Models
{
    /// <summary>
    /// Klasa z właściwościami "Produktu" który jest mapowany do bazy danych
    /// </summary>
    public class Product
    {
        public Guid RecId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public ProductType Type { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Enum typów produktu
    /// </summary>
    public enum ProductType
    {
        Service,
        Product
    }
}
