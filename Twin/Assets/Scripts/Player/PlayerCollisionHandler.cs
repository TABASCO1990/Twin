using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerCollisionHandler : MonoBehaviour
    {
        [SerializeField] private Levels.Locations _location;
        [SerializeField] private Levels.Stage _level;
        [SerializeField] private ParticleSystem _targetPartical;
        [SerializeField] private ParticleSystem _bombPartical;

        [Header("Audio")]
        [SerializeField] private AudioClip _audioScore;
        [SerializeField] private AudioClip _audioDie;
        [SerializeField] private AudioClip _audioBomb;
        [SerializeField] private AudioClip _audioBonusTime;

        private Player _player;
        private AudioSource _audioSource;
        private float _heightParticalTarget = 2;
        private float _heightParticalBomb = 0.5f;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void ResetCollisoin()
        {
            _level = _location.GetStage();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Shared.Target target))
            {
                _player.IncreaseScore(target.Score);
                _level.GetComponent<Levels.PlayerColor>().SetColor();
                _level.GetComponent<Levels.ObstacleColor>().SetColor();
                _level.SetLevel();
                _level.GetComponentInChildren<Shared.Plant>().RemoveTile();
                _targetPartical.gameObject.transform.position = new Vector3(target.transform.position.x, _heightParticalTarget, target.transform.position.z);
                _targetPartical.Play();
                _audioSource.PlayOneShot(_audioScore);
            }
            else if (other.TryGetComponent(out Shared.Water water))
            {
                _player.Die();
                _audioSource.PlayOneShot(_audioDie);
            }
            else if (other.TryGetComponent(out Shared.Bomb bomb))
            {
                _bombPartical.gameObject.transform.position = new Vector3(bomb.transform.position.x, _heightParticalBomb, bomb.transform.position.z);
                _bombPartical.Play();
                _audioSource.PlayOneShot(_audioBomb);
            }
            else
            {
                _audioSource.PlayOneShot(_audioBonusTime);
            }
        }
    }
}