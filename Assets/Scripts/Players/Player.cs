using UnityEngine;

namespace Izyplay.SliceItAll.Players
{
    [DisallowMultipleComponent]
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;

        [field: SerializeField] public Transform CameraFollow { get; private set; }

        private void Start() => settings.Initialize(this);
    }
}