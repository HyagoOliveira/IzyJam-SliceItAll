using UnityEngine;

namespace Izyplay.SliceItAll.Players
{
    [DisallowMultipleComponent]
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;

        private void Start() => settings.Initialize(this);
    }
}