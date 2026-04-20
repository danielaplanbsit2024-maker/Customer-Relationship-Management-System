namespace Customer_Relationship_Management
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set the data directory to a stable location in AppData
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbFolder = Path.Combine(appData, "BigBrewCRM");
            
            if (!Directory.Exists(dbFolder)) 
            {
                Directory.CreateDirectory(dbFolder);
            }

            // During development, if the DB isn't in AppData yet, we can copy it from the project
            string dbFile = "Database.mdf";
            string logFile = "Database_log.ldf";
            string destDbPath = Path.Combine(dbFolder, dbFile);

            if (!File.Exists(destDbPath))
            {
                // Try to find the source DB in the project structure
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string projectDir = Path.GetFullPath(Path.Combine(baseDir, @"..\..\.."));
                string sourceDbPath = Path.Combine(projectDir, dbFile);
                string sourceLogPath = Path.Combine(projectDir, logFile);

                if (File.Exists(sourceDbPath))
                {
                    try 
                    {
                        File.Copy(sourceDbPath, destDbPath);
                        if (File.Exists(sourceLogPath))
                        {
                            File.Copy(sourceLogPath, Path.Combine(dbFolder, logFile));
                        }
                    }
                    catch { /* Fallback to local if copy fails */ }
                }
            }

            AppDomain.CurrentDomain.SetData("DataDirectory", dbFolder);

            // Ensure database schema is up to date at startup
            DBconnection.EnsureSchemaUpdated();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}