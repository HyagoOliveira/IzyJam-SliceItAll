using UnityEngine;

namespace Izyplay.SliceItAll
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public sealed class ColliderEnabler : MonoBehaviour, IEnable
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        [SerializeField] private Collider collider;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        private void Reset() => collider = GetComponent<Collider>();

        public void SetEnabled(bool enabled) => collider.enabled = enabled;
    }
}