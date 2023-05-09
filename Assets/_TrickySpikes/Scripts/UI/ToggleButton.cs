using System;
using UnityEngine;
using UnityEngine.UI;

namespace TrickySpikes.UI {
    [RequireComponent(typeof(Button))]
    public class ToggleButton : MonoBehaviour {

        [SerializeField] private Image sourceImage;
        [SerializeField] private Sprite toggleOnImage;
        [SerializeField] private Sprite toggleOffImage;

        public Action Toggled;

        private Button _button;
        private bool _isToggleOn;

        private void Awake() {
            _button = GetComponent<Button>();
        }

        private void OnEnable() {
            _button.onClick.AddListener(Toggle);
        }

        private void OnDisable() {
            _button.onClick.RemoveListener(Toggle);
        }

        public void SetToggleState(bool state) {
            _isToggleOn = state;
            if (_isToggleOn) {
                sourceImage.sprite = toggleOnImage;
            } else {
                sourceImage.sprite = toggleOffImage;
            }
        }

        private void Toggle() {
            _isToggleOn = !_isToggleOn;
            SetToggleState(_isToggleOn);
            Toggled?.Invoke();
        }
    }
}
