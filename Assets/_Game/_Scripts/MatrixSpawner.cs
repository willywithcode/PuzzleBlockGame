using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MatrixSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 firstPos;
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private List<GameObject> squares;
    [SerializeField] private Vector2 spacing;
    [SerializeField] private Vector2 shape;

    public void SpawnSquare()
    {
        foreach (var square in squares)
        {
            DestroyImmediate(square);
        }
        squares.Clear();
        for(int i = 0; i < 8; i ++)
        {
            for (int j = 0; j < 8; j ++)
            {
                var square = Instantiate(squarePrefab, this.transform);
                squares.Add(square);
                square.transform.position = new Vector3(firstPos.x + i * (shape.x + spacing.x),
                                                        firstPos.y - j * (spacing.y + shape.y),
                                                        0);
            }
        }
    }

    public void ClearSquare()
    {
        foreach(var square in squares)
        {
            DestroyImmediate(square);

        }
        squares.Clear();
    }

    public void FillShapeSize()
    {
        SpriteRenderer ren = squarePrefab.GetComponentInChildren<SpriteRenderer>();
        shape.x = ren.bounds.size.x;
        shape.y = ren.bounds.size.y;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(MatrixSpawner))]
public class MatrixSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MatrixSpawner matrixSpawner = (MatrixSpawner)target;

        if(GUILayout.Button("Spawn"))
        {
            matrixSpawner.SpawnSquare();
        }
        if( GUILayout.Button("Clear"))
        {
            matrixSpawner.ClearSquare();

        }

        if(GUILayout.Button("Fill") ){
            matrixSpawner.FillShapeSize();
        }
    }
}

#endif
