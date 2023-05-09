using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TrickySpikes.UI {
    public class GameOverScreen : Screen {

        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;

        public Score Score => Game.Instance.Score;
        public SceneLoader SceneLoader => Game.Instance.SceneLoader;

        private void OnEnable() {
            UpdateText(scoreText, Score.Value);
            UpdateText(bestScoreText, Score.BestValue);

            restartButton.onClick.AddListener(Restart);
            menuButton.onClick.AddListener(Back);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(Restart);
            menuButton.onClick.RemoveListener(Back);
        }

        private void Restart() {
            SceneLoader.Restart();
        }

        private void Back() {
            SceneLoader.LoadMenu();
        }

        private void UpdateText(TextMeshProUGUI text, int value) {
            text.text = value.ToString();
        }
    }
}
