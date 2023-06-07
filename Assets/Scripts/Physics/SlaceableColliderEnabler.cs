using UnityEngine;

namespace Izyplay.SliceItAll
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public sealed class SlaceableColliderEnabler : MonoBehaviour, IEnable
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        [SerializeField] private Collider collider;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        private ISlaceable slaceable;

        private void Reset() => collider = GetComponent<Collider>();
        private void Awake() => slaceable = GetComponent<ISlaceable>();

        private void OnEnable() => slaceable.OnSliced += HandleOnSliced;
        private void OnDisable() => slaceable.OnSliced -= HandleOnSliced;

        public void SetEnabled(bool enabled) => collider.enabled = enabled;

        private void HandleOnSliced() => SetEnabled(false);
    }
}