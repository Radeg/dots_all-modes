namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("Operator/Reflect X in bounds", 2)]
	public class Reflect2XShapeNode : ProjectShapeNode<GridPoint2, IExplicitShape<GridPoint2>, IExplicitShape<GridPoint2>>
	{
		public override IExplicitShape<GridPoint2> Transform(IExplicitShape<GridPoint2> input)
		{
			return input.ReflectXInBounds();
		}
	}
}