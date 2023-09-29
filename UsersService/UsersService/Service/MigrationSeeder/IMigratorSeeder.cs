namespace UsersService.Service.MigrationSeeder
{
    public interface IMigratorSeeder
    {
        Task ApplyMigration();
        Task Seed();
    }
}
