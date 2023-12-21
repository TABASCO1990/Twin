using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerCollisionHandler))]
    public class Player : MonoBehaviour
    {
        private const int MaxCountScore = 17;

        [SerializeField] private Shared.Progress _progress;

        private PlayerMover _mover;
        private PlayerCollisionHandler _collisionHandler;
        private int _score;
        private int _countEventsScore;

        public event UnityAction<int> ScoreChanging;

        public event UnityAction<int> ScoreCountChanging;

        public event UnityAction<float> TimeChanging;

        public event UnityAction EffectsStarting;

        public event UnityAction BombExploding;

        public event UnityAction LevelCompleted;

        public event UnityAction GameOver;

        public int CountEventsScore => _countEventsScore;

        public int Score => _score;

        private void Start()
        {
            _mover = GetComponent<PlayerMover>();
            _collisionHandler = GetComponent<PlayerCollisionHandler>();
        }

        public void IncreaseScore(int score)
        {
            _score += score;
            _countEventsScore++;
            ScoreChanging?.Invoke(_score);
            ScoreCountChanging?.Invoke(_countEventsScore);
        }

        public void IncreaseTime(float time)
        {
            TimeChanging?.Invoke(time);
        }

        public void ResetPlayer()
        {
            _score = 0;
            _countEventsScore = 0;
            ScoreChanging?.Invoke(_score);
            ScoreCountChanging?.Invoke(_countEventsScore);
            _mover.ResetPlayer();
            _collisionHandler.ResetCollisoin();
        }

        public void Die()
        {
            GameOver?.Invoke();
        }

        public void CheckLevelCompletion()
        {
            if (CountEventsScore == MaxCountScore)
            {
                EffectsStarting?.Invoke();
                LevelCompleted?.Invoke();
                _progress.CountScore();
            }
        }

        public void TakeHit()
        {
            _mover.StopMove();
            BombExploding?.Invoke();
        }
    }
}