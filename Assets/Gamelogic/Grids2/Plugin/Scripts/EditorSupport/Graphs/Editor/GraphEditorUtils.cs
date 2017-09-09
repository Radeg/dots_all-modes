using UnityEngine;
using UnityEditor;

namespace Gamelogic.Grids2.Graph.Editor
{
	/// <summary>
	/// Contains methods for menu commands.
	/// </summary>
	public class GraphEditorUtils
	{
		/// <summary>
		/// Brings up a save file dialog that allows the user to specify a location to 
		/// save a new graph, makes a new graph, and saves it to the specified 
		/// location.
		/// </summary>
		public static void MakeNewGraph<TGraph>(string defaultName, string subExtension) where TGraph : ScriptableObject
		{
			var graph = ScriptableObject.CreateInstance<TGraph>();

			var path = Selection.activeObject == null ? null : AssetDatabase.GetAssetPath(Selection.activeObject);

			if(string.IsNullOrEmpty(path))
			{
				path = EditorUtility.SaveFilePanel(
					"Create new Graph",
					"Assets",
					defaultName + "." + subExtension + ".asset",
					"asset");

				if (string.IsNullOrEmpty(path))
				{
					return;
				}

				path = "Assets" + path.Substring(Application.dataPath.Length);

			}
			else
			{
				path += "/" + defaultName + "." + subExtension + ".asset";
			}

			if (path != "")
			{

				Debug.Log(path);

				AssetDatabase.CreateAsset(graph, path);
				AssetDatabase.SaveAssets();
			}
		}

		[MenuItem("Assets/Create/Grids/Space Map Graph")]
		public static void MakeNewSpaceMapGraph()
		{
			MakeNewGraph<SpaceMapGraph>("MapGraph", "spacemapgraph");
		}

		[MenuItem("Assets/Create/Grids/Shape Graph (1D)")]
		public static void MakeNewShape1Graph()
		{
			MakeNewGraph<Shape1Graph>("ShapeGraph", "shape1graph");
		}

		[MenuItem("Assets/Create/Grids/Shape Graph (2D)")]
		public static void MakeNewShape2Graph()
		{
			MakeNewGraph<Shape2Graph>("ShapeGraph", "shape2graph");
		}

		[MenuItem("Assets/Create/Grids/Shape Graph (3D)")]
		public static void MakeNewShape3Graph()
		{
			MakeNewGraph<Shape3Graph>("ShapeGraph", "shape3graph");
		}

		[MenuItem("Assets/Create/Grids/Uniform Grid Mesh Data")]
		public static void MakeUniformGridMeshData()
		{
			var graph = ScriptableObject.CreateInstance<UniformGridMeshData>();

			var path = Selection.activeObject == null ? null : AssetDatabase.GetAssetPath(Selection.activeObject);

			const string defaultName = "MeshData";
			const string subExtension = "meshdata";

			if (string.IsNullOrEmpty(path))
			{
				path = EditorUtility.SaveFilePanel(
					"Create new MeshData",
					"Assets",
					defaultName + "." + subExtension + ".asset",
					"asset");

				if (string.IsNullOrEmpty(path))
				{
					return;
				}

				path = "Assets" + path.Substring(Application.dataPath.Length);

			}
			else
			{
				path += "/" + defaultName + "." + subExtension + ".asset";
			}

			if (path != "")
			{
				path = "Assets" + path.Substring(Application.dataPath.Length);

				AssetDatabase.CreateAsset(graph, path);
				AssetDatabase.SaveAssets();
			}
		}

		[MenuItem("Assets/Create/Grids/New Periodic Grid Mesh Data")]
		public static void MakePeriodicGridMeshData()
		{
			var graph = ScriptableObject.CreateInstance<PeriodicGridMeshData>();

			var path = Selection.activeObject == null ? null : AssetDatabase.GetAssetPath(Selection.activeObject);

			const string defaultName = "MeshData";
			const string subExtension = "meshdata";

			if (string.IsNullOrEmpty(path))
			{
				path = EditorUtility.SaveFilePanel(
					"Create new MeshData",
					"Assets",
					defaultName + "." + subExtension + ".asset",
					"asset");

				if (string.IsNullOrEmpty(path))
				{
					return;
				}

				path = "Assets" + path.Substring(Application.dataPath.Length);

			}
			else
			{
				path += "/" + defaultName + "." + subExtension + ".asset";
			}

			if (path != "")
			{
				path = "Assets" + path.Substring(Application.dataPath.Length);

				AssetDatabase.CreateAsset(graph, path);
				AssetDatabase.SaveAssets();
			}
		}
	}
}