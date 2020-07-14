using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using InventoryManager.Models;

namespace InventoryManager.Database
{
    /// <summary>
    /// Klasa obsługująca bazę danych za pomocą EntityFramework
    /// </summary>
    class InventoryManagerContext : DbContext
    {
        private static bool _created = false;

        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Konstuktor inicjujący bazę danych i tworzący o ile to potrzebne
        /// </summary>
        public InventoryManagerContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        /// <summary>
        /// Metoda konfigurująca SQLite
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=inventorymanager.db");
    }
}
