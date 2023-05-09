using System.Collections.Generic;

namespace TrickySpikes {
    public class PauseManager : IPausable {

        private readonly List<IPausable> _pausables = new List<IPausable>();

        public void Pause() {
            foreach (var pausable in _pausables) {
                pausable.Pause();
            }
        }

        public void Resume() {
            foreach (var pausable in _pausables) {
                pausable.Resume();
            }
        }

        public void Register(IPausable pausable) {
            _pausables.Add(pausable);
        }
    }
}
