using Gamelogic.Extensions.Internal;

namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("Bitmask", 1)]
	[Version(2, 3)]
	public class Bitmask1ShapeNode : PrimitiveShapeNode<int>
	{
		public string mask;

		protected override IExplicitShape<int> Generate()
		{
			return ExplicitShape.Bitmask(mask);
		}
	}
}