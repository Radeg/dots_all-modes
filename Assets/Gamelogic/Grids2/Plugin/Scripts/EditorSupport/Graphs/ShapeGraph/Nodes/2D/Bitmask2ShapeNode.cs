using Gamelogic.Extensions.Internal;

namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("Polyomino/Bitmask", 2)]
	[Version(2, 3)]
	public class Bitmask2ShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public string[] mask;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			return ExplicitShape.Bitmask(mask);
		}
	}
}