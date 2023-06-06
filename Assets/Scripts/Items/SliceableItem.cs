using System;
using UnityEngine;

namespace Izyplay.SliceItAll.Items
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider))]
    public sealed class SliceableItem : MonoBehaviour, ISlaceable
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private GameObject whole;
        [SerializeField] private GameObject sliced;

        public event Action OnSliced;

        private void Reset() => boxCollider = GetComponent<BoxCollider>();

        public void Slice()
        {
            whole.SetActive(false);
            sliced.SetActive(true);
            boxCollider.enabled = false;

            OnSliced?.Invoke();
        }
    }
}