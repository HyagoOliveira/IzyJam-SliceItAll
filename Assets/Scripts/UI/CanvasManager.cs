using UnityEngine;
using Izyplay.SliceItAll.Levels;
using System.Collections;

namespace Izyplay.SliceItAll.UI
{
    [DisallowMultipleComponent]
    public sealed class CanvasManager : MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private GameObject score;
        [SerializeField] private GameObject startMessage;
        [SerializeField] private GameObject finalPanel;

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
            score.SetActive(true);
            startMessage.SetActive(false);
            finalPanel.SetActive(false);
        }

        private void HandleLevelFinished()
        {
            score.SetActive(false);
            startMessage.SetActive(false);
            StartCoroutine(FinalPanelCoroutine());
        }

        private IEnumerator FinalPanelCoroutine()
        {
            yield return new WaitForSeconds(timeUntilShowFinalPanel);
            finalPanel.SetActive(true);

            yield return new WaitForSeconds(timeShowingFinalPanel);
            levelSettings.ResetLevel();
        }
    }
}