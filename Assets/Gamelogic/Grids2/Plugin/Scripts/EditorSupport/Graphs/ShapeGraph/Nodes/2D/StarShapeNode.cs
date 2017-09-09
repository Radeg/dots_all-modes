namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// Node that generates a star shape.
	/// </summary>
	[ShapeNode("Hex/Star", 2)]
	class StarShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public int radius = 1;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			return ImplicitShape
				.Star(radius)
				.ToExplicit(new GridRect(
					new GridPoint2(-2 * radius, -2 * radius),
					new GridPoint2(4 * radius + 1, 4 * radius + 1)));
		}
	}
}
