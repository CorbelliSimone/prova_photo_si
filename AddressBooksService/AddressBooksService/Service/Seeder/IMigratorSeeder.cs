namespace AddressBooksService.Service.Seeder
{
    public interface IMigratorSeeder
    {
        Task ApplyMigration();
        Task SeedDb();
    }
}
