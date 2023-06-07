using Izyplay.SliceItAll.Levels;
using UnityEngine;

namespace Izyplay.SliceItAll.Scores
{
    [DisallowMultipleComponent]
    public sealed class ScoreMultiplierTower : MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;

        private IEnable[] enables;
        private ISlaceable[] slaceables;

        private void Awake()
        {
            enables = GetComponentsInChildren<IEnable>();
            slaceables = GetComponentsInChildren<ISlaceable>();
        }

        private void OnEnable()
        {
            foreach (var slacebale in slaceables)
            {
                slacebale.OnSliced += HandleOnSliced;
            }
        }

        private void OnDisable()
        {
            foreach (var slacebale in slaceables)
            {
                slacebale.OnSliced -= HandleOnSliced;
            }
        }

        private void HandleOnSliced()
        {
            SetEnables(false);
            levelSettings.Finish();
        }

        private void SetEnables(bool enabled)
        {
            foreach (var enable in enables)
            {
                enable.SetEnabled(enabled);
            }
        }
    }
}