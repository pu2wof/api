using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace owl.api.Models
{
	public partial class Clusterdata
	{
		public long Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string EventType { get; set; }
		public string Payload { get; set; }
		public string DeviceId { get; set; }
		public string Uuid { get; set; }
		public string DeviceType { get; set; }

		[JsonIgnore]
		public long? CompanyId { get; set; }

		[JsonIgnore]
		public Companies Company { get; set; }
	}
}
