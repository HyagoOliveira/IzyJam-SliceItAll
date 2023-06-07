using UnityEngine;
using Izyplay.SliceItAll.Physics;

namespace Izyplay.SliceItAll.Audios
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public sealed class SlicerAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClipCollection audioCollection;
        [SerializeField] private BoxDetector detector;

        private void Reset()
        {
            audioSource = GetComponent<AudioSource>();
            detector = GetComponentInChildren<BoxDetector>();
        }

        private void OnEnable() => detector.OnHitChanged += HandleHandleHitChanged;
        private void OnDisable() => detector.OnHitChanged -= HandleHandleHitChanged;

        private void HandleHandleHitChanged(Transform _)
        {
            var clip = audioCollection.GetRandomClip();
            audioSource.PlayOneShot(clip);
        }
    }
}