using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestArtIS.Server.Models;
using RestArtIS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestArtIS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MenuType>().HasData(
                new MenuType() { Id = 1, Name = "Denní" },
                new MenuType() { Id = 2, Name = "Týdenní" },
                new MenuType() { Id = 3, Name = "Stálé" }
                );
            builder.Entity<Allergen>().HasData(
                new Allergen { Id = 1, Code = "1", Name = "Obiloviny obsahující lepek", NameAddition = "pšenice, žito, ječmen, oves, špalda, kamut nebo jejich odrůdy a výrobky z nich" },
                new Allergen { Id = 2, Code = "2", Name = "Korýši", NameAddition = "a výrobky z nich" },
                new Allergen { Id = 3, Code = "3", Name = "Vejce", NameAddition = "a výrobky z nich" },
                new Allergen { Id = 4, Code = "4", Name = "Ryby", NameAddition = "a výrobky z nich" },
                new Allergen { Id = 5, Code = "5", Name = "Jádra podzemnice olejné (arašídy)", NameAddition = "a výrobky z nich" },
                new Allergen { Id = 6, Code = "6", Name = "Sójové boby (sója)", NameAddition = "a výrobky z nich" },
                new Allergen { Id = 7, Code = "7", Name = "Mléko", NameAddition = "a výrobky z něj" },
                new Allergen { Id = 8, Code = "8", Name = "Skořápkové plody", NameAddition = "Mandle, lískové ořechy, vlašské ořechy, kešu ořechy, pekanové ořechy, para ořechy, pistácie, makadamie a výrobky z nich" },
                new Allergen { Id = 9, Code = "9", Name = "Celer", NameAddition = "a výrobky z něj" },
                new Allergen { Id = 10, Code = "10", Name = "Hořčice", NameAddition = "a výrobky z ní" },
                new Allergen { Id = 11, Code = "11", Name = "Sezamová semena (sezam)", NameAddition = "a výrobky z nich" },
                new Allergen { Id = 12, Code = "12", Name = "Oxid siřičitý a siřičitany", NameAddition = "v koncentracích vyšších než 10 mg, ml/kg, l, vyjádřeno SO2" },
                new Allergen { Id = 13, Code = "13", Name = "Vlčí bob (lupina)", NameAddition = "a výrobky z něj" },
                new Allergen { Id = 14, Code = "14", Name = "Měkkýši", NameAddition = "a výrobky z nich" }
                );
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<VatHistory> VatHistories { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<MenuItemTemplate> MenuItemTemplates { get; set; }
        public DbSet<MenuItemCategory> MenuItemCategories { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<OrderItem> OrderItems { get; set; } 
        public DbSet<DeliveryRoute> DeliveryRoutes { get; set; } 
    }
}


