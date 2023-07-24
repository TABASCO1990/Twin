using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private bool _isRunning;
    private PlayerInput _input;
    private Vector2 _direction;
    private Vector3 _offset;

    public event UnityAction Running;
    private Animator _animator;

    private void Awake()
    {
        _input = new PlayerInput();       

        _input.Enable();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = _input.Player.Movement.ReadValue<Vector2>();

        Move(_direction);
        Rotate();
    }

    public void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.1)
        {
            _animator.SetBool(nameof(_isRunning), false);
            return;
        }

        _offset = new Vector3(direction.x, 0, direction.y);
        transform.Translate(_offset * _moveSpeed * Time.deltaTime, Space.World);
        _animator.SetBool(nameof(_isRunning), true);

        Running?.Invoke();
    }

    private void Rotate()
    {
        if (_offset != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_offset, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
