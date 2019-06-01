using System;
namespace owl.api.Models
{
	public partial class AndroidDebugMessages
	{
		public long Id { get; set; }
		public string Payload { get; set; }
		public string Uuid { get; set; }
		public string FromDeviceId { get; set; }
		public string FromDeviceType { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
