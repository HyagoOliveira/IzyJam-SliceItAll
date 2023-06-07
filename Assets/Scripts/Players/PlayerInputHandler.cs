using UnityEngine;
using Izyplay.SliceItAll.Inputs;
using Izyplay.SliceItAll.Levels;

namespace Izyplay.SliceItAll.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private InputSettings settings;
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private PlayerMotor motor;

        private void Reset() => motor = GetComponent<PlayerMotor>();

        private void OnEnable()
        {
            settings.OnScreenTouched += motor.Jump;
            levelSettings.OnLevelFinished += HandleLevelFinished;
        }

        private void OnDisable()
        {
            settings.OnScreenTouched -= motor.Jump;
            levelSettings.OnLevelFinished -= HandleLevelFinished;
        }

        private void HandleLevelFinished() => enabled = false;
    }
}