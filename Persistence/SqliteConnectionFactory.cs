using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace Persistence
{
	public class SqliteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection()
		{
			//String connectionString = ConfigurationManager.AppSettings["DataBase"];
			String connectionString = 
				"Data Source=C:\\Users\\MSI\\Desktop\\Informatica\\Anul II\\MPP\\C#\\Proiect_MPP_GUI_Client_Server\\concurs_inot2.db;Version=3;";
			//return new SQLiteConnection(connectionString);
			var conn = new SQLiteConnection(connectionString);
			return conn;
		}
	}
}
