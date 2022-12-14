using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 200f;
    [SerializeField] private Transform _orientation;

    private float _xRotation;
    private float _yRotation;

    public float MouseSensitivity
    {
        get => _mouseSensitivity;
        set => _mouseSensitivity = value;
    }

    public Transform Orientation
    {
        get => _orientation;
        set => _orientation = value;
    }

    public float xRotation
    {
        get => _xRotation;
        set => _xRotation = value;
    }

    public float yRotation
    {
        get => _yRotation;
        set => _yRotation = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _mouseSensitivity = ApplicationModel.MouseSensitivity;
        // Hide cursor from start the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Player camera rotation
        float mouseX = Input.GetAxisRaw("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        _orientation.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }
}
