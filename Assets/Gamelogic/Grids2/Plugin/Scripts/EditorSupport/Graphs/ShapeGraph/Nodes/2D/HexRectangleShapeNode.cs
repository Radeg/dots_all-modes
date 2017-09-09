using System;
using Gamelogic.Extensions;
using Gamelogic.Extensions.Internal;

namespace Gamelogic.Grids2.Graph
{
	/// <summary>
	/// Node that generates a up triangle shape.
	/// </summary>
	[ShapeNode("Hex/Rectangle", 2)]
	[Version(2, 2)]
	class HexRectangleShapeNode : PrimitiveShapeNode<GridPoint2>
	{
		public enum RectangleType
		{
			Normal,
			Fat,
			Thin
		}
		public enum HexType
		{
			Pointy,
			Flat
		}

		public RectangleType type = RectangleType.Fat;
		public HexType hexType = HexType.Pointy;

		public InspectableGridPoint2 dimensions = new InspectableGridPoint2{x = 0, y = 0};

		protected override IExplicitShape<GridPoint2> Generate()
		{
			var size = dimensions.GetGridPoint();

			switch (hexType)
			{
				case HexType.Pointy:
					switch (type)
					{
						case RectangleType.Normal:
							return GetRectangle(size);
						case RectangleType.Fat:
							return GetFatRectangle(size);
						case RectangleType.Thin:
							return GetThinRectangle(size);
						default:
							throw new ArgumentOutOfRangeException();
					}
				case HexType.Flat:
					switch (type)
					{
						case RectangleType.Normal:
							return GetFlatRectangle(size);
						case RectangleType.Fat:
							return GetFlatFatRectangle(size);
						case RectangleType.Thin:
							return GetFlatThinRectangle(size);
						default:
							throw new ArgumentOutOfRangeException();
					}
				default:
					throw new ArgumentOutOfRangeException();
			}
			
		}

		private IExplicitShape<GridPoint2> GetFlatThinRectangle(GridPoint2 size)
		{
			var storageWidth = size.X;
			var storageHeight = size.Y + GLMathf.FloorDiv(size.X - 1, 2);
			var storageBottomLeft = new GridPoint2(0, -GLMathf.FloorDiv(size.X - 1, 2));

			return
				ImplicitShape.FlatHexThinRectangle(size)
					.ToExplicit(new GridRect(storageBottomLeft, new GridPoint2(storageWidth, storageHeight)));
		}

		private IExplicitShape<GridPoint2> GetFlatFatRectangle(GridPoint2 size)
		{
			var storageWidth = size.X;
			var storageHeight = size.Y + GLMathf.FloorDiv(size.X, 2);
			var storageBottomLeft = new GridPoint2(0, -GLMathf.FloorDiv(size.X, 2));

			return
				ImplicitShape.FlatHexFatRectangle(size)
					.ToExplicit(new GridRect(storageBottomLeft, new GridPoint2(storageWidth, storageHeight)));
		}

		private IExplicitShape<GridPoint2> GetFlatRectangle(GridPoint2 size)
		{
			var storageWidth = size.X;
			var storageHeight = size.Y + GLMathf.FloorDiv(size.X - 1, 2);
			var storageBottomLeft = new GridPoint2(0, -GLMathf.FloorDiv(size.X - 1, 2));

			return
				ImplicitShape.FlatHexRectangle(size)
					.ToExplicit(new GridRect(storageBottomLeft, new GridPoint2(storageWidth, storageHeight)));
		}

		private static IExplicitShape<GridPoint2> GetFatRectangle(GridPoint2 size)
		{
			int storageWidth = size.X + GLMathf.FloorDiv(size.Y, 2);
			int storageHeight = size.Y;
			var storagePoint = new GridPoint2(-GLMathf.FloorDiv(size.Y, 2), 0);

			return ImplicitShape.HexFatRectangle(size).ToExplicit(new GridRect(storagePoint, new GridPoint2(storageWidth, storageHeight)));
		}

		private static IExplicitShape<GridPoint2> GetRectangle(GridPoint2 size)
		{
			int storageWidth = size.X + GLMathf.FloorDiv(size.Y - 1, 2);
			int storageHeight = size.Y;
			var storagePoint = new GridPoint2(-GLMathf.FloorDiv(size.Y - 1, 2), 0);

			return ImplicitShape.HexRectangle(size).ToExplicit(new GridRect(storagePoint, new GridPoint2(storageWidth, storageHeight)));
		}

		private static IExplicitShape<GridPoint2> GetThinRectangle(GridPoint2 size)
		{
			int storageWidth = size.X + GLMathf.FloorDiv(size.Y - 1, 2);
			int storageHeight = size.Y;
			var storagePoint = new GridPoint2(-GLMathf.FloorDiv(size.Y - 1, 2), 0);

			return ImplicitShape.HexThinRectangle(size).ToExplicit(new GridRect(storagePoint, new GridPoint2(storageWidth, storageHeight)));
		}
	}
}