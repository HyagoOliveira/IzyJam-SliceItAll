using UnityEngine;
using Izyplay.SliceItAll.Inputs;

namespace Izyplay.SliceItAll.Levels
{
    [DisallowMultipleComponent]
    public sealed class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelSettings settings;
        [SerializeField] private InputSettings inputSettings;

        private void OnEnable()
        {
            ListenForScreenTouch();
            settings.OnLevelFinished += HandleLevelFinished;
        }

        private void OnDisable()
        {
            UnlistenForScreenTouch();
            settings.OnLevelFinished -= HandleLevelFinished;
        }

        private void HandleLevelFinished() => ListenForScreenTouch();

        private void HandleScreenTouched()
        {
            settings.Start();
            UnlistenForScreenTouch();
        }

        private void ListenForScreenTouch() => inputSettings.OnScreenTouched += HandleScreenTouched;
        private void UnlistenForScreenTouch() => inputSettings.OnScreenTouched -= HandleScreenTouched;
    }
}