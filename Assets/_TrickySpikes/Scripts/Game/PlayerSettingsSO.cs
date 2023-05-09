using UnityEngine;

namespace TrickySpikes {
    [CreateAssetMenu(menuName = "TrickySpikes/PlayerSettings")]
    public class PlayerSettingsSO : ScriptableObject {

        [SerializeField] private float speed;
        [SerializeField] private float minBoost;
        [SerializeField] private float maxBoost;

        public float Speed => speed;
        public float MinBoost => minBoost;
        public float MaxBoost => maxBoost;
    }
}
