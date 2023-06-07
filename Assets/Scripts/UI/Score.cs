using TMPro;
using UnityEngine;
using Izyplay.SliceItAll.Scores;

namespace Izyplay.SliceItAll.UI
{
    [DisallowMultipleComponent]
    public sealed class Score : MonoBehaviour
    {
        [SerializeField] private ScoreSettings settings;
        [SerializeField] private TMP_Text value;

        private void Reset() => value = GetComponent<TMP_Text>();
        private void OnEnable() => settings.OnScoreChanged += HandleScoreChanged;
        private void OnDisable() => settings.OnScoreChanged -= HandleScoreChanged;

        private void HandleScoreChanged(float score) => value.text = score.ToString();
    }
}