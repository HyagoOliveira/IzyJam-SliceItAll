using UnityEngine;

namespace Izyplay.SliceItAll.Audios
{
    [CreateAssetMenu(fileName = "AudioClipCollection", menuName = "Izyplay/AudioClipCollection", order = 110)]
    public sealed class AudioClipCollection : ScriptableObject
    {
        [SerializeField, Tooltip("The Audio Clips. You can play them using theirs names.")]
        private AudioClip[] clips;

        /// <summary>
	    /// Gets a random audio clip.
	    /// </summary>
	    /// <returns>A random <see cref="AudioClip"/> instance.</returns>
	    public AudioClip GetRandomClip()
        {
            var index = Random.Range(0, clips.Length);
            return clips[index];
        }
    }
}