using UnityEngine;
using Izyplay.SliceItAll.Levels;
using System.Collections;

namespace Izyplay.SliceItAll.UI
{
    [DisallowMultipleComponent]
    public sealed class CanvasManager : MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private Canvas score;
        [SerializeField] private Canvas startMessage;
        [SerializeField] private Canvas finalPanel;

        [Header("Timers")]
        [SerializeField, Min(0f)] private float timeUntilShowFinalPanel = 2f;
        [SerializeField, Min(0f)] private float timeShowingFinalPanel = 5f;

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
            score.enabled = true;
            startMessage.enabled = false;
            finalPanel.enabled = false;
        }

        private void HandleLevelFinished()
        {
            startMessage.enabled = false;
            StartCoroutine(FinalPanelCoroutine());
        }

        private IEnumerator FinalPanelCoroutine()
        {
            yield return new WaitForSeconds(timeUntilShowFinalPanel);

            score.enabled = false;
            finalPanel.enabled = true;

            yield return new WaitForSeconds(timeShowingFinalPanel);
            levelSettings.ResetLevel();
        }
    }
}