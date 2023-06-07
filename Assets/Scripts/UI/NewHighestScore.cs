using UnityEngine;
using Izyplay.SliceItAll.Scores;

namespace Izyplay.SliceItAll.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Canvas))]
    public sealed class NewHighestScore : MonoBehaviour
    {
        [SerializeField] private ScoreSettings settings;
        [SerializeField] private Canvas canvas;

        private void Reset() => canvas = GetComponent<Canvas>();
        private void Awake() => canvas.enabled = false;
        private void OnEnable() => settings.OnHighestScoreReached += HandleOnHighestScoreReached;
        private void OnDisable() => settings.OnHighestScoreReached -= HandleOnHighestScoreReached;

        private void HandleOnHighestScoreReached() => canvas.enabled = true;
    }
}