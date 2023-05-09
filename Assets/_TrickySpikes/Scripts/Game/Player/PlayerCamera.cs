using System.Collections;
using UnityEngine;

namespace TrickySpikes {
    [RequireComponent(typeof(Camera))]
    public class PlayerCamera : MonoBehaviour {

        private Camera _camera;
        private Coroutine _colorChangeCoroutine;

        private void Awake() {
            _camera = GetComponent<Camera>();
        }

        public void ChangeBackgroundColor() {
            if (_colorChangeCoroutine != null) {
                StopCoroutine(_colorChangeCoroutine);
            }
            StartCoroutine(ChangeBackgroundColorCoroutine(_camera));
        }

        private IEnumerator ChangeBackgroundColorCoroutine(Camera camera) {
            float t = 0f;
            var oldColor = camera.backgroundColor;
            var newColor = Random.ColorHSV(0f, 1f, 0.9f, 0.9f, 0.6f, 0.6f);
            while (t < 1f) {
                t += Time.deltaTime;
                camera.backgroundColor = Color.Lerp(oldColor, newColor, t);
                yield return null;
            }
        }
    }
}
