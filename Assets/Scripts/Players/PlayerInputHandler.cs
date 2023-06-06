using UnityEngine;
using Izyplay.SliceItAll.Inputs;

namespace Izyplay.SliceItAll.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private InputSettings settings;
        [SerializeField] private PlayerMotor motor;

        private void Reset() => motor = GetComponent<PlayerMotor>();
        private void OnEnable() => settings.OnScreenTouched += motor.Jump;
        private void OnDisable() => settings.OnScreenTouched -= motor.Jump;
    }
}