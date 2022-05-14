using TrackerLibrary.DAL;

namespace TrackerLibrary.BUL
{
	public class InitializeConnections
	{
		// Call the method initializeConnection in GlobalConfig file
		public void InitializeConnection()
		{
			GlobalConfig.InitializeConnection(DatabaseType.Sql);
		}
	}
}
