using System.Configuration;

namespace TrackerLibrary.DAL
{
	public static class GlobalConfig
	{
		public const string PrizesFile = "PrizeModels.csv";
		public const string PeopleFile = "PeopleModels.csv";
		public const string TeamFile = "TeamModels.csv";
		public const string TournamentFile = "TournamentModels.csv";
		public const string MatchupFile = "Matchups.csv";
		public const string MatchupEntryFile = "MatchupEntry.csv";
		public static IDataConnection Connection { get; private set; }
		public static void InitializeConnection(DatabaseType db)
		{
			if(db == DatabaseType.Sql)
			{
				SqlConnector sql = new SqlConnector();
				Connection = sql;
			}
			else if(db == DatabaseType.TextFiles)
			{
				TextConnector text = new TextConnector();
				Connection = text;
			}
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
