using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;
using UnityEditorInternal;

[CustomEditor(typeof(MonoBehaviour), true)]
public class SortingLayerEditor : Editor
{

    SerializedProperty[] properties;
    string[] sortingLayerNames;

    void OnEnable()
    {
        if (Attribute.IsDefined(target.GetType(), typeof(HasSortingLayer)))
        {
            var sortingLayer = (HasSortingLayer)Attribute.GetCustomAttribute(target.GetType(), typeof(HasSortingLayer));
            properties = sortingLayer.Names.Select(s => {
                return serializedObject.FindProperty(s);
            }).ToArray();
            sortingLayerNames = GetSortingLayerNames();
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (properties != null && sortingLayerNames != null)
        {
            foreach (var p in properties)
            {
                if (p == null)
                {
                    continue;
                }
                int index = Mathf.Max(0, Array.IndexOf(sortingLayerNames, p.stringValue));
                index = EditorGUILayout.Popup(p.displayName, index, sortingLayerNames);

                p.stringValue = sortingLayerNames[index];
            }

            if (GUI.changed)
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }

    public string[] GetSortingLayerNames()
    {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
        var sortingLayers = (string[])sortingLayersProperty.GetValue(null, new object[0]);
        return sortingLayers;
    }
}