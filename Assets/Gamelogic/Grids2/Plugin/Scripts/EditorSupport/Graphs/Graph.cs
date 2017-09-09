using System;
using System.Collections.Generic;
using Gamelogic.Extensions.Internal;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// A class the represents a computational graph. 
	/// </summary>
	/// <remarks>This is the non-generic base class, see <see cref="Graph{TNode}"/> for details.</remarks>
	public class Graph : ScriptableObject
	{ }

	/// <summary>
	/// A class the represents a computational graph.
	/// </summary>
	/// <typeparam name="TNode">The node type for this graph.</typeparam>
	/// <seealso cref="Gamelogic.Grids2.Graph.Graph" />
	/// <remarks>Each node in this graph takes some inputs, and calculates outputs,
	/// that can in turn be fed as inputs into other nodes.
	/// All nodes produces outputs as lists. When a node has multiple inputs,
	/// these are all combined into a single list for the node to operate on.
	/// The output of one node can only be connected to the input of another node if the types match.</remarks>
	[Version(1,1)]
	public  class Graph<TNode> : Graph
		where TNode : BaseNode
	{
		#region Private Fields
		[HideInInspector]
		[SerializeField]
		private int idCounter;

		[HideInInspector]
		[SerializeField] 
// ReSharper disable once FieldCanBeMadeReadOnly.Local
// Cannot be readonly because it is serialized.
		private List<BaseNode> nodes = new List<BaseNode>();
		#endregion

		#region Properties
		
		/// <summary>
		/// Returns all the nodes in this graph.
		/// </summary>
		public List<BaseNode> Nodes
		{
			get { return nodes; }
		}
		#endregion

		#region Public Methods
#if UNITY_EDITOR

		///  <summary>
		///  Creates and adds a new unlinked node to the graph.
		///  </summary>
		///  <typeparam name="T">The type of the node to add.</typeparam>
		/// <param name="initialPosition">The initial position the node will be displayed
		///     in the visual representation.</param>
		/// <returns>The newly created node.</returns>
		public TNode AddNode(Type nodeType, Vector2 initialPosition, string name) 
		{
			var node = (TNode) CreateInstance(nodeType);

			node.id = idCounter;
			//node.name = "(" + idCounter + ") " + node.GetType().Name;
			node.name = name;
			node.rect = new Rect(initialPosition.x, initialPosition.y, node.rect.width, node.rect.height);

			nodes.Add(node);
			idCounter++;
		
			AssetDatabase.AddObjectToAsset(node, this);
			AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(node));
		
			EditorUtility.SetDirty(this);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

			return node;
		}

		/// <summary>
		/// Unlinks this node from other nodes, destroys it, and removes it from the graph.
		/// </summary>
		/// <param name="node">The node to remove.</param>
		public void RemoveNode(TNode node)
		{
			nodes.Remove(node);

			foreach (var node1 in nodes)
			{
				node1.RemoveNodeInput(node);
			}

			var path = AssetDatabase.GetAssetOrScenePath(node);
			DestroyImmediate(node, true);

			AssetDatabase.ImportAsset(path);
			AssetDatabase.SaveAssets();
			EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// Removes all nodes from this graph.
		/// </summary>
		public void Clear()
		{
			foreach (var node in nodes)
			{
				DestroyImmediate(node, true);
			}

			nodes.Clear();

			var path = AssetDatabase.GetAssetOrScenePath(this);

			AssetDatabase.ImportAsset(path);
			AssetDatabase.SaveAssets();
			EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// Save the asset database.
		/// </summary>
		public void Save()
		{
			AssetDatabase.SaveAssets();
		}
#endif

		/// <summary>
		/// Calls recompute on all nodes in the graph.
		/// </summary>
		public void Recompute()
		{
			foreach (var node in nodes)
			{
				node.Recompute();
			}

			foreach (var node in nodes)
			{
				node.UpdateStatic();
			}
		}
		#endregion
	}
}
