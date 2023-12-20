using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _countBonusSeconds = 1f;
    [SerializeField] private int _score = 10;

    public int Score => _score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player.Player player))
        {
            player.IncreaseTime(_countBonusSeconds);
        }
    }
}
