using UnityEngine;

namespace Izyplay.SliceItAll.Scores
{
    [DisallowMultipleComponent]
    public sealed class SlaceableScoreAdder : AbstractSlaceableScore
    {
        [SerializeField, Min(0f)] private float score = 10.5f;

        protected override void HandleOnSliced() => settings.Add(score);
    }
}