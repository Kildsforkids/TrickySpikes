using System.Collections;
using UnityEngine;

namespace TrickySpikes {
    public class Scaler : MonoBehaviour {

        private IEnumerator Start() {
            float t = 0f;
            var targetScale = transform.localScale;
            float initialScale = 0.1f;
            while (t < 1f) {
                t += Time.deltaTime;
                transform.localScale = Vector3.Lerp(targetScale * initialScale, targetScale, t);
                yield return null;
            }
        }
    }
}
