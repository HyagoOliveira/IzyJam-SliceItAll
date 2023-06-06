using UnityEngine;
using Izyplay.SliceItAll.Physics;

namespace Izyplay.SliceItAll.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerMotor : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private Rigidbody body;
        [SerializeField] private BoxDetector bladeDetector;
        [SerializeField] private LayerMask environment;

        private void Reset()
        {
            body = GetComponent<Rigidbody>();
            bladeDetector = GetComponentInChildren<BoxDetector>();

            SetupRigidbody();
        }

        private void OnEnable() => bladeDetector.OnHitChanged += HandleHitChanged;
        private void OnDisable() => bladeDetector.OnHitChanged -= HandleHitChanged;

        public void Jump()
        {
            EnablePhysics();
            StopVelocity();

            body.AddForce(settings.GetJumpVelocity(), ForceMode.Impulse);
            body.AddTorque(settings.GetTorqueVelocity());
        }

        private void StopVelocity() => body.velocity = Vector3.zero;

        private void EnablePhysics() => body.isKinematic = false;
        private void DisablePhysics() => body.isKinematic = true;

        private void SetupRigidbody()
        {
            DisablePhysics();
            body.constraints =
                RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ;
        }

        private void HandleHitChanged(Transform hit)
        {
            var isFromEnvironment = ContainLayer(hit.gameObject.layer, environment);
            if (!isFromEnvironment) return;

            DisablePhysics();
        }

        private static bool ContainLayer(LayerMask layer, LayerMask other) =>
            (layer & (1 << other)) != 0;
    }
}