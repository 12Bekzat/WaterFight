using System.Collections.Generic;

namespace Warships.Entities
{
	public class MyBoard : IBoard
	{
		public IList<Ship> Ships { get; set; } = new List<Ship>();
	}
}