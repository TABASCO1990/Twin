using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Player))]
    public class Effects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _confettiPartical;
        [SerializeField] private AnimatorExtension _animatorExtension;

        private Player _player;
        private string _nameAnimation = "_isRunning";

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            _player.EffectsStarting += OnEffectsStarting;
        }

        private void OnDisable()
        {
            _player.EffectsStarting -= OnEffectsStarting;
        }

        private void OnEffectsStarting()
        {
            _confettiPartical.Play();
            _animatorExtension.SetBoolFalse(_nameAnimation);
        }
    }
}