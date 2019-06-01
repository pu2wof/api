using System;
namespace owl.api.Models
{
	public partial class DeploymentTestReports
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Results { get; set; }
		public string MessageSuccessRate { get; set; }
	}
}
