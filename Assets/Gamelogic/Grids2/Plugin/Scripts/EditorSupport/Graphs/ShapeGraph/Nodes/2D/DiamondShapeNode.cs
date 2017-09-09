namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// Node that generates a (rect) diamond shape.
	/// </summary>
	[ShapeNode("Rect/Diamond", 2)]
	class DiamondShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public int radius = 1;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			return ImplicitShape
				.RectDiamond(radius)
				.ToExplicit(new GridRect(
					new GridPoint2(1 - radius, 1 - radius),
					new GridPoint2(2 * radius - 1, 2 * radius - 1)));
		}
	}
}
