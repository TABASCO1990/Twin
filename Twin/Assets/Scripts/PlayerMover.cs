using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private Vector2 _direction;
    private Vector2 _rotate;
    private Vector2 _rotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = new PlayerInput();

        _input.Enable();
    }

    private void Update()
    {
        _direction = _input.Player.Movement.ReadValue<Vector2>();

        Move(_direction);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.1)
            return;

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;        
    }
    
    private void Look()
    {

    }
}
