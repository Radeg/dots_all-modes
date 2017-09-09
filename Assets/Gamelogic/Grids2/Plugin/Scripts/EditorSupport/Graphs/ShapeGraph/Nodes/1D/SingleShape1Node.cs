namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// Represents a single point.
	/// </summary>
	[ShapeNode("All/Single", 1)]
	public class SingleShape1Node : PrimitiveShapeNode<int>
	{
		protected override IExplicitShape<int> Generate()
		{
			return ImplicitShape
				.Single1()
				.ToExplicit(new GridInterval(0, 1));
		}
	}
}