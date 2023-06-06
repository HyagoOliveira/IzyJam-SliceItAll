using UnityEngine;

namespace Izyplay.SliceItAll.Inputs
{
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-1)]
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField] private InputSettings settings;

        private static bool hasInitialized;

        private void Awake()
        {
            if (hasInitialized)
            {
                DestroyImmediate(gameObject);
                return;
            }

            hasInitialized = true;
            DontDestroyOnLoad(gameObject);
        }

        private void Update() => settings.Update();
    }
}