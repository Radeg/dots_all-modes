using System.Collections.Generic;
using UnityEngine;

namespace Gamelogic.Grids2
{
	/// <summary>
	/// A class that can be used to color a tile grid with a color function.
	/// </summary>
	/// <seealso cref="Gamelogic.Grids2.GridBehaviour{GridPoint2, SpriteCell}" />
	public class GridColors : GridBehaviour<GridPoint2, TileCell>
	{
		public ColorFunction colorFunction;
		public List<Color> colors;

		public override void InitGrid()
		{
			foreach (var point in Grid.Points)
			{
				var colorIndex = point.GetColor(colorFunction.x0, colorFunction.x1, colorFunction.y1);
				var cell = Grid[point];
				var colorable = cell.GetComponent<SpriteCell>();

				colorable.Color = colors[colorIndex];
			}
		}
	}
}