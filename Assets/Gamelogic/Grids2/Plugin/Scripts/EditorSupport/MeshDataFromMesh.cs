/*using System.Collections.Generic;
using System.Linq;
using Gamelogic.Extensions.Internal;
using UnityEditor;
using UnityEngine;

namespace Gamelogic.Grids2.Examples
{
	[Version(2, 3)]
	public class MeshDataFromMesh : MeshData
	{
		public Mesh mesh;
		public float scale;

		private bool flipped;

		public override IEnumerable<Vector3> GetVertices(IExplicitShape<int> shape, GridMap<int> map)
		{
			return shape.Points.SelectMany(p => mesh.vertices.Select(q => map.GridToWorld(q + scale * map.DeRound(p))));
		}

		public override IEnumerable<Vector3> GetVertices(IExplicitShape<GridPoint2> shape, GridMap<GridPoint2> map)
		{
			return shape.Points.SelectMany(p => mesh.vertices.Select(q => map.GridToWorld(q + scale * map.DeRound(p))));
		}

		public override IEnumerable<Vector3> GetVertices(IExplicitShape<GridPoint3> shape, GridMap<GridPoint3> map)
		{
			return shape.Points.SelectMany(p => mesh.vertices.Select(q => map.GridToWorld(q + scale * map.DeRound(p))));
		}

		//TODO doubleSided
		public override IEnumerable<int> GetTriangles(IExplicitShape<int> shape, bool doubleSided, bool flip)
		{
			if (doubleSided) return null;

			if (flip) return GetTrianglesFlipped(shape);

			return GetTrianglesNormal(shape);

		}

		private IEnumerable<int> GetTrianglesNormal(IExplicitShape<int> shape)
		{
			return shape.Points.SelectMany((p, i) => mesh.triangles.Select(t => t + i * mesh.vertices.Length));
		}

		private IEnumerable<int> GetTrianglesFlipped(IExplicitShape<int> shape)
		{
			var triangles = mesh.triangles;

			var flippedTriangles = new int[triangles.Length];

			for (int i = 0; i < triangles.Length; i += 3)
			{
				flippedTriangles[i] = triangles[i + 1];
				flippedTriangles[i + 1] = triangles[i];
				flippedTriangles[i + 2] = triangles[i + 2];
			}

			return shape.Points.SelectMany((p, i) => flippedTriangles.Select(t => t + i * mesh.vertices.Length));
		}

		public override IEnumerable<int> GetTriangles(IExplicitShape<GridPoint2> shape, bool doubleSided, bool flip)
		{
			if (doubleSided) return null;

			if (flip) return GetTrianglesFlipped(shape);

			return GetTrianglesNormal(shape);

		}

		private IEnumerable<int> GetTrianglesNormal(IExplicitShape<GridPoint2> shape)
		{
			return shape.Points.SelectMany((p, i) => mesh.triangles.Select(t => t + i * mesh.vertices.Length));
		}

		private IEnumerable<int> GetTrianglesFlipped(IExplicitShape<GridPoint2> shape)
		{
			var triangles = mesh.triangles;

			var flippedTriangles = new int[triangles.Length];

			for (int i = 0; i < triangles.Length; i += 3)
			{
				flippedTriangles[i] = triangles[i + 1];
				flippedTriangles[i + 1] = triangles[i];
				flippedTriangles[i + 2] = triangles[i + 2];
			}

			return shape.Points.SelectMany((p, i) => flippedTriangles.Select(t => t + i * mesh.vertices.Length));
		}
		public override IEnumerable<int> GetTriangles(IExplicitShape<GridPoint3> shape, bool doubleSided, bool flip)
		{
			if (doubleSided) return null;

			if (flip) return GetTrianglesFlipped(shape);

			return GetTrianglesNormal(shape);

		}

		private IEnumerable<int> GetTrianglesNormal(IExplicitShape<GridPoint3> shape)
		{
			return shape.Points.SelectMany((p, i) => mesh.triangles.Select(t => t + i * mesh.vertices.Length));
		}

		private IEnumerable<int> GetTrianglesFlipped(IExplicitShape<GridPoint3> shape)
		{
			var triangles = mesh.triangles;
			var flippedTriangles = new int[triangles.Length];

			for (int i = 0; i < triangles.Length; i += 3)
			{
				flippedTriangles[i] = triangles[i + 1];
				flippedTriangles[i + 1] = triangles[i];
				flippedTriangles[i + 2] = triangles[i + 2];
			}

			return shape.Points.SelectMany((p, i) => flippedTriangles.Select(t => t + i * mesh.vertices.Length));
		}

		public override IEnumerable<Vector2> GetUVs(IExplicitShape<int> shape)
		{
			return shape.Points.SelectMany(p => mesh.uv);
		}

		public override IEnumerable<Vector2> GetUVs(IExplicitShape<GridPoint2> shape)
		{
			return shape.Points.SelectMany(p => mesh.uv);
		}

		public override IEnumerable<Vector2> GetUVs(IExplicitShape<GridPoint3> shape)
		{
			return shape.Points.SelectMany(p => mesh.uv);
		}

		public override IEnumerable<Vector3> GetNormals(IExplicitShape<int> shape, GridMap<int> map, bool flip)
		{
			return shape.Points.SelectMany(p => mesh.vertices.Select((q, i) => map.GridToWorld(q + map.DeRound(p) + (flip ? -mesh.normals[i] : mesh.normals[i])).normalized));
		}

		public override IEnumerable<Vector3> GetNormals(IExplicitShape<GridPoint2> explicitShape, GridMap<GridPoint2> gridMap, bool flip)
		{
			return explicitShape.Points.SelectMany(p => mesh.vertices.Select((q, i) => gridMap.GridToWorld(q + gridMap.DeRound(p) + (flip ? -mesh.normals[i] : mesh.normals[i])).normalized));
		}

		public override IEnumerable<Vector3> GetNormals(IExplicitShape<GridPoint3> explicitShape, GridMap<GridPoint3> gridMap, bool flip)
		{
			return explicitShape.Points.SelectMany(p => mesh.vertices.Select((q, i) => gridMap.GridToWorld(q + gridMap.DeRound(p) + (flip ? -mesh.normals[i] : mesh.normals[i])).normalized));
		}

		[MenuItem("Assets/Create/Grids/Mesh Data from Mesh")]
		public static void Create()
		{
			var graph = ScriptableObject.CreateInstance<MeshDataFromMesh>();
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
				AssetDatabase.CreateAsset(graph, "Assets/MeshData.asset");
				AssetDatabase.SaveAssets();
			}
		}
	}
}*/