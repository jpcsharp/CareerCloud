using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext:DbContext
    {
        public CareerCloudContext(DbContextOptions<CareerCloudContext> options)
        : base(options)
        {
        }
        public DbSet<CompanyLocationPoco> companyLocations { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountry { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        
        
        private readonly string _connectionString;
        public CareerCloudContext(string connectionstring)
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            this._connectionString = connectionstring;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<SystemCountryCodePoco>().HasMany(e => e.ApplicantWorkHistorys).WithOne(e => e.SystemCountryCodeS).HasForeignKey(e => e.CountryCode);
            modelBuilder.Entity<SystemCountryCodePoco>().HasMany(e => e.CompanyLocations).WithOne(e => e.SystemCountryCodeS).HasForeignKey(e => e.CountryCode);

            modelBuilder.Entity<SystemCountryCodePoco>()
            .HasMany(s => s.ApplicantProfiles) 
            .WithOne(a => a.SystemCountryCodeS)
            .HasForeignKey(a => a.Country);
            
            modelBuilder.Entity<SystemLanguageCodePoco>()
            .HasMany(s => s.CompanyDescriptions) 
            .WithOne(a => a.SystemLanguageCodes)
            .HasForeignKey(a => a.LanguageId);



            // modelBuilder.Entity<ApplicantProfilePoco>()
            //.HasMany(s => s.SystemCountryCode) 
            //.WithOne(a => a.ApplicantProfilePoco)
            //.HasForeignKey(a => a.Code);

            //modelBuilder.Entity<CompanyProfilePoco>().Ignore(e => e.comp);


            // modelBuilder.Entity<ApplicantProfilePoco>().Ignore(e => e.SystemCountryCode);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().Ignore(e => e.SystemCountryCode);
            modelBuilder.Entity<CompanyDescriptionPoco>().Ignore(e => e.LanguageId);
            modelBuilder.Entity<CompanyProfilePoco>().Ignore(e => e.CompanyDescription);
            modelBuilder.Entity<CompanyJobPoco>().Ignore(e => e.CompanyProfile);
            modelBuilder.Entity<ApplicantJobApplicationPoco>().Ignore(e => e.Applicant);
          
            modelBuilder.Entity<CompanyJobPoco>().Ignore(e => e.ApplicantJobApplication);
            modelBuilder.Entity<ApplicantProfilePoco>().Ignore(e => e.ApplicantJobApplication);


            //modelBuilder.Entity<CompanyJobPoco>()
            //    .HasOne(c => c.CompanyProfiles)
            //    .WithMany(p => p.CompanyJobs)
            //    .HasForeignKey(c => c.Company)
            //    .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<ApplicantProfilePoco>().HasMany(e => e.ApplicantEducations).WithOne(e => e.ApplicantProfiles).HasForeignKey(e => e.Applicant);
            modelBuilder.Entity<ApplicantEducationPoco>().HasMany(e => e.ApplicantProfile).WithOne(e => e.ApplicantEducation).HasForeignKey(e => e.Id);
            modelBuilder.Entity<CompanyJobPoco>().HasMany(e => e.ApplicantJobApplications).WithOne(e => e.CompanyJobs).HasForeignKey(e => e.Applicant);
            modelBuilder.Entity<ApplicantJobApplicationPoco>().Property(e=>e.Job);
            modelBuilder.Entity<SecurityLoginPoco>().Ignore(e=>e.ApplicantProfiles);
            base.OnModelCreating(modelBuilder);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).AddJsonFile("appsettings.json");
            void ConfigureServices(IServiceCollection services) => services.AddDbContext<CareerCloudContext>();
           string connectionstring="";
            if (!optionsBuilder.IsConfigured)
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                //var connectionString = configuration.GetConnectionString("DataConnection");
                optionsBuilder.UseSqlServer(_connectionString);

            }
        }
        
        
    }
}