using Core.Security.Entities;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Contexts
{
	public class BaseDbContext:DbContext
	{
		protected IConfiguration Configuration { get; set; }
		public DbSet<SoftwareProgrammingLanguage> SoftwareProgrammingLanguages{ get; set; }

		public DbSet<Technology>technologies{ get; set; }

		public DbSet<Website> websites  { get; set; }

		public DbSet<User> users { get; set; }
		public DbSet<UserOperationClaim> userOperationClaims { get; set; }
		public DbSet<OperationClaim> operationClaims { get; set; }







		public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
		{
			Configuration = configuration;

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//SoftwareProgrammingLanguages Db Model
			modelBuilder.Entity<SoftwareProgrammingLanguage>(a =>
			{
				a.ToTable("SoftwareProgrammingLanguages").HasKey(k => k.Id);
				a.Property(p=>p.Id).HasColumnName("Id");
				a.Property(p=>p.Name).HasColumnName("Name");


			});


			//Technology Db Model
			modelBuilder.Entity<Technology>(a =>
			{
				a.ToTable("Technologies").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.Name).HasColumnName("Name");
				a.Property(p => p.SPLId).HasColumnName("SPLId");
				a.HasOne(p => p.SoftwareProgrammingLanguage);

			});

			//User Db Model

			modelBuilder.Entity<User>(a =>
			{
				a.ToTable("Users").HasKey(p=>p.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.FirstName).HasColumnName("FirstName");
				a.Property(p => p.LastName).HasColumnName("LastName");
				a.Property(p => p.Email).HasColumnName("Email");
				a.Property(p=>p.PasswordSalt).HasColumnName("PasswordSalt");
				a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
				a.Property(p => p.Status).HasColumnName("Status");
				a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

				a.HasMany(c => c.UserOperationClaims);
				a.HasMany(c=>c.RefreshTokens);

			});


			//OperationClaims Db Model
			modelBuilder.Entity<OperationClaim>(a =>
			{
				a.ToTable("OperationClaims").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(c => c.Name).HasColumnName("Name");

			});

			//UserOperationClaims Db Model

			modelBuilder.Entity<UserOperationClaim>(a =>
			{
				a.ToTable("userOperationClaims").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(c=>c.UserId).HasColumnName("UserId");
				a.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId");

				a.HasOne(c => c.OperationClaim);
				a.HasOne(c => c.User);
			});

			//Website Db Model
			modelBuilder.Entity<Website>(a =>
			{
				a.ToTable("Websites").HasKey(k => k.Id);
				a.Property(p=>p.Id).HasColumnName("Id");
				a.Property(c => c.Url).HasColumnName("Url");

				a.HasOne(c => c.User);



			});





			//SoftwareProgrammingLanguage[] softwareProgrammingLanguageEntitySeeds =
			//{
			//	new(1,"C#"),
			//	new(2,"Java"),
			//	new(3,"Java"),
			//};

			//modelBuilder.Entity<SoftwareProgrammingLanguage>().HasData(softwareProgrammingLanguageEntitySeeds);

		}

	}
}
