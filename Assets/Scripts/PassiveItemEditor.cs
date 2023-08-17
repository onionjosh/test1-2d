using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PassiveItem))]
public class PassiveItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PassiveItem passiveItem = (PassiveItem)target; // Declare and assign 'passiveItem' here
        if (passiveItem == null)
        {
            EditorGUILayout.LabelField("No PassiveItem selected.");
            return;
        }

        // Draw the default inspector
        DrawDefaultInspector();

        if (GUILayout.Button("Add New Rank"))
        {
            passiveItem.AddNewRank();
        }

        // If the list was changed, mark the object as dirty
        if (GUI.changed)
        {
            EditorUtility.SetDirty(passiveItem);
        }
    }
}
