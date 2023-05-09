using UnityEngine;
using UnityEngine.Events;

namespace TrickySpikes {
    public class Bonus : MonoBehaviour, IObstacle {

        [SerializeField] private int scoreAmount;

        public UnityEvent<int> OnPick;

        public void OnPlayerCollide(Player player) {
            OnPick?.Invoke(scoreAmount);
            OnPick.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}

