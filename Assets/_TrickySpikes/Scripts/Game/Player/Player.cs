using UnityEngine;
using UnityEngine.Events;

namespace TrickySpikes {
    public class Player : MonoBehaviour {

        [SerializeField] private PlayerMovement movement;

        public UnityEvent OnDie;

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                movement.ActivateBoost();
            } else if (Input.GetMouseButtonUp(0)) {
                movement.DeactivateBoost();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.TryGetComponent(out IObstacle obstacle)) {
                obstacle.OnPlayerCollide(this);
            }
        }

        public void Init(Bootstrap game) {
            OnDie.AddListener(game.GameOver);
        }

        public void Move(Vector2 targetPosition) {
            movement.Move(targetPosition);
        }

        public void TakeDamage() {
            Die();
        }

        private void Die() {
            OnDie?.Invoke();
            OnDie.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}
