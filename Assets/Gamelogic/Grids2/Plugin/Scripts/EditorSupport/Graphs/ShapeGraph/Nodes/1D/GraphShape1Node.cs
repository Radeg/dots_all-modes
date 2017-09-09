namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("Graph/Graph", 1)]
	public class GraphShape1Node : PrimitiveShapeNode<int>
	{
		public Shape1Graph graph;

		protected override IExplicitShape<int> Generate()
		{
			return graph.GetShape();
		}
	}
}