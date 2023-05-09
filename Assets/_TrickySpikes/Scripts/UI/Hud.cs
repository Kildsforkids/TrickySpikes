using TMPro;
using UnityEngine;

namespace TrickySpikes.UI {
    public class Hud : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Screen gameOverScreen;

        public Score Score => Game.Instance.Score;

        private void Start() {
            UpdateScoreText(Score.Value);
        }

        private void OnEnable() {
            Score.ScoreUpdated += UpdateScoreText;
        }

        private void OnDisable() {
            Score.ScoreUpdated -= UpdateScoreText;
        }

        public void ShowGameOverScreen() {
            gameOverScreen.Show();
        }

        public void HideGameOverScreen() {
            gameOverScreen.Hide();
        }

        private void UpdateScoreText(int value) {
            scoreText.text = value.ToString();
        }
    }
}
