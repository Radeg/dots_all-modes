using System;
using UnityEngine.Events;

namespace Gamelogic.Grids2
{
	[Serializable]
	public class GridEvent : UnityEvent<GridPoint2>
	{
	}
}