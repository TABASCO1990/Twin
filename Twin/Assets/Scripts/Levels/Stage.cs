using UnityEngine;

public class Stage : ObjectPool
{
    [SerializeField] private GameObject[] _levelPrefabs;
    [SerializeField] private int _startLevelPrefab = 0;
    [SerializeField] private Player _player;

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

        _player.CheckLevelCompletion();
    }

    private void InitializeObstacle(GameObject level)
    {
        int numberCurrentLevel = _pool.IndexOf(level) - 1;
        _pool[numberCurrentLevel].SetActive(false);
        level.SetActive(true);
    }
}
