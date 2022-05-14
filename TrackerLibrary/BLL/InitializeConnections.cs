using TrackerLibrary.DAL;

namespace TrackerLibrary.BLL
{
	public class InitializeConnections
	{
		public void InitializeConnection()
		{
			GlobalConfig.InitializeConnection(DatabaseType.Sql);
		}
	}
}
