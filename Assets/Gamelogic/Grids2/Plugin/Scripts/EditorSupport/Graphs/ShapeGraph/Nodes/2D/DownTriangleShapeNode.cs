using UnityEngine;

namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// Node that generates a down triangle shape.
	/// </summary>
	[ShapeNode("Hex/Down Triangle", 2)]
	class DownTriangleShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public float radius = 1;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			int iRadius = Mathf.CeilToInt(radius);

			return ImplicitShape
				.DownTriangle(radius).ToExplicit(new GridRect(
					new GridPoint2(2 - 2 * iRadius, 2 - 2 * iRadius),
					new GridPoint2(3 * iRadius - 2, 3 * iRadius - 2)));
			
		}
	}
}
