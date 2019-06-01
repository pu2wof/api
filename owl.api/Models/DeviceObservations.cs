using System;
namespace owl.api.Models
{
	public partial class DeviceObservations
	{
		public long Id { get; set; }
		public string DeviceId { get; set; }
		public string DeviceType { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? ObservationTimestamp { get; set; }
	}
}
