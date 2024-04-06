using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static ShapeData;

[CustomEditor(typeof(ShapeData)), CanEditMultipleObjects]
public class DataDrawer : Editor
{
    private ShapeData data => (ShapeData)target;
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawColumnsInputFields();
        EditorGUILayout.Space();

        if (data.shape != null && data.col > 0 && data.row > 0) DrawTable();
        serializedObject.ApplyModifiedProperties();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(data);
        }
    }
    private void DrawColumnsInputFields()
    {
        var columnsTemp = data.col;
        var rowsTemp = data.row;
        data.col = EditorGUILayout.IntField(label: "Columns", data.col);
        data.row = EditorGUILayout.IntField(label: "Rows", data.row);
        if ((data.col != columnsTemp || data.row != rowsTemp) && data.col > 0 && data.row > 0)
            data.Create();
    }
    private void DrawTable()
    {
        var tableStyle = new GUIStyle(other: "box");
        tableStyle.padding = new RectOffset(left: 10, right: 10, top: 10, bottom: 10);
        tableStyle.margin.left = 32;
        var headerColumnStyle = new GUIStyle();
        headerColumnStyle.fixedWidth = 65;
        headerColumnStyle.alignment = TextAnchor.MiddleCenter;
        var rowstyle = new GUIStyle();
        rowstyle.fixedHeight = 25;
        rowstyle.alignment = TextAnchor.MiddleCenter;
        var dataFieldStyle = new GUIStyle(EditorStyles.miniButtonMid);
        dataFieldStyle.normal.background = Texture2D.grayTexture;
        dataFieldStyle.onNormal.background = Texture2D.whiteTexture;
        for (var i = 0; i < data.row; i++)
        {
            EditorGUILayout.BeginHorizontal(headerColumnStyle);
            for (var j = 0; j < data.col; j++)
            {
                EditorGUILayout.BeginHorizontal(rowstyle);
                var boolean = EditorGUILayout.Toggle(data.shape[i].col[j], dataFieldStyle);
                data.shape[i].col[j] = boolean;
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndHorizontal();
        }
    }

}
