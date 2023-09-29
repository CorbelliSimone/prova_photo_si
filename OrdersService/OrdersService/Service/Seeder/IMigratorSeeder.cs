namespace OrdersService.Service.Seeder
{
    public interface IMigratorSeeder
    {
        Task ApplyMigration();
        Task SeedDb();
    }
}
