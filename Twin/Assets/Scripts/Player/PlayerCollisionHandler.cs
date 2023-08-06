using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Locations _location;
    [SerializeField] private Level _level;

    private Player _player;

    private void Awake()
    {
        _level = _location.GetLevel();
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Target target))
        {
            _player.IncreaseScore(target.Score);
            _level.GetComponent<PlayerColor>().SetColor();
            _level.GetComponent<ObstacleColor>().SetColor();
            _level.SetLevel();
            _level.GetComponentInChildren<Plant>().RemoveTile();
        }
        else if (other.TryGetComponent(out Water water))
        {
            _player.Die();
        }
    }
}
