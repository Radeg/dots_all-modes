using UnityEngine;

namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// Node that generates a up triangle shape.
	/// </summary>
	[ShapeNode("Hex/Up Triangle", 2)]
	class UpTriangleShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public float radius = 1;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			int iRadius = Mathf.CeilToInt(radius);

            return ImplicitShape
				.UpTriangle(radius)
				.ToExplicit(new GridRect(
				new GridPoint2(1 - iRadius, 1 - iRadius),
				new GridPoint2(3 * iRadius - 2, 3 * iRadius - 2)));
		}
	}
}
