using UnityEngine;
using UnityEngine.Events;

public class Level : ObjectPool
{
    [SerializeField] private GameObject[] _levelPrefabs;
    [SerializeField] private int _startLevelPrefab = 0;
    [SerializeField] private Player _player;

    public event UnityAction LevelComplete;

    private void Start()
    {
        foreach (var level in _levelPrefabs)
        {
            Initialize(level);
        }

        _pool[_startLevelPrefab].SetActive(true);
    }

    public void SetLevel()
    {
        if (TryGetNextObject(out GameObject level))
        {
            InitializeObstacle(level);
        }

        CheckLevelCompletion();
    }

    public void CheckLevelCompletion()
    {
        if (_player.CountEventsScore == _levelPrefabs.Length)
        {
            LevelComplete?.Invoke();
        }
    }

    private void InitializeObstacle(GameObject level)
    {
        int numberCurrentLevel = _pool.IndexOf(level) - 1;
        _pool[numberCurrentLevel].SetActive(false);
        level.SetActive(true);
    }
}
