using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Locations _location;
    [SerializeField] private Stage _level;
    [SerializeField] private ParticleSystem _targetPartical;
    [SerializeField] private ParticleSystem _bombPartical;
   
    private Player _player;
    private float _heightParticalTarget = 2;
    private float _heightParticalBomb = 0.5f;

    public UnityEvent EffectsLaunched;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.EffectsStarted += OnEffectsStarted;
    }   

    private void OnDisable()
    {
        _player.EffectsStarted -= OnEffectsStarted;
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
            _targetPartical.gameObject.transform.position = new Vector3(target.transform.position.x, _heightParticalTarget, target.transform.position.z);
            _targetPartical.Play();
        }
        else if (other.TryGetComponent(out Water water))
        {
            _player.Die();
        }
        else if(other.TryGetComponent(out Bomb bomb))
        {
            _bombPartical.gameObject.transform.position = new Vector3(bomb.transform.position.x, _heightParticalBomb, bomb.transform.position.z);

            _bombPartical.Play();         
        }
    }

    private void OnEffectsStarted()
    {
        EffectsLaunched?.Invoke();
    }  
}
