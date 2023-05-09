using System;
using UnityEngine;
using UnityEngine.UI;

namespace TrickySpikes.UI {
    public class SettingsScreen : Screen {

        [SerializeField] private Button backButton;
        [SerializeField] private Slider soundSlider;

        public Action BackButtonPressed;

        private SoundSystem _soundSystem;

        private void Awake() {
            _soundSystem = Game.Instance.SoundSystem;
        }

        private void Start() {
            soundSlider.value = _soundSystem.MusicVolume;
        }

        private void OnEnable() {
            backButton.onClick.AddListener(Back);
            soundSlider.onValueChanged.AddListener(SetVolume);
        }

        private void OnDisable() {
            backButton.onClick.RemoveListener(Back);
            soundSlider.onValueChanged.RemoveListener(SetVolume);
        }

        private void Back() {
            BackButtonPressed?.Invoke();
        }

        private void SetVolume(float value) {
            _soundSystem.MusicVolume = value;
        }
    }
}
