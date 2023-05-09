using UnityEngine;

namespace TrickySpikes {
    public class CircleSpinner : Spinner2D {

        [SerializeField] private CircleSettingsSO circleSettings;

        private void Start() {
            SetSpinSpeed(circleSettings.SpinSpeed);
            SetSpinSpeedCoefficient(circleSettings.SpinSpeedCoefficient);
        }

        public void SetRandomSpinSpeed() {
            SetSpinSpeedCoefficient(Random.Range(circleSettings.MinSpinSpeedCoefficient, circleSettings.MaxSpinSpeedCoefficient));
        }
    }
}
