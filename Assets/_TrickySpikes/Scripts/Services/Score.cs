using System;

namespace TrickySpikes {
    public class Score {

        public Action<int> BestScoreUpdated;
        public Action<int> ScoreUpdated;

        public int Value {
            get => _scoreProvider.LoadScore(ScoreType.Default);
            set {
                if (value > BestValue) {
                    BestValue = value;
                }
                _scoreProvider.SaveScore(value, ScoreType.Default);
                ScoreUpdated?.Invoke(value);
            }
        }

        public int BestValue {
            get => _scoreProvider.LoadScore(ScoreType.Best);
            set {
                _scoreProvider.SaveScore(value, ScoreType.Best);
                BestScoreUpdated?.Invoke(value);
            }
        }

        private ScoreProvider _scoreProvider;

        public Score(ScoreProvider scoreProvider) {
            _scoreProvider = scoreProvider;
        }
    }
}
