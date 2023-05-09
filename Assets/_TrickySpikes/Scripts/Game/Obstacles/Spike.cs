using UnityEngine;

namespace TrickySpikes {
    public class Spike : MonoBehaviour, IObstacle, IIndestructible {

        public void OnPlayerCollide(Player player) {
            player.TakeDamage();
        }
    }
}

