using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IngredientMustNotHave)), CanEditMultipleObjects]
public class IngredientMustNotHaveInspector : Editor {
    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorList.Show(serializedObject.FindProperty("ingredients"), EditorListOption.ListLabel | EditorListOption.Buttons);

        serializedObject.ApplyModifiedProperties();
    }

}
