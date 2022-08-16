﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Edublock.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edublock.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }


    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }


    public DbSet<Department> Departments { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<CertificateType> CertificateTypes { get; set; }
    public DbSet<UserUniversityLink> UserUniversityLinks { get; set; }
    public DbSet<UserUniversityDepartmentLink> UserUniversityDepartmentLinks { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<RequestStatus> RequestStatuses { get; set; }
    public DbSet<RequestsLog> RequestsLogs { get; set; }
}
