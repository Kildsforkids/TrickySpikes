using UnityEngine;

namespace TrickySpikes {
    public class Singleton<T> : MonoBehaviour where T : Component {

        public static T Instance { get; private set; }

        private void Awake() {
            if (Instance == null) {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
}
