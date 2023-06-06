using TMPro;
using UnityEngine;
using Izyplay.SliceItAll.Scores;

namespace Izyplay.SliceItAll.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animation))]
    public sealed class Score : MonoBehaviour
    {
        [SerializeField] private ScoreSettings settings;
        [SerializeField] private Animation anim;
        [SerializeField] private TMP_Text current;
        [SerializeField] private TMP_Text addition;
        [SerializeField] private string format = "F2";

        private void Reset() => anim = GetComponent<Animation>();

        private void OnEnable()
        {
            settings.OnScoreChanged += HandleScoreChanged;
            settings.OnScoreIncreased += HandleScoreIncreased;
        }

        private void OnDisable()
        {
            settings.OnScoreChanged -= HandleScoreChanged;
            settings.OnScoreIncreased -= HandleScoreIncreased;
        }

        private void HandleScoreChanged(float score) => current.text = score.ToString(format);

        private void HandleScoreIncreased(float increase)
        {
            addition.text = $"+{increase:F2}";
            anim.Play();
        }
    }
}