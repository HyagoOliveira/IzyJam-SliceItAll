using System;
using UnityEngine;

namespace Izyplay.SliceItAll
{
    [CreateAssetMenu(fileName = "ScoreSettings", menuName = "Izyplay/ScoreSettings", order = 110)]
    public sealed class ScoreSettings : ScriptableObject
    {
        public event Action<float> OnScoreIncreased;
        public event Action<float> OnScoreChanged;

        public float Score
        {
            get => score;
            private set
            {
                score = value;
                OnScoreChanged?.Invoke(score);
            }
        }

        private float score;

        internal void Initialize() => Score = 0f;

        public void AddScore(float value)
        {
            Score += value;
            OnScoreIncreased?.Invoke(value);
        }

        public void Multiply(int multiplier)
        {
            var toAdd = Score - multiplier * Score;
            toAdd = Mathf.Max(toAdd, 0f);
            AddScore(toAdd);
        }
    }
}