using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Locations _location;
    [SerializeField] private Stage _level;

    private Player _player;

    private void Awake()
    {
        ResetCollisoin();
    }

    private void Start()
    {
        _player = GetComponent<Player>();      
    }

    public void ResetCollisoin()
    {
        _level = _location.GetStage();
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
