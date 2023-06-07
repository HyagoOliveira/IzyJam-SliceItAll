using UnityEngine;
using Izyplay.SliceItAll.Audios;

namespace Izyplay.SliceItAll.Physics
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public sealed class Slicer : MonoBehaviour
    {
        [SerializeField] private BoxDetector detector;
        [SerializeField] private AudioClipCollection slicerClips;
        [SerializeField] private AudioSource audioSource;

        private void Reset()
        {
            audioSource = GetComponent<AudioSource>();
            detector = GetComponentInChildren<BoxDetector>();
        }

        private void OnEnable() => detector.OnHitChanged += HandleHitChanged;
        private void OnDisable() => detector.OnHitChanged -= HandleHitChanged;

        private void HandleHitChanged(Transform hit)
        {
            var isSliceable = hit.TryGetComponent(out ISlaceable slaceable);
            if (!isSliceable) return;

            slaceable.Slice();
            var clip = slicerClips.GetRandomClip();
            audioSource.PlayOneShot(clip);
        }
    }
}