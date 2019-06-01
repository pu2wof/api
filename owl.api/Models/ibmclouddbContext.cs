using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Npgsql;

namespace owl.api.Models
{
	public partial class ibmclouddbContext : DbContext
	{
		private readonly EnvironmentConfig _configuration;

		public ibmclouddbContext(IOptions<EnvironmentConfig> configuration)
		{
			_configuration = configuration.Value;
		}

		public ibmclouddbContext(DbContextOptions<ibmclouddbContext> options, IOptions<EnvironmentConfig> configuration)
			: base(options)
		{
			_configuration = configuration.Value;
		}

		public virtual DbSet<AndroidDebugMessages> AndroidDebugMessages { get; set; }
		public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
		public virtual DbSet<Claims> Claims { get; set; }
		public virtual DbSet<Clusterdata> Clusterdata { get; set; }
		public virtual DbSet<Companies> Companies { get; set; }
		public virtual DbSet<DeploymentTestReports> DeploymentTestReports { get; set; }
		public virtual DbSet<DeviceObservations> DeviceObservations { get; set; }
		public virtual DbSet<Devices> Devices { get; set; }
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
				var connection = new NpgsqlConnection($"Host={_configuration.OwlApiDatabaseHost};Database={_configuration.OwlApiDatabaseName};Username={_configuration.OwlApiDatabaseUser};Password={_configuration.OwlApiDatabasePass};Port={_configuration.OwlApiDatabasePort};SSL Mode=Prefer;Trust Server Certificate=true");

				if (!string.IsNullOrEmpty(_configuration.OwlApiPgCert))
				{
					connection.ProvideClientCertificatesCallback += clientCerts => GetClientCertificates(clientCerts);
				}

				optionsBuilder.UseNpgsql(connection);
			}
		}

		private void GetClientCertificates(X509CertificateCollection clientCerts)
		{
			var base64CertBytes = System.Convert.FromBase64String(_configuration.OwlApiPgCert);
			var certificate = new X509Certificate2(base64CertBytes);
			clientCerts.Add(certificate);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasPostgresExtension("uuid-ossp");

			modelBuilder.Entity<AndroidDebugMessages>(entity =>
			{
				entity.ToTable("android_debug_messages");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.FromDeviceId)
					.IsRequired()
					.HasColumnName("from_device_id")
					.HasColumnType("character varying");

				entity.Property(e => e.FromDeviceType)
					.IsRequired()
					.HasColumnName("from_device_type")
					.HasColumnType("character varying");

				entity.Property(e => e.Payload)
					.IsRequired()
					.HasColumnName("payload")
					.HasColumnType("json");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

				entity.Property(e => e.Uuid)
					.IsRequired()
					.HasColumnName("uuid")
					.HasColumnType("character varying");
			});

			modelBuilder.Entity<ArInternalMetadata>(entity =>
			{
				entity.HasKey(e => e.Key);

				entity.ToTable("ar_internal_metadata");

				entity.Property(e => e.Key)
					.HasColumnName("key")
					.HasColumnType("character varying")
					.ValueGeneratedNever();

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

				entity.Property(e => e.Value)
					.HasColumnName("value")
					.HasColumnType("character varying");
			});

			modelBuilder.Entity<Claims>(entity =>
			{
				entity.ToTable("claims");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.Description).HasColumnName("description");

				entity.Property(e => e.File)
					.HasColumnName("file")
					.HasColumnType("character varying");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<Clusterdata>(entity =>
			{
				entity.ToTable("clusterdata");

				entity.HasIndex(e => e.CompanyId)
					.HasName("fki_clusterdata_companies");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CompanyId).HasColumnName("company_id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.DeviceId)
					.IsRequired()
					.HasColumnName("device_id")
					.HasColumnType("character varying");

				entity.Property(e => e.DeviceType)
					.IsRequired()
					.HasColumnName("device_type")
					.HasColumnType("character varying");

				entity.Property(e => e.EventType)
					.HasColumnName("event_type")
					.HasColumnType("character varying");

				entity.Property(e => e.Payload)
					.HasColumnName("payload")
					.HasColumnType("json");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

				entity.Property(e => e.Uuid)
					.HasColumnName("uuid")
					.HasColumnType("character varying");

				entity.HasOne(d => d.Company)
					.WithMany(p => p.Clusterdata)
					.HasForeignKey(d => d.CompanyId)
					.HasConstraintName("clusterdata_companies");
			});

			modelBuilder.Entity<Companies>(entity =>
			{
				entity.ToTable("companies");

				entity.HasIndex(e => e.ApiToken)
					.HasName("unique_api_token")
					.IsUnique();

				entity.HasIndex(e => e.Code)
					.HasName("unique_company_code")
					.IsUnique();

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.ApiToken).HasColumnName("api_token");

				entity.Property(e => e.Code).HasColumnName("code");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name")
					.HasColumnType("character varying(500)");
			});

			modelBuilder.Entity<DeploymentTestReports>(entity =>
			{
				entity.ToTable("deployment_test_reports");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.MessageSuccessRate)
					.HasColumnName("message_success_rate")
					.HasColumnType("character varying");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name")
					.HasColumnType("character varying");

				entity.Property(e => e.Results)
					.IsRequired()
					.HasColumnName("results");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<DeviceObservations>(entity =>
			{
				entity.ToTable("device_observations");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.DeviceId)
					.IsRequired()
					.HasColumnName("device_id")
					.HasColumnType("character varying");

				entity.Property(e => e.DeviceType)
					.IsRequired()
					.HasColumnName("device_type")
					.HasColumnType("character varying");

				entity.Property(e => e.Latitude)
					.IsRequired()
					.HasColumnName("latitude")
					.HasColumnType("character varying");

				entity.Property(e => e.Longitude)
					.IsRequired()
					.HasColumnName("longitude")
					.HasColumnType("character varying");

				entity.Property(e => e.ObservationTimestamp).HasColumnName("observation_timestamp");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<Devices>(entity =>
			{
				entity.ToTable("devices");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.AuthToken)
					.IsRequired()
					.HasColumnName("auth_token")
					.HasColumnType("character varying");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.DeviceId)
					.IsRequired()
					.HasColumnName("device_id")
					.HasColumnType("character varying");

				entity.Property(e => e.DeviceType)
					.IsRequired()
					.HasColumnName("device_type")
					.HasColumnType("character varying");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<Incidents>(entity =>
			{
				entity.ToTable("incidents");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Casualties).HasColumnName("casualties");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.Impacted).HasColumnName("impacted");

				entity.Property(e => e.Location)
					.HasColumnName("location")
					.HasColumnType("character varying");

				entity.Property(e => e.Managers)
					.HasColumnName("managers")
					.HasColumnType("character varying");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasColumnType("character varying");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<Messages>(entity =>
			{
				entity.ToTable("messages");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.File)
					.HasColumnName("file")
					.HasColumnType("character varying");

				entity.Property(e => e.Message).HasColumnName("message");

				entity.Property(e => e.Mtype)
					.HasColumnName("mtype")
					.HasColumnType("character varying");

				entity.Property(e => e.Read).HasColumnName("read");

				entity.Property(e => e.Recipient).HasColumnName("recipient");

				entity.Property(e => e.Sender).HasColumnName("sender");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<Notifications>(entity =>
			{
				entity.ToTable("notifications");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Content).HasColumnName("content");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.Title)
					.HasColumnName("title")
					.HasColumnType("character varying");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<Priorities>(entity =>
			{
				entity.ToTable("priorities");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.Details).HasColumnName("details");

				entity.Property(e => e.IncidentId).HasColumnName("incident_id");

				entity.Property(e => e.Level)
					.HasColumnName("level")
					.HasColumnType("character varying");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasColumnType("character varying");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<Resources>(entity =>
			{
				entity.ToTable("resources");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.Location)
					.HasColumnName("location")
					.HasColumnType("character varying");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasColumnType("character varying");

				entity.Property(e => e.Quantity)
					.HasColumnName("quantity")
					.HasColumnType("character varying");

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasColumnType("character varying");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
			});

			modelBuilder.Entity<SchemaMigrations>(entity =>
			{
				entity.HasKey(e => e.Version);

				entity.ToTable("schema_migrations");

				entity.Property(e => e.Version)
					.HasColumnName("version")
					.HasColumnType("character varying")
					.ValueGeneratedNever();
			});

			modelBuilder.Entity<Users>(entity =>
			{
				entity.ToTable("users");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt).HasColumnName("created_at");

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasColumnType("character varying");

				entity.Property(e => e.Incident).HasColumnName("incident");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasColumnType("character varying");

				entity.Property(e => e.PasswordDigest)
					.HasColumnName("password_digest")
					.HasColumnType("character varying");

				entity.Property(e => e.Phone)
					.HasColumnName("phone")
					.HasColumnType("character varying");

				entity.Property(e => e.RememberToken)
					.HasColumnName("remember_token")
					.HasColumnType("character varying");

				entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

				entity.Property(e => e.Username)
					.HasColumnName("username")
					.HasColumnType("character varying");
			});

			modelBuilder.HasSequence("android_debug_messages_id_seq");

			modelBuilder.HasSequence("companies_id_seq");

			modelBuilder.HasSequence("deployment_test_reports_id_seq");

			modelBuilder.HasSequence("device_observations_id_seq");

			modelBuilder.HasSequence("devices_id_seq");
		}
	}
}
