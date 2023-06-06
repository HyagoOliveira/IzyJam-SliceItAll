using Cinemachine;
using UnityEngine;

namespace Izyplay.SliceItAll.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public sealed class AttachPlayerToVirtualCamera : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        private void Reset() => virtualCamera = GetComponent<CinemachineVirtualCamera>();
        private void OnEnable() => settings.OnPlayerInitialized += HandlePlayerInitialized;
        private void OnDisable() => settings.OnPlayerInitialized -= HandlePlayerInitialized;

        private void HandlePlayerInitialized(Player player) =>
            virtualCamera.Follow = player.CameraFollow;
    }
}