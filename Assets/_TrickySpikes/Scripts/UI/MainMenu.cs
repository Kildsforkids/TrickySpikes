using UnityEngine;

namespace TrickySpikes.UI {
    public class MainMenu : MonoBehaviour {

        [SerializeField] private MenuScreen menuScreen;
        [SerializeField] private SettingsScreen settingsScreen;

        private Screen _activeScreen;

        public void Start() {
            EnableScreen(menuScreen);
        }

        private void OnEnable() {
            menuScreen.OnSettingsShow += EnableSettingsScreen;
            settingsScreen.BackButtonPressed += EnableMenuScreen;
        }

        private void OnDisable() {
            menuScreen.OnSettingsShow -= EnableSettingsScreen;
            settingsScreen.BackButtonPressed -= EnableMenuScreen;
        }

        public void EnableScreen(Screen screen) {
            _activeScreen?.Hide();
            screen.Show();
            _activeScreen = screen;
        }

        private void EnableSettingsScreen() {
            EnableScreen(settingsScreen);
        }

        private void EnableMenuScreen() {
            EnableScreen(menuScreen);
        }
    }
}
