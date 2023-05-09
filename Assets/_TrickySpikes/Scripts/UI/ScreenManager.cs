using UnityEngine;

namespace TrickySpikes.UI {
    public abstract class ScreenManager : MonoBehaviour {

        private Screen _activeScreen;

        public void EnableScreen(Screen screen) {
            _activeScreen?.Hide();
            screen.Show();
            _activeScreen = screen;
        }
    }
}
