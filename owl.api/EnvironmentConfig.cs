using System;
namespace owl.api
{
	public class EnvironmentConfig
	{
		public string OwlApiDatabaseName { get; set; }
		public int OwlApiDatabasePort { get; set; }
		public string OwlApiDatabaseHost { get; set; }
		public string OwlApiDatabaseUser { get; set; }
		public string OwlApiDatabasePass { get; set; }
		public string OwlApiPgCert { get; set; }
	}
}
