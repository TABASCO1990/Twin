using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private PlayerInput _input;
    private Vector2 _direction;
    private Vector3 _offset;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Enable();
    }

    private void Update()
    {
        _direction = _input.Player.Movement.ReadValue<Vector2>();

        Move(_direction);
        Look();
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.1)
            return;

        _offset = new Vector3(direction.x, 0, direction.y);
        transform.Translate(_offset * _moveSpeed * Time.deltaTime, Space.World);    
    }

    private void Look()
    {
        if (_offset != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_offset, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
