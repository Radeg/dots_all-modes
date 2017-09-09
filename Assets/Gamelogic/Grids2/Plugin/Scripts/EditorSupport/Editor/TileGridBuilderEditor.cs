using Gamelogic.Extensions.Editor.Internal;
using UnityEditor;
using UnityEngine;

namespace Gamelogic.Grids2.Editor
{
	/// <summary>
	/// The editor class for <see cref="TileGridBuilder"/>.
	/// </summary>
	/// <seealso cref="GLEditor{T}" />
	[CustomEditor(typeof(TileGridBuilder)), CanEditMultipleObjects]
    public class TileGridBuilderEditor : GLEditor<TileGridBuilder>
    {
        public override void OnInspectorGUI()
        {
			Target.prefab = EditorGUILayout.ObjectField("Cell Prefab", Target.prefab, typeof(Object), true) as GameObject;

			Splitter();
			AddTextAndButton("Build Grid", "Build", BuildGrid);
			Splitter();

			base.OnInspectorGUI();
        }

        private void BuildGrid()
        {
            if (Target.prefab == null)
            {
                Debug.LogError("No prefab is attached.");
                return;
            }

	        Target.cellStorage = null;
            Target.Build();
        }
    }
}