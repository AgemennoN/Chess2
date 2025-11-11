#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PerkEffect), true)]
public class PerkEffectDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        var lineHeight = EditorGUIUtility.singleLineHeight;
        var buttonRect = new Rect(position.x, position.y, position.width, lineHeight);

        var currentType = property.managedReferenceValue?.GetType();
        var buttonLabel = currentType == null ? "Add Effect Type" : $"Change ({currentType.Name})";

        if (GUI.Button(buttonRect, buttonLabel)) {
            var menu = new GenericMenu();
            var baseType = typeof(PerkEffect);
            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract && t != baseType);

            foreach (var t in allTypes) {
                menu.AddItem(new GUIContent(t.Name), false, () => {
                    property.serializedObject.Update();
                    property.managedReferenceValue = Activator.CreateInstance(t);
                    property.serializedObject.ApplyModifiedProperties();
                });
            }

            if (currentType != null) {
                menu.AddSeparator("");
                menu.AddItem(new GUIContent("Remove"), false, () => {
                    property.serializedObject.Update();
                    property.managedReferenceValue = null;
                    property.serializedObject.ApplyModifiedProperties();
                });
            }

            menu.ShowAsContext();
        }

        if (property.managedReferenceValue != null) {
            var contentRect = new Rect(position.x, position.y + lineHeight + 2, position.width, position.height - lineHeight - 2);
            EditorGUI.PropertyField(contentRect, property, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        var height = EditorGUIUtility.singleLineHeight + 4;
        if (property.managedReferenceValue != null)
            height += EditorGUI.GetPropertyHeight(property, true);
        return height;
    }
}
#endif
