using TMPro;
using UnityEngine;
using Izyplay.SliceItAll.Scores;

namespace Izyplay.SliceItAll.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animation))]
    public sealed class ScoreAddition : MonoBehaviour
    {
        [SerializeField] private ScoreSettings settings;
        [SerializeField] private Animation anim;
        [SerializeField] private TMP_Text value;

        private void Reset() => anim = GetComponent<Animation>();
        private void OnEnable() => settings.OnScoreIncreased += HandleScoreIncreased;
        private void OnDisable() => settings.OnScoreIncreased -= HandleScoreIncreased;

        private void HandleScoreIncreased(float increase)
        {
            value.text = $"+ {increase}";

            anim.Stop();
            anim.Play();
        }
    }
}