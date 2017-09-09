using Gamelogic.Extensions.Internal;

namespace Gamelogic.Grids2.Graph
{
	[ShapeNode("Polyomino/Hexomino", 2)]
	[Version(2, 3)]
	public class HexominoShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public Polyominoes.Hexomino.Type type;

		protected override IExplicitShape<GridPoint2> Generate()
		{
			return Polyominoes.Hexomino.Shapes[type];
		}
	}
}