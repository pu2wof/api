using System;
using System.Collections.Generic;

namespace owl.api.Models
{
	public partial class Companies
	{
		public Companies()
		{
			Clusterdata = new HashSet<Clusterdata>();
		}

		public long Id { get; set; }
		public string Name { get; set; }
		public Guid Code { get; set; }
		public Guid? ApiToken { get; set; }

		public ICollection<Clusterdata> Clusterdata { get; set; }
	}
}
