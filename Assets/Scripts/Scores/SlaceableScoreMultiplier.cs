using UnityEngine;

namespace Izyplay.SliceItAll.Scores
{
    [DisallowMultipleComponent]
    public sealed class SlaceableScoreMultiplier : AbstractSlaceableScore
    {
        [SerializeField, Min(0)] private int multiplier = 1;

        protected override void HandleOnSliced() => settings.Multiply(multiplier);
    }
}