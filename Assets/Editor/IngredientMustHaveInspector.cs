using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IngredientMustHave)), CanEditMultipleObjects]
public class IngredientMustHaveInspector : Editor {
    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorList.Show(serializedObject.FindProperty("ingredients"), EditorListOption.ListLabel | EditorListOption.Buttons);

        serializedObject.ApplyModifiedProperties();
    }

}
