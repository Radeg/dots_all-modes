using Gamelogic.Extensions.Internal;

namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("Bitmask", 3)]
	[Version(2, 3)]
	public class Bitmask3ShapeNode : PrimitiveShapeNode<GridPoint3>
	{
		public string[][] mask;

		protected override IExplicitShape<GridPoint3> Generate()
		{
			return ExplicitShape.Bitmask(mask);
		}
	}
}