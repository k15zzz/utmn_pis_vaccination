using PIS_Vaccination_PI_21_03.Source.Models;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models.EntitiesModels;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class AppDbContext : DbContext
{
    public DbSet<LogEntitiesModel> Loggings { get; set; } = null!;
    public DbSet<AnimalCategoryEntitiesModel> AnimalCategory { get; set; } = null!;
    public DbSet<AnimalStatusEntitiesModel> AnimalStatus { get; set; } = null!;
    public DbSet<AnimalEntitiesModel> Animals { get; set; } = null!;
    public DbSet<ContractEntitiesModel> Contracts { get; set; } = null!;
    public DbSet<OrganizationEntitiesModel> Organizations { get; set; } = null!;
    public DbSet<RoleEntitiesModel> Roles { get; set; } = null!; 
    public DbSet<TownEntitiesModel> Towns { get; set; } = null!;
    public DbSet<TownsServiceEntitiesModels> TownsServices { get; set; } = null!;
    public DbSet<UserEntitiesModels> Users { get; set; } = null!;
    public DbSet<VaccinationEntitiesModel> Vaccinations { get; set; } = null!;
    public DbSet<StatusStatisticEntitiesModel> StatisticStatus { get; set; } = null!;
    public DbSet<StatisticTownEntitiesModel> StatisticTowns { get; set; } = null!;
    public DbSet<StatisticEntitiesModel> Statistics { get; set; } = null!;
    public DbSet<RoleStatusStatisticEntitiesMode> RoleStatusStatistic { get; set; } = null!;
    
 
    public AppDbContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=db;Port=5432;Database=vaccination;Username=root;Password=root");
    }
}