using System;
using System.Collections.Generic;
using System.Text;

namespace Warships.Entities
{
	public class User : BaseEntity
	{
		public string Login { get; set; }
		public int WinCount { get; set; }
		public int LoseCount { get; set; }
	}
}
