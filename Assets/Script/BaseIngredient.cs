using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIngredient : BaseTasty {

    private bool listVisibility = true;

    public string i_name = "none";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public override void OnInspectorGUI() {
    //    serializedObject.Update();
    //    EditorGUIUtility.LookLikeInspector();
    //    ListIterator("myArrayField", ref listVisibility);
    //    serializedObject.ApplyModifiedProperties();
    //}


    //public void ListIterator(string propertyPath, ref bool visible) {
    //    SerializedProperty listProperty = serializedObject.FindProperty(propertyPath);
    //    visible = EditorGUILayout.Foldout(visible, listProperty.name);
    //    if (visible) {
    //        EditorGUI.indentLevel++;
    //        for (int i = 0; i < listProperty.arraySize; i++) {
    //            SerializedProperty elementProperty = listProperty.GetArrayElementAtIndex(i);
    //            Rect drawZone = GUILayoutUtility.GetRect(0f, 16f);
    //            bool showChildren = EditorGUI.PropertyField(drawZone, elementProperty);
    //        }
    //        EditorGUI.indentLevel--;
    //    }
    //}
}
