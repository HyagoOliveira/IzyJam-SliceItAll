using System;
using UnityEngine;
using Izyplay.SliceItAll.Scores;

namespace Izyplay.SliceItAll.Levels
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Izyplay/LevelSettings", order = 110)]
    public sealed class LevelSettings : ScriptableObject
    {
        [SerializeField] private ScoreSettings score;

        public event Action OnLevelStarted;
        public event Action OnLevelFinished;

        public void Start()
        {
            score.Initialize();
            OnLevelStarted?.Invoke();
        }

        public void Finish() => OnLevelFinished?.Invoke();
    }
}