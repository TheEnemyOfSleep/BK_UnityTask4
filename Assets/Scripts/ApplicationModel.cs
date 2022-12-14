using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel : MonoBehaviour
{
    static private int _mazeTiles = 10;

    static public int MazeTiles
    {
        get => _mazeTiles;
        set => _mazeTiles = value;
    }

    static private float _mouseSensitivity = 200f;

    static public float MouseSensitivity
    {
        get => _mouseSensitivity;
        set => _mouseSensitivity = value;
    }
}
