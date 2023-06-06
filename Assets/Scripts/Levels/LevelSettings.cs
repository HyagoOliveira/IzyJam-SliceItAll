using System;
using UnityEngine;

namespace Izyplay.SliceItAll.Levels
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Izyplay/LevelSettings", order = 110)]
    public sealed class LevelSettings : ScriptableObject
    {
        public event Action OnLevelStarted;
        public event Action OnLevelFinished;

        public void Start() => OnLevelStarted?.Invoke();
        public void Finish() => OnLevelFinished?.Invoke();
    }
}