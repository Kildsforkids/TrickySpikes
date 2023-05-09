using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TrickySpikes.UI {
    public class MenuScreen : Screen {

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;

        public Action OnSettingsShow;

        private Game _game;
        private Score _score;
        private SceneLoader _sceneLoader;

        private void Awake() {
            _game = Game.Instance;
            _score = _game.Score;
            _sceneLoader = _game.SceneLoader;
        }

        private void Start() {
            UpdateScoreText(_score.BestValue);
        }

        private void OnEnable() {
            playButton.onClick.AddListener(Play);
            settingsButton.onClick.AddListener(ShowSettings);
            exitButton.onClick.AddListener(Exit);
        }

        private void OnDisable() {
            playButton.onClick.RemoveListener(Play);
            settingsButton.onClick.RemoveListener(ShowSettings);
            exitButton.onClick.RemoveListener(Exit);
        }

        private void UpdateScoreText(int value) {
            scoreText.text = value.ToString();
        }

        private void Play() {
            _sceneLoader.LoadGame();
        }

        private void ShowSettings() {
            OnSettingsShow?.Invoke();
        }

        private void Exit() {
            _game.Quit();
        }
    }
}
