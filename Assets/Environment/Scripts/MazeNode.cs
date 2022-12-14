using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeNode : MonoBehaviour
{
    [SerializeField] private GameObject[] _walls;

    public GameObject[] Walls
    {
        get => _walls;
        set => _walls = value;
    }

    public void RemoveWall(int wallToRemove)
    {
        Destroy(_walls[wallToRemove].gameObject);

        //If you don't want to destroy wall uncomment this section and comment/delete section above
        //_walls[wallToRemove].gameObject.SetActive(false);
    }
}
