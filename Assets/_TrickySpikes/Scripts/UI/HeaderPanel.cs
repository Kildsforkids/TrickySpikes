using UnityEngine;

namespace TrickySpikes.UI {
    public class HeaderPanel : MonoBehaviour {

        [SerializeField] private ToggleButton soundMuteButton;

        private SoundSystem _soundSystem;

        private void Awake() {
            _soundSystem = Game.Instance.SoundSystem;
        }

        private void Start() {
            soundMuteButton.SetToggleState(!_soundSystem.IsMusicMute);
        }

        private void OnEnable() {
            soundMuteButton.Toggled += ToggleMute;
        }

        private void OnDisable() {
            soundMuteButton.Toggled -= ToggleMute;
        }

        private void ToggleMute() {
            _soundSystem.ToggleMute();
        }
    }
}
