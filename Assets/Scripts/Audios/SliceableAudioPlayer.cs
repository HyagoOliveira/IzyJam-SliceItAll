using UnityEngine;

namespace Izyplay.SliceItAll.Audios
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public sealed class SliceableAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClipCollection audioCollection;

        private ISlaceable slaceable;

        private void Reset() => audioSource = GetComponent<AudioSource>();
        private void Awake() => slaceable = GetComponent<ISlaceable>();
        private void OnEnable() => slaceable.OnSliced += HandleSliced;
        private void OnDisable() => slaceable.OnSliced -= HandleSliced;

        private void HandleSliced()
        {
            var clip = audioCollection.GetRandomClip();
            audioSource.PlayOneShot(clip);
        }
    }
}