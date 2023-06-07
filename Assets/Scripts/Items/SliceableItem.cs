using System;
using UnityEngine;

namespace Izyplay.SliceItAll.Items
{
    [DisallowMultipleComponent]
    public sealed class SliceableItem : MonoBehaviour, ISlaceable
    {
        [SerializeField] private GameObject whole;
        [SerializeField] private GameObject sliced;

        public event Action OnSliced;

        public void Slice()
        {
            whole.SetActive(false);
            sliced.SetActive(true);

            OnSliced?.Invoke();
        }
    }
}