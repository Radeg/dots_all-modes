using UnityEngine;

namespace Gamelogic.Grids2.Graph.Editor
{
	/// <summary>
	/// A graph window for space map graphs.
	/// </summary>
	public class SpaceMapGraphWindow : GraphWindow<SpaceMapNode<Vector3>>
	{
		public static void ShowEditor(Graph<SpaceMapNode<Vector3>> graph)
		{
			ShowEditorImpl<SpaceMapGraphWindow, SpaceMapNodeAttribute>(graph);
		}
	}
}