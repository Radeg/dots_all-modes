namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("Graph/Graph", 2)]
	public class GraphShape2Node : PrimitiveShapeNode<GridPoint2>
	{
		public Shape2Graph graph;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			return graph.GetShape();
		}
	}
}