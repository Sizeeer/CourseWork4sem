
using System.Configuration;

namespace TrackerLibrary.DAL
{
	public static class GlobalConfig
	{
		// Create a constance variable to keep it doesn't change
		public const string PrizesFile = "PrizeModels.csv";
		public const string PeopleFile = "PeopleModels.csv";
		public const string TeamFile = "TeamModels.csv";
		public const string TournamentFile = "TournamentModels.csv";
		public const string MatchupFile = "Matchups.csv";
		public const string MatchupEntryFile = "MatchupEntry.csv";

		// List of IDataConnections, use the list to add sql or text
		public static IDataConnection Connection { get; private set; } 

		// Initialize the connection with sql connection or text file connection
		public static void InitializeConnection(DatabaseType db)
		{
			if(db == DatabaseType.Sql)
			{
				// TODO - Create SQL connection
				SqlConnector sql = new SqlConnector();
				Connection = sql;
			}
			else if(db == DatabaseType.TextFiles)
			{
				// TODO - Create text file connection
				TextConnector text = new TextConnector();
				Connection = text;
			}
		}

		// return connection string from app.config in UIL
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
