using System;
using System.Collections.Generic;

namespace ToTheMasjid
{
	public class Mosque
	{
		public int id { get; set; }
		public string name { get; set; }
		public string category { get; set; }
		public int Latitude { get; set; }
		public int Longitude { get; set; }
		public DateTime FajrTime { get; set; }
		public DateTime DhuhrTime { get; set; }
		public DateTime AsrTime { get; set; }
		public DateTime MaghrebTime { get; set; }
		public DateTime IshaTime { get; set; }
		public DateTime Jummah1Time { get; set; }
		public DateTime Jummah2Time { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string Facebook { get; set; }
		public string Website { get; set; }
	}

	public class Mosques
	{
		public string type { get; set; }
		public IList<Mosque> value { get; set; }
	}
}
