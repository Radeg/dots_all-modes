using System;

namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// Class for selecting the grid type and setting an associated graph.
	/// </summary>
	/// <remarks>Only one of the graphs is used depending on the value of <c>gridType</c>.</remarks>
	[Serializable]
	public class GridShapeGraph
	{
		public GridType gridType;

		public Shape1Graph shape1Graph;
		public Shape2Graph shape2Graph;
		public Shape3Graph shape3Graph;
	}
}