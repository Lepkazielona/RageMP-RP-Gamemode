using System.IO;
using Microsoft.EntityFrameworkCore;
using RpGamemode;
using Tommy;


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
  

            //string connString = @"server=localhost;port=49153;database=server;user=root;password=mysqlpw";
            string connString;
            using (var conf = new Main().ConfigReader)
            {
                TomlTable table = TOML.Parse(conf);
                connString = table["Database"]["ConnString"];
            }
            optionsBuilder.UseMySql(connString);

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
                
                entity.Property(e => e.mileage).IsRequired();
                entity.Property(e => e.x).IsRequired();
                entity.Property(e => e.y).IsRequired();
                entity.Property(e => e.z).IsRequired();
                entity.Property(e => e.rot).IsRequired();
                entity.Property(e => e.color1).IsRequired();
                entity.Property(e => e.color2).IsRequired();

                entity.HasOne(d => d.CarModel)
                    .WithMany(p => p.Cars);
                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Cars);
            });
            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasKey(e => e.ID);
                
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.model).IsRequired();
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