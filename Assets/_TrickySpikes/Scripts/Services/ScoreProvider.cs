namespace TrickySpikes {
    public class ScoreProvider {

        private const string BestScoreKey = "BestScore";
        private IStore _store;
        private int _score;

        public ScoreProvider(IStore store) {
            _store = store;
            _score = 0;
        }

        public int LoadScore(ScoreType type) {
            switch (type) {
                case ScoreType.Default:
                    return _score;
                case ScoreType.Best:
                    return _store.LoadInt(BestScoreKey);
            }
            return 0;
        }

        public void SaveScore(int score, ScoreType type) {
            switch (type) {
                case ScoreType.Default:
                    _score = score;
                    break;
                case ScoreType.Best:
                    _store.SaveInt(BestScoreKey, score);
                    break;
            }
        }
    }

    public enum ScoreType {
        Default,
        Best
    }
}
