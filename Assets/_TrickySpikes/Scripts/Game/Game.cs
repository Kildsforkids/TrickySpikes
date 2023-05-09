using UnityEngine;

namespace TrickySpikes {
    public class Game : Singleton<Game> {

        [SerializeField] private GameSettingsSO gameSettings;
        [SerializeField] private GameObject audioManager;
        [SerializeField] private int targetFrameRate = 60;

        public IStore Store { get; private set; }
        public SoundSystem SoundSystem { get; private set; }
        public Score Score { get; private set; }
        public SceneLoader SceneLoader { get; private set; }
        public PauseManager PauseManager { get; private set; }

        private void Start() {
            Application.targetFrameRate = targetFrameRate;
            Store = new PlayerPrefsStore();
            SoundSystem = new SoundSystem(gameSettings);
            Score = new Score(new ScoreProvider(Store));
            SceneLoader = new SceneLoader();
            PauseManager = new PauseManager();

            SceneLoader.LoadMenu(CreateAudioManager);
        }

        public void Quit() {
            if (!Application.isEditor)
                Application.Quit();
            else
                Debug.Log("Exit!");
        }

        private void CreateAudioManager() {
            Instantiate(audioManager);
        }
    }
}
