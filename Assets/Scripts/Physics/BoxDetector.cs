using System;
using UnityEngine;

namespace Izyplay.SliceItAll.Physics
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider))]
    public sealed class BoxDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask layers;
        [SerializeField] private BoxCollider boxCollider;

        public event Action<Transform> OnHitChanged;

        private Transform lastHit;

        private readonly Collider[] buffer = new Collider[1];

        private void Reset() => boxCollider = GetComponent<BoxCollider>();

        private void Update() => CheckHit();

        private void CheckHit()
        {
            var bounds = boxCollider.bounds;
            var overlapCount = UnityEngine.Physics.OverlapBoxNonAlloc(
                bounds.center,
                bounds.extents,
                buffer,
                transform.localRotation,
                layers,
                QueryTriggerInteraction.Ignore
            );

            var hasHit = overlapCount > 0;
            if (!hasHit)
            {
                lastHit = null;
                return;
            }

            var currentHit = buffer[0].transform;
            var hasHitChanged = currentHit != lastHit;

            if (hasHitChanged)
            {
                OnHitChanged?.Invoke(currentHit);
                lastHit = currentHit;
            }
        }
    }
}