using System.Collections.Generic;
using TrickySpikes.UI;
using TrickySpikes.Utils;
using UnityEngine;

namespace TrickySpikes {
    public class Bootstrap : MonoBehaviour {

        [SerializeField] private Circle circle;
        [SerializeField] private GameObject spikePrefab;
        [SerializeField] private GameObject bonusPrefab;
        [SerializeField] private Player player;
        [SerializeField] private Hud hud;

        public PauseManager PauseManager => Game.Instance.PauseManager;
        public Score Score => Game.Instance.Score;

        private HashSet<int> _usedAngles = new HashSet<int>(10);

        private void Awake() {
            Score.Value = 0;
        }

        private void Start() {
            CreatePlayer();
            CreateBonus();
        }

        public void AddScore(int amount) {
            Score.Value += amount;
            CreateBonus();
            CreateSpike();
        }

        public void GameOver() {
            PauseManager.Pause();
            hud.ShowGameOverScreen();
        }

        private void CreatePlayer() {
            var player = Instantiate(this.player, circle.CircleCenter, Quaternion.identity);
            player.Init(this);
            player.Move(circle.SetRandomTargetPosition(CircleUtils.RandomAngle));
        }

        private void CreateSpike() {
            var angle = CircleUtils.RandomAngle;
            while (_usedAngles.Contains(angle)) {
                angle = CircleUtils.RandomAngle;
            }
            circle.Spawn(spikePrefab, angle);
            _usedAngles.Add(angle);
        }

        private void CreateBonus() {
            var angle = CircleUtils.RandomAngle;
            while (_usedAngles.Contains(angle)) {
                angle = CircleUtils.RandomAngle;
            }
            var bonus = circle.Spawn(bonusPrefab, angle).GetComponentInChildren<Bonus>();
            bonus.OnPick.AddListener(AddScore);
        }
    }
}
