using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Gamelogic.Grids2.Experimental
{
	public class VertexColors : GridBehaviour<GridPoint2, MeshCell>
	{
		public ColorFunction colorFunction;
		public Color[] colors;

		public override void InitGrid()
		{
			var meshFilter = GetComponent<MeshFilter>();
			var mesh = meshFilter.sharedMesh;
			var vertexCount = mesh.vertices.Length;
			var gridCount = Grid.Points.Count();
			var vertexColors = new List<Color>();
			int colorCount = vertexCount/gridCount;

			foreach (var point in Grid.Points)
			{
				var colorIndex = point.GetColor(colorFunction.x0, colorFunction.x1, colorFunction.y1);

				for(int i = 0; i < colorCount; i++)
				{
					vertexColors.Add(colors[colorIndex]);
				}
			}

			mesh.colors = vertexColors.ToArray();
		}
	}
}