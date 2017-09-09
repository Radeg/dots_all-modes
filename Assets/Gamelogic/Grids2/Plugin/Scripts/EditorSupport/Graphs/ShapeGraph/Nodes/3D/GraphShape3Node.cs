namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("Graph/Graph", 3)]
	public class GraphShape3Node : PrimitiveShapeNode<GridPoint3>
	{
		public Shape3Graph graph;

		protected override IExplicitShape<GridPoint3> Generate()
		{
			return graph.GetShape();
		}
	}
}