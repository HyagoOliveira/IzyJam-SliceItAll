using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Izyplay.SliceItAll.Inputs
{
    [CreateAssetMenu(fileName = "InputSettings", menuName = "Izyplay/InputSettings", order = 110)]
    public sealed class InputSettings : ScriptableObject
    {
        /// <summary>
        /// Action fired when a touch is made on the Screen, not been done on any UI Element.
        /// </summary>
        public event Action OnScreenTouched;

        internal void Update()
        {
            var hasTouched =
                HasMouseInput() ||
                HasKeyboardInput() ||
                HasScreenTouchInput();

            if (hasTouched) OnScreenTouched?.Invoke();
        }

        private bool HasMouseInput()
        {
            var hasMouseInput = Input.GetMouseButtonDown(0);
            var hasTouchedInAnyUI = EventSystem.current.IsPointerOverGameObject();

            return hasMouseInput && !hasTouchedInAnyUI;
        }

        private bool HasKeyboardInput() => Input.GetKeyDown(KeyCode.Space);

        private bool HasScreenTouchInput()
        {
            if (Input.touchCount == 0) return false;

            var touch = Input.GetTouch(0);
            var hasTouched = touch.phase == TouchPhase.Ended;
            var hasTouchedInAnyUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);

            return hasTouched && !hasTouchedInAnyUI;
        }
    }
}