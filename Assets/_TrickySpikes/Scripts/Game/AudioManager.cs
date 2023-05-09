using UnityEngine;

namespace TrickySpikes {
    public class AudioManager : MonoBehaviour {

        [SerializeField] private AudioSource audioSource;

        private SoundSystem _soundSystem;

        private void Awake() {
            _soundSystem = Game.Instance.SoundSystem;
            DontDestroyOnLoad(this);
        }

        private void Start() {
            SetVolume(_soundSystem.MusicVolume);
            SetMusicMute(_soundSystem.IsMusicMute);
        }

        private void OnEnable() {
            _soundSystem.MusicMuteStateChanged += SetMusicMute;
            _soundSystem.MusicVolumeChanged += SetVolume;
        }

        private void OnDisable() {
            _soundSystem.MusicMuteStateChanged -= SetMusicMute;
            _soundSystem.MusicVolumeChanged -= SetVolume;
        }

        private void SetVolume(float value) {
            audioSource.volume = value;
        }

        private void SetMusicMute(bool state) {
            audioSource.mute = state;
        }
    }
}
