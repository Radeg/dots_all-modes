using UnityEngine;

namespace Gamelogic.Grids2
{
	public class GridEventTrigger : GridBehaviour<GridPoint2, TileCell>
	{
		public Camera uiCamera;
		public GridEvent onLeftMouseButtonDown;
		public GridEvent onRightMouseButtonDown;
	
		public GridPoint2 MousePosition
		{
			get
			{
				var worldPosition = transform.InverseTransformPoint(uiCamera.ScreenToWorldPoint(Input.mousePosition));
			
				return GridMap.WorldToGridToDiscrete(worldPosition);
			}
		}

		public void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (Grid.Contains(MousePosition))
				{
					if (onLeftMouseButtonDown != null)
					{
						onLeftMouseButtonDown.Invoke(MousePosition);
					}
				}
			}

			if (Input.GetMouseButtonDown(1))
			{
				if (Grid.Contains(MousePosition))
				{
					if (onRightMouseButtonDown != null)
					{
						onRightMouseButtonDown.Invoke(MousePosition);
					}
				}
			}
		}
	}
}