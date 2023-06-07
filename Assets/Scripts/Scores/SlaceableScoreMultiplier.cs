using TMPro;
using UnityEngine;

namespace Izyplay.SliceItAll.Scores
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider))]
    public sealed class SlaceableScoreMultiplier : AbstractSlaceableScore
    {
        [SerializeField, Min(1F)] private float multiplier = 1F;
        [SerializeField, Min(0F)] private float height = 1F;
        [SerializeField] private TMP_Text multiplierText;
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private Transform cube;

        private void Reset()
        {
            multiplierText = GetComponentInChildren<TMP_Text>();
            boxCollider = GetComponent<BoxCollider>();
            cube = transform.Find("Cube");
        }

        protected override void HandleOnSliced() => settings.Multiply(multiplier);

        private void OnValidate()
        {
            if (multiplierText)
            {
                var rect = multiplierText.GetComponent<RectTransform>();
                var sizeDelta = rect.sizeDelta;

                sizeDelta.y = height;
                multiplierText.text = $"{multiplier}X";

                rect.sizeDelta = sizeDelta;
            }

            if (cube)
            {
                var scale = cube.localScale;
                scale.y = height;
                cube.localScale = scale;
            }

            var size = boxCollider.size;
            size.y = height;
            boxCollider.size = size;
        }
    }
}