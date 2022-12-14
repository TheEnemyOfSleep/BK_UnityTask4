using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _orientation;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    private Vector3 _velocity;
    private bool _isGrounded;

    public Transform Orientation
    {
        get => _orientation;
        set => _orientation = value;
    }

    public CharacterController Controller
    {
        get => _controller;
        set => _controller = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float Gravity
    {
        get => _speed;
        set => _speed = value;
    }

    public Transform GroundCheck
    {
        get => _groundCheck;
        set => _groundCheck = value;
    }

    public float GroundDistance
    {
        get => _groundDistance;
        set => _groundDistance = value;
    }

    public LayerMask GroundMask
    {
        get => _groundMask;
        set => _groundMask = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if(_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        transform.rotation = _orientation.rotation;

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }
}
