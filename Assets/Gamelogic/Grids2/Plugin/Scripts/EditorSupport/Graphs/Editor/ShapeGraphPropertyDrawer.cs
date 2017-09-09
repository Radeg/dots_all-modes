using UnityEditor;
using UnityEngine;

namespace Gamelogic.Grids2.Graph.Editor
{
	/// <summary>
	/// Class for drawing a <see cref="GridShapeGraph"/> field in the editor.
	/// </summary>
	[CustomPropertyDrawer(typeof(GridShapeGraph))]
	public class ShapeGraphPropertyDrawer : PropertyDrawer
	{
		private const float ExtraHeight = 20;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) + ExtraHeight;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var gridTypeProperty = property.FindPropertyRelative("gridType");
			var shape1GraphProperty = property.FindPropertyRelative("shape1Graph");
			var shape2GraphProperty = property.FindPropertyRelative("shape2Graph");
			var shape3GraphProperty = property.FindPropertyRelative("shape3Graph");

			EditorGUI.BeginProperty(position, label, property);		

			position.height = 16;
			var enumRect = new Rect(position.x, position.y + 1, position.width, position.height);
			var exactShapeRect = new Rect(position.x, position.y + 20, position.width, position.height);

			EditorGUI.PropertyField(enumRect, gridTypeProperty);

			switch (gridTypeProperty.enumValueIndex)
			{
				case 0:
					EditorGUI.PropertyField(exactShapeRect, shape1GraphProperty);
					break;
				case 1:
					EditorGUI.PropertyField(exactShapeRect, shape2GraphProperty);
					break;
				case 2:
					EditorGUI.PropertyField(exactShapeRect, shape3GraphProperty);
					break;
				default:
					EditorGUI.LabelField(exactShapeRect, "There is no graph shape for this kind of grid.");
					break;
			}

			EditorGUI.EndProperty();
		}
	}
}