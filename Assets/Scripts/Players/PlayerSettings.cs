using System;
using UnityEngine;

namespace Izyplay.SliceItAll.Players
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Izyplay/PlayerSettings", order = 110)]
    public sealed class PlayerSettings : ScriptableObject
    {
        [SerializeField, Min(0f)] private float jumpForce = 5f;
        [SerializeField] private float torqueForce = 25f;
        [SerializeField] private Vector3 jumpDirection = new Vector3(0f, 1f, 1F);

        /// <summary>
        /// Action fired when the Player is initialized.
        /// </summary>
        public event Action<Player> OnPlayerInitialized;

        public Player Player { get; private set; }

        public Vector3 GetTorqueVelocity() => Vector3.right * torqueForce;
        public Vector3 GetJumpVelocity() => jumpDirection.normalized * jumpForce;

        internal void Initialize(Player player)
        {
            Player = player;
            OnPlayerInitialized?.Invoke(Player);
        }

        //TODO: add function to set fields using Remote Config.
    }
}