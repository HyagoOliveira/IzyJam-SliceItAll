using UnityEngine;
using Izyplay.SliceItAll.Levels;

namespace Izyplay.SliceItAll.UI
{
    [DisallowMultipleComponent]
    public sealed class CanvasManager : MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private GameObject score;
        [SerializeField] private GameObject startMessage;

        private void OnEnable()
        {
            levelSettings.OnLevelStarted += HandleLevelStarted;
            levelSettings.OnLevelFinished += HandleLevelFinished;
        }

        private void OnDisable()
        {
            levelSettings.OnLevelStarted -= HandleLevelStarted;
            levelSettings.OnLevelFinished -= HandleLevelFinished;
        }

        private void HandleLevelStarted()
        {
            score.SetActive(true);
            startMessage.SetActive(false);
        }

        private void HandleLevelFinished()
        {
            score.SetActive(false);
            startMessage.SetActive(true);
        }
    }
}