using System;
using System.Linq;
using Gamelogic.Extensions;
using UnityEngine;

namespace Gamelogic.Grids2
{
	/// <summary>
	/// A grid builder that uses a single mesh for the entire grid.
	/// </summary>
	/// <seealso cref="GridBuilder{MeshCell}" />
	public class MeshGridBuilder : GridBuilder<MeshCell>
	{
		public bool doubleSided;
		public bool flipTriangles;
		public MeshData meshData;

		private MeshFilter meshFilter;

		public override void MakeCells<TPoint>(
			IGrid<TPoint, MeshCell> grid, 
			GridMap<TPoint> map)
		{
			meshFilter = this.GetRequiredComponent<MeshFilter>();
			var mesh = new Mesh();

			switch (gridShapeGraph.gridType)
			{
				case GridType.Grid1:
					InitMesh(mesh, (IGrid<int, MeshCell>)grid, (GridMap<int>)(object)map);
					break;
				case GridType.Grid2:
					InitMesh(mesh, (IGrid<GridPoint2, MeshCell>)grid, (GridMap<GridPoint2>)(object)map);
					break;
				case GridType.Grid3:
					InitMesh(mesh, (IGrid<GridPoint3, MeshCell>)grid, (GridMap<GridPoint3>)(object)map);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			meshFilter.sharedMesh = mesh;
			mesh.UploadMeshData(false); //TODO: Check whether this should be true or false
		
			cellStorage = new MeshCell[grid.Cells.Count()];

			var meshCellIndex = 0;
			foreach (var meshCell in grid.Cells)
			{
				cellStorage[meshCellIndex] = meshCell;				

				meshCellIndex++;
			}
		}
		
		private void InitMesh(Mesh mesh, IExplicitShape<int> grid, GridMap<int> map)
		{
			mesh.vertices = meshData.GetVertices(grid, map).ToArray();
			mesh.triangles = meshData.GetTriangles(grid, doubleSided, flipTriangles).ToArray();
			mesh.uv = meshData.GetUVs(grid).ToArray();
			//mesh.normals = meshData1.GetNormals(grid, map, doubleSided, flipTriangles).ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			//mesh.normals
		}

		private void InitMesh(Mesh mesh, IExplicitShape<GridPoint2> grid, GridMap<GridPoint2> map)
		{
			mesh.vertices = meshData.GetVertices(grid, map).ToArray();
			mesh.triangles = meshData.GetTriangles(grid, doubleSided, flipTriangles).ToArray();
			mesh.uv = meshData.GetUVs(grid).ToArray();
			//mesh.normals = meshData1.GetNormals(grid, map, doubleSided, flipTriangles).ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			//mesh.normals
		}

		private void InitMesh(Mesh mesh, IExplicitShape<GridPoint3> grid, GridMap<GridPoint3> map)
		{
			mesh.vertices = meshData.GetVertices(grid, map).ToArray();
			mesh.triangles = meshData.GetTriangles(grid, doubleSided, flipTriangles).ToArray();
			mesh.uv = meshData.GetUVs(grid).ToArray();
			//mesh.normals = meshData1.GetNormals(grid, map, doubleSided, flipTriangles).ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			//mesh.normals
		}
	}
}