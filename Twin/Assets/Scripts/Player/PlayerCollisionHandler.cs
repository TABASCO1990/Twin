using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    //[SerializeField] private UnityEvent LevelChanged;
    [SerializeField] private Location _location;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Target target))
        {
            _player.IncreaseScore(target.Score);
            //LevelChanged?.Invoke();
            _location.GetComponent<PlayerColor>().SetColor();
            _location.GetComponent<ObstacleColor>().SetColor();
            _location.SetLevel();
            _location.GetComponentInChildren<Plant>().RemoveTile();
        }
        else if (other.TryGetComponent(out Water water))
        {
            _player.Die();
        }
    }
}
