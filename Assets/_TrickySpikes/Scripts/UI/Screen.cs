using UnityEngine;

namespace TrickySpikes.UI {
    public class Screen : MonoBehaviour {

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}
