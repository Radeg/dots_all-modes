using UnityEngine;

namespace Gamelogic.Grids2.Graph
{
	[SpaceMapNode("Polar/Twirl XY", 3)]
	public class TwirlXYSpaceMapNode : ProjectSpaceMapNode<Vector3, Vector3>
	{
		public float anglePerRadius;

		protected override IMap<Vector3, Vector3> Transform(IMap<Vector3, Vector3> input)
		{
			var map = Map.Twirl(anglePerRadius);

			if (input == null) return map;

			return input.ComposeWith(map);
		}
	}
}