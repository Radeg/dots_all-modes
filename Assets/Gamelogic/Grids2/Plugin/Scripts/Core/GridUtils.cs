using UnityEngine;
using System.Linq;
using Gamelogic.Extensions;

namespace Gamelogic.Grids2
{
	/// <summary>
	/// Class with utlity methods for grids.
	/// </summary>
	public static class GridUtils
	{
		public static Grid2<float> ImageToGreyScaleGrid(Texture2D texture)
		{
			var dimensions = new GridPoint2(texture.width, texture.height);
			var storageRect = new GridRect(GridPoint2.Zero, dimensions);
			var implicitShape = ImplicitShape.Parallelogram(dimensions);
			var explicitShape = implicitShape.ToExplicit(storageRect);

			var grid = new Grid2<float>(explicitShape);
			var textureData = texture.GetPixels().Select(c => c.grayscale).ToArray();

			var randomX = GLRandom.Range(0, texture.width);
			var randomY = GLRandom.Range(0, texture.height);

			grid.Fill(p => textureData[(p.X + randomX) % texture.width + (texture.width * ((p.Y + randomY) % texture.height))]);

			return grid;
		}
	}
}