using System;

namespace TrickySpikes {
    public class SoundSystem {

        public Action<float> MusicVolumeChanged;
        public Action<bool> MusicMuteStateChanged;

        public float MusicVolume {
            get => _musicVolume;
            set {
                _musicVolume = value;
                MusicVolumeChanged?.Invoke(value);
            }
        }

        public bool IsMusicMute {
            get => _isMusicMute;
            set {
                _isMusicMute = value;
                MusicMuteStateChanged?.Invoke(value);
            }
        }

        private float _musicVolume;
        private bool _isMusicMute;

        public SoundSystem(ISoundSettingsProvider settings) {
            _musicVolume = settings.MusicVolume;
            _isMusicMute = settings.IsMusicMute;
        }

        public void ToggleMute() {
            IsMusicMute = !IsMusicMute;
        }
    }
}
