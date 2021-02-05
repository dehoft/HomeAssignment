namespace TesonetHomeAssignment.DB
{
    public static class ConnectionName
    {
        public static string connectionName = "Playground";

        public static (string, bool) Connect(string settingsConnectionName = null)
        {
            if (!string.IsNullOrEmpty(settingsConnectionName)) connectionName = settingsConnectionName;
            return Database.GetSqlConnection(connectionName);
        }
    }
}
