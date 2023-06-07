using System;
using UnityEngine;

namespace Izyplay.SliceItAll.Scores
{
    [CreateAssetMenu(fileName = "ScoreSettings", menuName = "Izyplay/ScoreSettings", order = 110)]
    public sealed class ScoreSettings : ScriptableObject
    {
        public event Action<float> OnScoreIncreased;
        public event Action<float> OnScoreChanged;
        public event Action OnHighestScoreReached;

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

        private const string highestScoreKey = "HighestScore";


        internal void Initialize() => Score = 0f;

        public void Add(float value)
        {
            Score += value;
            OnScoreIncreased?.Invoke(value);
        }

        public void Multiply(float multiplier)
        {
            multiplier = Mathf.Max(multiplier - 1F, 1F);
            var addition = Score * multiplier;
            Add(addition);
        }

        public void TrySaveHighestScore()
        {
            var highestScore = PlayerPrefs.GetFloat(highestScoreKey, defaultValue: 0F);
            var isNewHighestScore = Score > highestScore;

            if (!isNewHighestScore) return;

            PlayerPrefs.SetFloat(highestScoreKey, Score);
            PlayerPrefs.Save();

            OnHighestScoreReached?.Invoke();
        }

        [ContextMenu("Erase Highest Score")]
        private void EraseHighestScore()
        {
            PlayerPrefs.DeleteKey(highestScoreKey);
            Debug.Log("Highest Score was erased");
        }
    }
}