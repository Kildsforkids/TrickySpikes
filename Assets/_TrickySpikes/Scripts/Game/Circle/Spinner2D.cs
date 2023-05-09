using UnityEngine;

namespace TrickySpikes {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Spinner2D : MonoBehaviour, IPausable {

        [SerializeField] private float spinSpeed;
        [SerializeField] private float spinSpeedCoefficient;
        [SerializeField] private bool isClockwise;

        public PauseManager PauseManager => Game.Instance.PauseManager;

        private Rigidbody2D _rigidbody;
        private float _angle = 0f;
        private bool _isActive = true;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody2D>();
            PauseManager.Register(this);
        }

        private void Update() {
            if (_isActive) {
                Spin();
            }
        }

        public void SetSpinSpeed(float speed) {
            spinSpeed = speed;
        }

        public void SetSpinSpeedCoefficient(float coefficient) {
            spinSpeedCoefficient = coefficient;
        }

        public void ToggleSpinDirection() => SetSpinDirection(!isClockwise);

        public void Pause() {
            _isActive = false;
        }

        public void Resume() {
            _isActive = true;
        }

        private void SetSpinDirection(bool isClockwise) => this.isClockwise = isClockwise;

        private void Spin() {
            _rigidbody.MoveRotation(_angle);
            float rotation = spinSpeed * spinSpeedCoefficient * Time.deltaTime;

            if (isClockwise) {
                _angle -= rotation;
                if (_angle < 1f) {
                    _angle = 360f;
                }
            } else {
                _angle += rotation;
                if (_angle > 359f) {
                    _angle = 0f;
                }
            }
        }
    }
}
