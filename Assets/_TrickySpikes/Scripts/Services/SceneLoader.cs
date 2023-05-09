using System;
using UnityEngine.SceneManagement;

namespace TrickySpikes {
    public class SceneLoader {

        public void LoadScene(string sceneName, Action loaded = null) {
            SceneManager.LoadScene(sceneName);
            loaded?.Invoke();
        }

        public void LoadMenu(Action loaded = null) {
            LoadScene("Menu", loaded);
        }

        public void LoadGame(Action loaded = null) {
            LoadScene("Game", loaded);
        }

        public void Restart() {
            LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
