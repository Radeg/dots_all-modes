namespace Gamelogic.Grids2.Graph.Editor
{
	/// <summary>
	/// A graph window for editing 2D shape graphs.
	/// </summary>
	/// <seealso cref="GraphWindow{ShapeNode{GridPoint2}}" />
	public class Shape2GraphWindow : GraphWindow<ShapeNode<GridPoint2>>
	{
		public static void ShowEditor(Graph<ShapeNode<GridPoint2>> graph)
		{
			ShowEditorImpl<Shape2GraphWindow, ShapeNodeAttribute>(graph);
		}
	}
}