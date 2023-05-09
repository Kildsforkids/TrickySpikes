using UnityEngine;

namespace TrickySpikes {
    [ExecuteInEditMode]
    [RequireComponent(typeof(LineRenderer))]
    public class EdgeColiderVisualizer : MonoBehaviour {

        [SerializeField] private CircleEdgeCollider2D edgeCollider;

        private LineRenderer _lineRenderer;

        private void Awake() {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void UpdateLine() {
            UpdateLine(edgeCollider.EdgePoints);
        }

        private void UpdateLine(Vector2[] edgePoints) {
            Vector3[] linePoints = new Vector3[edgePoints.Length];
            for (int i = 0; i < edgePoints.Length; i++) {
                linePoints[i] = edgePoints[i];
            }
            _lineRenderer.positionCount = linePoints.Length;
            _lineRenderer.SetPositions(linePoints);
        }
    }
}
