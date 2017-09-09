using UnityEngine;

namespace Gamelogic.Grids.Examples
{
    public class DotTileSet : ScriptableObject
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Gamelogic/Examples/Create Dot Tile Set")]
        public static void CreateTileSet()
        {
            var tileSet = CreateInstance<DotTileSet>();
            UnityEditor.AssetDatabase.CreateAsset(tileSet, "Assets/DotTiles.asset");
            UnityEditor.AssetDatabase.SaveAssets();
        }
#endif

        public Sprite[] sprites;
        public Color[] colors = ExampleUtils.Colors;
    }
}