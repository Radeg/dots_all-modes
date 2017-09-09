using UnityEngine;

namespace Gamelogic.Grids2.Internal
{
	public class DebugMesh : MonoBehaviour
	{

		public Color color = Color.white;
		public float radius = 0.1f;

		public void OnDrawGizmos()
		{
			Gizmos.color = color;

			foreach (var vert in GetComponent<MeshFilter>().sharedMesh.vertices)
			{
				Gizmos.DrawSphere(transform.TransformPoint(vert), radius);
			}
		}
	}
}