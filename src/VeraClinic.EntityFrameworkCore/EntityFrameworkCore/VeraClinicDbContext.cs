using Microsoft.EntityFrameworkCore;
using VeraClinic.Patients; // Patient ve TriageCode için gerekli
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace VeraClinic.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class VeraClinicDbContext :
    AbpDbContext<VeraClinicDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* SmartClinic - Hasta Takip Sistemi Entities */
    public DbSet<Patient> Patients { get; set; }

    #region Entities from the modules

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public VeraClinicDbContext(DbContextOptions<VeraClinicDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        /* SmartClinic: Patient (Hasta) Tablosu Yapılandırması */

        builder.Entity<Patient>(b =>
        {
            // Tablo ismi: AppPatients
            b.ToTable(VeraClinicConsts.DbTablePrefix + "Patients", VeraClinicConsts.DbSchema);
            b.ConfigureByConvention(); 

            // Alan kısıtlamaları
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.Surname).IsRequired().HasMaxLength(128);
            b.Property(x => x.IdentityNumber).IsRequired().HasMaxLength(11);
            b.Property(x => x.Complaint).HasMaxLength(500);
            

            // Triyaj kodu için varsayılan değer (None)
            b.Property(x => x.CurrentTriageStatus).HasDefaultValue(TriageCode.None);

            // Indexleme (Hızlı arama için)
            b.HasIndex(x => x.IdentityNumber);
        });
    }
}