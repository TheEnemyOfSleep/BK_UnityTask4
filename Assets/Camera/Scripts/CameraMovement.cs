using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;

    public Transform CameraPosition
    {
        get => _cameraPosition;
        set => _cameraPosition = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _cameraPosition.position;
    }
}
