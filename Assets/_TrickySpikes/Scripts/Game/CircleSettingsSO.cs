using UnityEngine;

namespace TrickySpikes {
    [CreateAssetMenu(menuName = "TrickySpikes/CircleSettings")]
    public class CircleSettingsSO : ScriptableObject {

        [SerializeField] private float radius;
        [SerializeField] private int points;
        [SerializeField] private float spinSpeed;
        [SerializeField] private float spinSpeedCoefficient;
        [SerializeField] private float minSpinSpeedCoefficient;
        [SerializeField] private float maxSpinSpeedCoefficient;

        private void OnValidate() {
            spinSpeedCoefficient = Mathf.Clamp(spinSpeedCoefficient, minSpinSpeedCoefficient, maxSpinSpeedCoefficient);
        }

        public float Radius => radius;
        public int Points => points;
        public float SpinSpeed => spinSpeed;
        public float SpinSpeedCoefficient => spinSpeedCoefficient;
        public float MinSpinSpeedCoefficient => minSpinSpeedCoefficient;
        public float MaxSpinSpeedCoefficient => maxSpinSpeedCoefficient;
    }
}
