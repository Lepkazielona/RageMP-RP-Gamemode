using System.IO;
using Microsoft.EntityFrameworkCore;


namespace DB
{
    public class DBContext:DbContext
    {
        public DbSet<Apartament> Apartments { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemModel> ItemModels { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
  
            //string connString = File.ReadAllText("C:\\RAGEMP\\server-files\\dotnet\\resources\\gamemode\\RpGamemode\\RpGamemode\\bin\\Debug\\netcoreapp3.1\\DB-CONFIG.txt");
            string connString = @"server=localhost;port=49153;database=server;user=root;password=mysqlpw";
            //optionsBuilder.UseMySQL(connString);
            optionsBuilder.UseMySql(connString);
            //@"server=localhost;port=49155;database=server;user=root;password=mysqlpw"
            //optionsBuilder.UseMySql(@"server=localhost;port=49153;database=server;user=root;password=mysqlpw");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Apartament>(entity =>
            {
                entity.HasKey(e => e.ID);
                
                entity.Property(e => e.x).IsRequired();
                entity.Property(e => e.y).IsRequired();
                entity.Property(e => e.z).IsRequired();
                
                entity.Property(e => e.name).IsRequired();
                entity.HasOne(d => d.Characters)
                    .WithMany(p => p.Apartaments);
                entity.HasIndex(e => e.name).IsUnique();
            });
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.ID);
                
                entity.Property(e => e.milage).IsRequired();
                entity.Property(e => e.x).IsRequired();
                entity.Property(e => e.y).IsRequired();
                entity.Property(e => e.z).IsRequired();
                
                entity.HasOne(d => d.CarModel)
                    .WithMany(p => p.Cars);
                entity.HasOne(d => d.Characters)
                    .WithMany(p => p.Cars);
            });
            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasKey(e => e.ID);
                
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.hash).IsRequired();
                entity.HasIndex(e => e.name).IsUnique();
            });
            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.ID);
                
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.surname).IsRequired();
                entity.Property(e => e.money).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Characters);
            });
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.count).IsRequired();

                
                entity.HasOne(d => d.ItemModel)
                    .WithMany(p => p.items);
                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Items);
            });
            modelBuilder.Entity<ItemModel>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.texture).IsRequired();
                entity.Property(e => e.isEatable).IsRequired();
                entity.HasIndex(e => e.name).IsUnique();

            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.nickname).IsRequired();
                entity.Property(e => e.creationDate).IsRequired();
                entity.Property(e => e.rank).IsRequired();
                entity.Property(e => e.password).IsRequired();
                entity.Property(e => e.passwordSol).IsRequired();
                
                entity.HasIndex(e => e.nickname).IsUnique();
            });
        }
    }
}