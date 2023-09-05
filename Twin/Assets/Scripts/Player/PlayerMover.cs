using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;  

    private PlayerInput _input;
    private Vector2 _direction;
    private Vector3 _offset;
    private Animator _animator;
    private bool _isMove = true;
    private bool _isRunning;

    private void Awake()
    {
        _input = new PlayerInput();       
        _input.Enable();   
    }

    private void Start()
    {        
        _animator = GetComponent<Animator>();
        ResetPlayer();
    }

    private void Update()
    {
        _direction = _input.Player.Movement.ReadValue<Vector2>();

        if (_isMove)
        {
            Move(_direction);
            Rotate();
        }
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.1)
        {
            _animator.SetBool(nameof(_isRunning), false);
            return;
        }

        _offset = new Vector3(direction.x, 0, direction.y);
        transform.Translate(_offset * _moveSpeed * Time.deltaTime, Space.World);
        _animator.SetBool(nameof(_isRunning), true);
    }

    private void Rotate()
    {
        if (_offset != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_offset, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotateSpeed * Time.deltaTime);
        }
    }

    public void StopMove()
    {
        StartCoroutine(ÑhangeStates());    
    }

    IEnumerator ÑhangeStates()
    {
        _isMove = false;
        _animator.SetBool("_isTakeHit", true);
        yield return new WaitForSeconds(3);
        _animator.SetBool("_isTakeHit", false);
        _isMove = true;
    }
}
