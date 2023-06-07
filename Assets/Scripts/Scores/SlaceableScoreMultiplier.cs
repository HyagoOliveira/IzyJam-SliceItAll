using TMPro;
using UnityEngine;

namespace Izyplay.SliceItAll.Scores
{
    [DisallowMultipleComponent]
    public sealed class SlaceableScoreMultiplier : AbstractSlaceableScore
    {
        [SerializeField, Min(1F)] private float multiplier = 1F;
        [SerializeField] private TMP_Text multiplierText;

        private void Reset() => multiplierText = GetComponentInChildren<TMP_Text>();

        protected override void HandleOnSliced() => settings.Multiply(multiplier);

        private void OnValidate()
        {
            if (multiplierText == null) return;
            multiplierText.text = multiplier.ToString();
        }
    }
}