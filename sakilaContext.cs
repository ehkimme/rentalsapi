using Microsoft.EntityFrameworkCore;

namespace RentalsApi
{
    public partial class sakilaContext : DbContext
    {
        public sakilaContext()
        {
        }

        public sakilaContext(DbContextOptions<sakilaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<FilmActor> FilmActors { get; set; } = null!;
        public virtual DbSet<FilmCategory> FilmCategories { get; set; } = null!;
        public virtual DbSet<FilmText> FilmTexts { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;

        public virtual DbSet<StaffList> StaffLists { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source = sakila.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actor");

                entity.HasIndex(e => e.LastName, "idx_actor_last_name");

                entity.Property(e => e.ActorId)
                    .HasColumnType("int")
                    .ValueGeneratedNever()
                    .HasColumnName("actor_id");

                entity.Property(e => e.FirstName)
                    .HasColumnType("VARCHAR(45)")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasColumnType("VARCHAR(45)")
                    .HasColumnName("last_name");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.CityId, "idx_fk_city_id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("int")
                    .ValueGeneratedNever()
                    .HasColumnName("address_id");

                entity.Property(e => e.Address1)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("address");

                entity.Property(e => e.Address2)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("address2");

                entity.Property(e => e.CityId)
                    .HasColumnType("INT")
                    .HasColumnName("city_id");

                entity.Property(e => e.District)
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("district");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.Phone)
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("VARCHAR(10)")
                    .HasColumnName("postal_code");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("SMALLINT")
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR(25)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.CountryId, "idx_fk_country_id");

                entity.Property(e => e.CityId)
                    .HasColumnType("int")
                    .ValueGeneratedNever()
                    .HasColumnName("city_id");

                entity.Property(e => e.City1)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("city");

                entity.Property(e => e.CountryId)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("country_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId)
                    .HasColumnType("SMALLINT")
                    .ValueGeneratedNever()
                    .HasColumnName("country_id");

                entity.Property(e => e.Country1)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("country");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.AddressId, "idx_customer_fk_address_id");

                entity.HasIndex(e => e.StoreId, "idx_customer_fk_store_id");

                entity.HasIndex(e => e.LastName, "idx_customer_last_name");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.Active)
                    .HasColumnType("CHAR(1)")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'Y'");

                entity.Property(e => e.AddressId)
                    .HasColumnType("INT")
                    .HasColumnName("address_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("create_date");

                entity.Property(e => e.Email)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasColumnType("VARCHAR(45)")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasColumnType("VARCHAR(45)")
                    .HasColumnName("last_name");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.StoreId)
                    .HasColumnType("INT")
                    .HasColumnName("store_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("film");

                entity.HasIndex(e => e.LanguageId, "idx_fk_language_id");

                entity.HasIndex(e => e.OriginalLanguageId, "idx_fk_original_language_id");

                entity.Property(e => e.FilmId)
                    .HasColumnType("int")
                    .ValueGeneratedNever()
                    .HasColumnName("film_id");

                entity.Property(e => e.Description)
                    .HasColumnType("BLOB SUB_TYPE TEXT")
                    .HasColumnName("description");

                entity.Property(e => e.LanguageId)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("language_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.Length)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("length");

                entity.Property(e => e.OriginalLanguageId)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("original_language_id");

                entity.Property(e => e.Rating)
                    .HasColumnType("VARCHAR(10)")
                    .HasColumnName("rating")
                    .HasDefaultValueSql("'G'");

                entity.Property(e => e.ReleaseYear)
                    .HasColumnType("VARCHAR(4)")
                    .HasColumnName("release_year");

                entity.Property(e => e.RentalDuration)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("rental_duration")
                    .HasDefaultValueSql("3");

                entity.Property(e => e.RentalRate)
                    .HasColumnType("DECIMAL(4,2)")
                    .HasColumnName("rental_rate")
                    .HasDefaultValueSql("4.99");

                entity.Property(e => e.ReplacementCost)
                    .HasColumnType("DECIMAL(5,2)")
                    .HasColumnName("replacement_cost")
                    .HasDefaultValueSql("19.99");

                entity.Property(e => e.SpecialFeatures)
                    .HasColumnType("VARCHAR(100)")
                    .HasColumnName("special_features");

                entity.Property(e => e.Title)
                    .HasColumnType("VARCHAR(255)")
                    .HasColumnName("title");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.FilmLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.OriginalLanguage)
                    .WithMany(p => p.FilmOriginalLanguages)
                    .HasForeignKey(d => d.OriginalLanguageId);
            });

            modelBuilder.Entity<FilmActor>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.FilmId });

                entity.ToTable("film_actor");

                entity.Property(e => e.ActorId)
                    .HasColumnType("INT")
                    .HasColumnName("actor_id");

                entity.Property(e => e.FilmId)
                    .HasColumnType("INT")
                    .HasColumnName("film_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmActors)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FilmCategory>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CategoryId });

                entity.ToTable("film_category");

                entity.HasIndex(e => e.CategoryId, "idx_fk_film_category_category");

                entity.HasIndex(e => e.FilmId, "idx_fk_film_category_film");

                entity.Property(e => e.FilmId)
                    .HasColumnType("INT")
                    .HasColumnName("film_id");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("category_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FilmCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmCategories)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FilmText>(entity =>
            {
                entity.HasKey(e => e.FilmId);

                entity.ToTable("film_text");

                entity.Property(e => e.FilmId)
                    .HasColumnType("SMALLINT")
                    .ValueGeneratedNever()
                    .HasColumnName("film_id");

                entity.Property(e => e.Description)
                    .HasColumnType("BLOB SUB_TYPE TEXT")
                    .HasColumnName("description");

                entity.Property(e => e.Title)
                    .HasColumnType("VARCHAR(255)")
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.HasIndex(e => e.FilmId, "idx_fk_film_id");

                entity.HasIndex(e => new { e.StoreId, e.FilmId }, "idx_fk_film_id_store_id");

                entity.Property(e => e.InventoryId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("inventory_id");

                entity.Property(e => e.FilmId)
                    .HasColumnType("INT")
                    .HasColumnName("film_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.StoreId)
                    .HasColumnType("INT")
                    .HasColumnName("store_id");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.LanguageId)
                    .HasColumnType("SMALLINT")
                    .ValueGeneratedNever()
                    .HasColumnName("language_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.Name)
                    .HasColumnType("CHAR(20)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.CustomerId, "idx_fk_customer_id");

                entity.HasIndex(e => e.StaffId, "idx_fk_staff_id");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("int")
                    .ValueGeneratedNever()
                    .HasColumnName("payment_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("DECIMAL(5,2)")
                    .HasColumnName("amount");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("INT")
                    .HasColumnName("customer_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("payment_date");

                entity.Property(e => e.RentalId)
                    .HasColumnType("INT")
                    .HasColumnName("rental_id");

                entity.Property(e => e.StaffId)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("staff_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Rental)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.RentalId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("rental");

                entity.HasIndex(e => e.CustomerId, "idx_rental_fk_customer_id");

                entity.HasIndex(e => e.InventoryId, "idx_rental_fk_inventory_id");

                entity.HasIndex(e => e.StaffId, "idx_rental_fk_staff_id");

                entity.HasIndex(e => new { e.RentalDate, e.InventoryId, e.CustomerId }, "idx_rental_uq")
                    .IsUnique();

                entity.Property(e => e.RentalId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("rental_id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("INT")
                    .HasColumnName("customer_id");

                entity.Property(e => e.InventoryId)
                    .HasColumnType("INT")
                    .HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.RentalDate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("rental_date");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("return_date");

                entity.Property(e => e.StaffId)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("staff_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            

            
            modelBuilder.Entity<StaffList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("staff_list");

                entity.Property(e => e.Address)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("country");

                entity.Property(e => e.Id)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("phone");

                entity.Property(e => e.Sid)
                    .HasColumnType("INT")
                    .HasColumnName("SID");

                entity.Property(e => e.ZipCode)
                    .HasColumnType("VARCHAR(10)")
                    .HasColumnName("zip_code");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.HasIndex(e => e.AddressId, "idx_fk_store_address");

                entity.HasIndex(e => e.ManagerStaffId, "idx_store_fk_manager_staff_id");

                entity.Property(e => e.StoreId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("store_id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("INT")
                    .HasColumnName("address_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.ManagerStaffId)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("manager_staff_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ManagerStaff)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.ManagerStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "idx_fk_staff_address_id");

                entity.HasIndex(e => e.StoreId, "idx_fk_staff_store_id");

                entity.Property(e => e.StaffId)
                    .HasColumnType("SMALLINT")
                    .ValueGeneratedNever()
                    .HasColumnName("staff_id");

                entity.Property(e => e.Active)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("active")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddressId)
                    .HasColumnType("INT")
                    .HasColumnName("address_id");

                entity.Property(e => e.Email)
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasColumnType("VARCHAR(45)")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasColumnType("VARCHAR(45)")
                    .HasColumnName("last_name");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("last_update");

                entity.Property(e => e.Password)
                    .HasColumnType("VARCHAR(40)")
                    .HasColumnName("password");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.StoreId)
                    .HasColumnType("INT")
                    .HasColumnName("store_id");

                entity.Property(e => e.Username)
                    .HasColumnType("VARCHAR(16)")
                    .HasColumnName("username");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
