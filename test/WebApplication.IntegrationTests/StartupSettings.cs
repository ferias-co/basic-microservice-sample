namespace WebApplication.IntegrationTests
{
    public static class StartupSettings
    {
        public static void Environment()
        {
            System.Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Sandbox");
            System.Environment.SetEnvironmentVariable("CONNECTION_STRING", "mongodb://localhost:27017");
            System.Environment.SetEnvironmentVariable("SUPPLIER_DATABASE", "suppliers");
            System.Environment.SetEnvironmentVariable("SUPPLIER_REPOSITORY", "suppliers");
        }
    }
}
