using System.Linq;
using Gamelogic.Extensions;
using UnityEngine;

namespace Gamelogic.Grids2
{
	/// <summary>
	/// A builder that uses separate objects for each cell of a grid.
	/// </summary>
	/// <seealso cref="GridBuilder{TileCell}" />
	public class TileGridBuilder : GridBuilder<TileCell>
    {
        [SerializeField, HideInInspector]
        public GameObject prefab;

        public override void MakeCells<TPoint>(
			IGrid<TPoint, TileCell> grid,
			GridMap<TPoint> map)
        {
            if (Application.isPlaying)
            {
                gameObject.transform.DestroyChildren();
            }
            else
            {
                gameObject.transform.DestroyChildrenImmediate();
            }

            cellStorage = new TileCell[grid.Points.Count()];

            var pointIndex = 0;

            foreach (var point in grid.Points)
            {                
                var cell = Instantiate(prefab, gameObject);
                cell.transform.localPosition = map.GridToWorld(point);

                var spriteCellComponent = cell.GetComponent<TileCell>();
                grid[point] = spriteCellComponent;
                cellStorage[pointIndex] = spriteCellComponent;

                pointIndex++;
            }
        }
    }
}