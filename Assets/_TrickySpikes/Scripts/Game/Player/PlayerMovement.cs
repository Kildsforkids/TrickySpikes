using System.Collections;
using UnityEngine;

namespace TrickySpikes {
    public class PlayerMovement : MonoBehaviour {

        [SerializeField] private PlayerSettingsSO playerSettings;
        [SerializeField] private ParticleSystem trail;

        private Rigidbody2D _rigidbody;
        private float _boost;
        private Vector2 _targetPosition;
        private Coroutine _updateBoostCoroutine;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            _boost = playerSettings.MinBoost;
        }

        private void FixedUpdate() {
            var direction = (_targetPosition - _rigidbody.position).normalized;
            _rigidbody.MovePosition(_rigidbody.position + direction * playerSettings.Speed * _boost * Time.fixedDeltaTime);
        }

        public void Move(Vector2 targetPosition) {
            _targetPosition = targetPosition;
        }

        public void ActivateBoost() {
            if (_updateBoostCoroutine != null)
                StopCoroutine(_updateBoostCoroutine);
            trail.Play();
            _updateBoostCoroutine = StartCoroutine(IncreaseBoostCoroutine());
        }

        public void DeactivateBoost() {
            if (_updateBoostCoroutine != null)
                StopCoroutine(_updateBoostCoroutine);
            trail.Stop();
            _updateBoostCoroutine = StartCoroutine(DecreaseBoostCoroutine());
        }

        private IEnumerator IncreaseBoostCoroutine() {
            while (_boost < playerSettings.MaxBoost) {
                _boost += Time.deltaTime;
                yield return null;
            }
        }

        private IEnumerator DecreaseBoostCoroutine() {
            while (_boost > playerSettings.MinBoost) {
                _boost -= Time.deltaTime;
                yield return null;
            }
        }
    }
}
