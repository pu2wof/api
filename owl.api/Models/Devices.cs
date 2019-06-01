using System;
namespace owl.api.Models
{
	public partial class Devices
	{
		public long Id { get; set; }
		public string DeviceType { get; set; }
		public string DeviceId { get; set; }
		public string AuthToken { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
