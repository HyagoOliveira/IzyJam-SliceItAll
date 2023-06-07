using System;
using UnityEngine;

namespace Izyplay.SliceItAll.Items
{
    [DisallowMultipleComponent]
    public sealed class SliceableScoreSection : MonoBehaviour, ISlaceable
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color slicedColor = Color.red;

        public event Action OnSliced;

        private void Reset() => meshRenderer = GetComponentInChildren<MeshRenderer>();

        public void Slice()
        {
            meshRenderer.material.color = slicedColor;
            OnSliced?.Invoke();
        }
    }
}