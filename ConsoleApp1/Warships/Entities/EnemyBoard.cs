using System.Collections.Generic;

namespace Warships.Entities
{
	public class EnemyBoard : IBoard
	{
		public IList<Ship> Ships { get; set; } = new List<Ship>();
	}
}