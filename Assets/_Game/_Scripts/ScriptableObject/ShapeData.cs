using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShapeData", menuName = " ScriptableObject/ShapeData")]
public class ShapeData : ScriptableObject
{
    [Serializable]
    public class Row
    {
        public bool[] col;
        private int _size = 0;
        public Row() { }
        public Row(int size)
        {
            col = new bool[size];
            _size = size;
        }

        public void ClearRow()
        {
            for (int i = 0; i < _size; i++)
            {
                col[i] = false;
            }
        }
    }
    public int col = 0;
    public int row = 0;
    public Row[] shape;

    public void Create()
    {
        shape = new Row[row];
        for(int i = 0; i < row; i++)
        {
            shape[i] = new Row(col);
        }
    }
}
