using System;
using System.Collections.Generic;
using System.Text;

namespace Warships.Entities
{
	interface IBoard
	{
		public IList<Ship> Ships { get; set; };
	}
}
