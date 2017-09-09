
using Gamelogic.Extensions.Editor.Internal;
using UnityEditor;

namespace Gamelogic.Grids2.Editor
{
	/// <summary>
	/// The editor class for <see cref="MeshGridBuilder"/>.
	/// </summary>
	/// <seealso cref="GLEditor{T}" />
	[CustomEditor(typeof(MeshGridBuilder)), CanEditMultipleObjects]
	public sealed class MeshGridBuilderEditor : GLEditor<MeshGridBuilder>
	{
		public override void OnInspectorGUI()
		{
			Splitter();
			AddTextAndButton("Build Grid", "Build", BuildGrid);
			Splitter();

			base.OnInspectorGUI();
		}

		private void BuildGrid()
		{
			Target.cellStorage = null;
			Target.Build();
		}
	}
}