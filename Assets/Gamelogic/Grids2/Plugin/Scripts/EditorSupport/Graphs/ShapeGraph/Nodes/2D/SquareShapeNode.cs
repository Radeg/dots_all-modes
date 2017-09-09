namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// Node that generates a square shape.
	/// </summary>
	[ShapeNode("Rect/Square", 2)]
	public class SquareShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public int radius;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			return ImplicitShape
				.Square(radius)
				.ToExplicit(new GridRect(
					new GridPoint2(1 - radius, 1 - radius),
					new GridPoint2(2*radius - 1, 2*radius - 1)));
		}
	}
}