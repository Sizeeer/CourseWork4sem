using System.Configuration;

namespace TrackerLibrary.DAL
{
	public static class GlobalConfig
	{
		public static IDataConnection Connection { get; private set; }
		public static void InitializeConnection()
		{
			SqlConnector sql = new SqlConnector();
			Connection = sql;
		}
		public static string CnnString(string name)
		{
			return ConfigurationManager.ConnectionStrings[name].ConnectionString;
		}

		public static string AppKeyLookup(string key)
		{
			return ConfigurationManager.AppSettings[key];	
		}
	}
}
