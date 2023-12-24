using System;

namespace Player
{
    [System.Serializable]
    public class PlayerInfo
    {
        private int[] _scores;
        private int _countActiveStages;
        private bool _isMusic;
        private bool _isEffects = true;

        public int[] Scores
        {
            get => _scores;
            set => _scores = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int CountActiveStages
        {
            get => _countActiveStages;
            set => _countActiveStages = value > 0 ? value : _countActiveStages;
        }
        public bool IsMusic
        { 
            get => _isMusic;
            set => _isMusic = value;
        }

        public bool IsEffects
        { 
            get => _isEffects;
            set => _isEffects = value;
        }
    }
}