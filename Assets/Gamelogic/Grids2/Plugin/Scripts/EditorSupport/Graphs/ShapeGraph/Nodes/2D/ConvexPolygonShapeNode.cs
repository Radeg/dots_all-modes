using System.Linq;
using Gamelogic.Extensions.Internal;

namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("All/Convex Polygon", 2)]
	[Version(2, 3)]
	public class ConvexPolygonShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public InspectableGridPoint2[] vertices;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			var points = vertices.Select(p => p.GetGridPoint());
			var implicitShape = ImplicitShape.ConvexPolygon(points);
			var bounds = GridRect.Erode(ExplicitShape.GetBounds(points));

			return implicitShape.ToExplicit(bounds);
		}
	}
}