using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TrickySpikes {
    public class Timer : MonoBehaviour, IPausable {

        [SerializeField] private float secondsRate;
        [SerializeField] private bool isActive;

        public UnityEvent OnTick;

        public PauseManager PauseManager => Game.Instance.PauseManager;

        private void Awake() {
            PauseManager.Register(this);
        }

        private IEnumerator Start() {
            var waitForSeconds = new WaitForSeconds(secondsRate);
            while (isActive) {
                yield return waitForSeconds;
                if (isActive) {
                    OnTick?.Invoke();
                }
            }
        }

        public void Pause() {
            isActive = false;
        }

        public void Resume() {
            isActive = true;
        }
    }
}
