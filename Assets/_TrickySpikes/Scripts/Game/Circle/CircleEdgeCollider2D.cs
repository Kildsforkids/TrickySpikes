using UnityEngine;
using UnityEngine.Events;

namespace TrickySpikes {
    [ExecuteInEditMode]
    [RequireComponent(typeof(EdgeCollider2D))]
    public class CircleEdgeCollider2D : MonoBehaviour {

        [SerializeField] private CircleSettingsSO circleSettings;

        public UnityEvent OnCircleUpdate;

        public float Radius => circleSettings.Radius;
        public int Points => circleSettings.Points;
        public Vector2[] EdgePoints => _edgePoints;

        private EdgeCollider2D _edgeCollider;
        private float _currentRadius;
        private Vector2[] _edgePoints = new Vector2[0];

        private void Awake() {
            _edgeCollider = GetComponent<EdgeCollider2D>();
        }

        private void Start() {
            CreateCircle();
        }

        private void Update() {
            if (Points != _edgeCollider.pointCount || _currentRadius != Radius) {
                CreateCircle();
            }
        }

        private void CreateCircle() {
            _edgePoints = new Vector2[Points + 1];

            for (int i = 0; i <= Points; i++) {
                float angle = Mathf.PI * 2f / Points * i;
                _edgePoints[i] = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
            }

            _edgeCollider.points = _edgePoints;
            _currentRadius = Radius;

            OnCircleUpdate?.Invoke();
        }
    }
}

