using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace owl.api.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Clusterdata> Clusterdata { get; set; }
        public virtual DbSet<Incidents> Incidents { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<SchemaMigrations> SchemaMigrations { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=development.sqlite3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArInternalMetadata>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasColumnType("varchar")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<Claims>(entity =>
            {
                entity.ToTable("claims");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.File)
                    .HasColumnName("file")
                    .HasColumnType("varchar");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Clusterdata>(entity =>
            {
                entity.ToTable("clusterdata");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Incidents>(entity =>
            {
                entity.ToTable("incidents");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Casualties).HasColumnName("casualties");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Impacted).HasColumnName("impacted");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar");

                entity.Property(e => e.Managers)
                    .HasColumnName("managers")
                    .HasColumnType("varchar");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.ToTable("messages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.File)
                    .HasColumnName("file")
                    .HasColumnType("varchar");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Mtype)
                    .HasColumnName("mtype")
                    .HasColumnType("varchar");

                entity.Property(e => e.Read)
                    .HasColumnName("read")
                    .HasColumnType("boolean");

                entity.Property(e => e.Recipient).HasColumnName("recipient");

                entity.Property(e => e.Sender).HasColumnName("sender");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("notifications");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Priorities>(entity =>
            {
                entity.ToTable("priorities");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Details).HasColumnName("details");

                entity.Property(e => e.IncidentId).HasColumnName("incident_id");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("varchar");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Resources>(entity =>
            {
                entity.ToTable("resources");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("varchar");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SchemaMigrations>(entity =>
            {
                entity.HasKey(e => e.Version);

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("varchar")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar");

                entity.Property(e => e.Incident).HasColumnName("incident");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                entity.Property(e => e.PasswordDigest)
                    .HasColumnName("password_digest")
                    .HasColumnType("varchar");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar");

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasColumnType("varchar");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar");
            });
        }
    }
}
