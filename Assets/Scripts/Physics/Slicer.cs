using UnityEngine;

namespace Izyplay.SliceItAll.Physics
{
    [DisallowMultipleComponent]
    public sealed class Slicer : MonoBehaviour
    {
        [SerializeField] private BoxDetector detector;

        private void Reset() => detector = GetComponentInChildren<BoxDetector>();
        private void OnEnable() => detector.OnHitChanged += HandleHitChanged;
        private void OnDisable() => detector.OnHitChanged -= HandleHitChanged;

        private void HandleHitChanged(Transform hit)
        {
            var isSliceable = hit.TryGetComponent(out ISlaceable slaceable);
            if (isSliceable) slaceable.Slice();
        }
    }
}