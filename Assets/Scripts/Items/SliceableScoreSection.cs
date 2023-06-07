using System;
using UnityEngine;

namespace Izyplay.SliceItAll.Items
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider))]
    public sealed class SliceableScoreSection : MonoBehaviour, ISlaceable
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color slicedColor = Color.red;

        public event Action OnSliced;

        private void Reset()
        {
            boxCollider = GetComponent<BoxCollider>();
            meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        public void Slice()
        {
            boxCollider.enabled = false;
            meshRenderer.material.color = slicedColor;

            OnSliced?.Invoke();
        }
    }
}