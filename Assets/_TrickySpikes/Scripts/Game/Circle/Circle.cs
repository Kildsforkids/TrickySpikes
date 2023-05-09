using TrickySpikes.Utils;
using UnityEngine;

namespace TrickySpikes {
    public class Circle : MonoBehaviour, IObstacle {

        [SerializeField] private CircleEdgeCollider2D edgeCollider;

        public Vector2 CircleCenter => transform.position;
        public float Radius => edgeCollider.Radius;

        private float _lastPointAngle;

        public void OnPlayerCollide(Player player) {
            var position = SetRandomTargetPosition(_lastPointAngle);
            player.Move(position);
        }

        public Transform Spawn(GameObject prefab, float angle) {
            var position = CircleUtils.GetPositionOnCircleEdge(CircleCenter, Radius, angle);
            var spike = Instantiate(prefab, position, Quaternion.identity, transform).transform;
            spike.up = (CircleCenter - position).normalized;
            return spike;
        }

        public Vector2 SetRandomTargetPosition(float lastPointAngle) {
            var position = CircleUtils.GetRandomPositionFromAngle(
                CircleCenter,
                Radius,
                lastPointAngle,
                90f,
                out float randomAngle
            );
            _lastPointAngle = randomAngle;
            return position;
        }
    }
}

