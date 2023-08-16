using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
//[RequireComponent(typeof(Animator))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Locations _location;
    [SerializeField] private Stage _level;
    [SerializeField] private ParticleSystem _targetPartical;
   
    private Player _player;
    private float _heightPartical = 2;

    public UnityEvent EffectsLaunched;

    private void Awake()
    {
        _player = GetComponent<Player>();
        //ResetCollisoin();
    }

    private void OnEnable()
    {
        _player.EffectsStarted += OnEffectsStarted;
    }

    private void OnDisable()
    {
        _player.EffectsStarted += OnEffectsStarted;
    }

    private void Start()
    {
        //_animator = GetComponent<Animator>();
    }

    public void ResetCollisoin()
    {
        _level = _location.GetStage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Target target))
        {
            _player.IncreaseScore(target.Score);
            _level.GetComponent<PlayerColor>().SetColor();
            _level.GetComponent<ObstacleColor>().SetColor();
            _level.SetLevel();
            _level.GetComponentInChildren<Plant>().RemoveTile();
            _targetPartical.gameObject.transform.position = new Vector3(target.transform.position.x, _heightPartical, target.transform.position.z);
            _targetPartical.Play();
        }
        else if (other.TryGetComponent(out Water water))
        {
            _player.Die();
        }
    }

    private void OnEffectsStarted()
    {
        EffectsLaunched?.Invoke();
    }
}
