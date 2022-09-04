using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Contexts
{
	public class BaseDbContext:DbContext
	{
		protected IConfiguration Configuration { get; set; }
		public DbSet<SoftwareProgrammingLanguage> SoftwareProgrammingLanguages{ get; set; }
		public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
		{
			Configuration = configuration;

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SoftwareProgrammingLanguage>(a =>
			{
				a.ToTable("SoftwareProgrammingLanguages").HasKey(k => k.Id);
				a.Property(p=>p.Id).HasColumnName("Id");
				a.Property(p=>p.Name).HasColumnName("Name");


			});

			SoftwareProgrammingLanguage[] softwareProgrammingLanguageEntitySeeds =
			{
				new(1,"C#"),
				new(2,"Java"),
				new(3,"Java"),
			};

			modelBuilder.Entity<SoftwareProgrammingLanguage>().HasData(softwareProgrammingLanguageEntitySeeds);

		}

	}
}
