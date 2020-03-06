using System;
using System.Collections.Generic;
using System.Text;
using Warships.Entities;

namespace Warships.Interfaces
{
	public interface IGameRepository
	{
		public IList<Ship> Ships { get; set; } 
		//public User Player { get; set; }
	}
}
