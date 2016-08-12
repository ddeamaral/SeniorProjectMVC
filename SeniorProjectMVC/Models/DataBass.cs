namespace SeniorProjectMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBass : DbContext
    {
        public DataBass()
            : base("name=DataBass")
        {
        }

        public virtual DbSet<AddressBook> AddressBooks { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Fullfilment> Fullfilments { get; set; }
        public virtual DbSet<OrderHeader> OrderHeaders { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }
        public virtual DbSet<SKU_Table> SKU_Table { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<XREF_AddressBookCustomer> XREF_AddressBookCustomer { get; set; }
        public virtual DbSet<XREF_CatalogProduct> XREF_CatalogProduct { get; set; }
        public virtual DbSet<XREF_CustomerRole> XREF_CustomerRole { get; set; }
        public virtual DbSet<XREF_TaxCustomer> XREF_TaxCustomer { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressBook>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<AddressBook>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<AddressBook>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<AddressBook>()
                .Property(e => e.StateID)
                .IsFixedLength();

            modelBuilder.Entity<AddressBook>()
                .Property(e => e.Zipcode)
                .IsFixedLength();

            modelBuilder.Entity<AddressBook>()
                .HasMany(e => e.XREF_AddressBookCustomer)
                .WithRequired(e => e.AddressBook)
                .HasForeignKey(e => e.AddresBook_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catalog>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Catalog>()
                .Property(e => e.Extra)
                .IsUnicode(false);

            modelBuilder.Entity<Catalog>()
                .HasMany(e => e.XREF_CatalogProduct)
                .WithRequired(e => e.Catalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.DOB)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderHistories)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.XREF_AddressBookCustomer)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.XREF_CustomerRole)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Percentage)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Extra)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.Discount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fullfilment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Fullfilment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Fullfilment>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Fullfilment>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Fullfilment>()
                .Property(e => e.StateID)
                .IsUnicode(false);

            modelBuilder.Entity<Fullfilment>()
                .Property(e => e.Zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<Fullfilment>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.Subtotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderHeader>()
                .HasMany(e => e.OrderHistories)
                .WithRequired(e => e.OrderHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderHeader>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.OrderHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderHeader>()
                .HasMany(e => e.XREF_TaxCustomer)
                .WithRequired(e => e.OrderHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.SKU_Table)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.XREF_CatalogProduct)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Property>()
                .Property(e => e.Color)
                .IsFixedLength();

            modelBuilder.Entity<Property>()
                .Property(e => e.Weight)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Property>()
                .Property(e => e.PropertyName)
                .IsFixedLength();

            modelBuilder.Entity<Property>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.SKU_Table)
                .WithRequired(e => e.Property)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.XREF_CustomerRole)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShippingMethod>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingMethod>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingMethod>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShippingMethod>()
                .HasMany(e => e.OrderHeaders)
                .WithRequired(e => e.ShippingMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SKU_Table>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SKU_Table>()
                .Property(e => e.UnitType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SKU_Table>()
                .Property(e => e.SKUPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SKU_Table>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.SKU_Table)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.OrderHeaders)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tax>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tax>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tax>()
                .Property(e => e.Percentage)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Tax>()
                .HasMany(e => e.XREF_TaxCustomer)
                .WithRequired(e => e.Tax)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.Catalogs)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.Fullfilments)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);

            
        }
    }
}
