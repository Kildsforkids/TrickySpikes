using UnityEngine;

namespace TrickySpikes {
    [CreateAssetMenu(menuName = "TrickySpikes/GameSettings")]
    public class GameSettingsSO : ScriptableObject, ISoundSettingsProvider {

        [Header("Sound")]
        [Range(0f, 1f)]
        [SerializeField] private float musicVolume;
        [SerializeField] private bool isMusicMute;

        public float MusicVolume {
            get => musicVolume;
            set => musicVolume = value;
        }

        public bool IsMusicMute {
            get => isMusicMute;
            set => isMusicMute = value;
        }
    }
}
