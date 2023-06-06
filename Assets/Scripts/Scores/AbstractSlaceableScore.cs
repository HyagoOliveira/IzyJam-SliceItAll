using UnityEngine;

namespace Izyplay.SliceItAll.Scores
{
    public abstract class AbstractSlaceableScore : MonoBehaviour
    {
        [SerializeField] protected ScoreSettings settings;

        private ISlaceable slaceable;

        private void Awake() => slaceable = GetComponent<ISlaceable>();
        private void OnEnable() => slaceable.OnSliced += HandleOnSliced;
        private void OnDisable() => slaceable.OnSliced -= HandleOnSliced;

        protected abstract void HandleOnSliced();
    }
}