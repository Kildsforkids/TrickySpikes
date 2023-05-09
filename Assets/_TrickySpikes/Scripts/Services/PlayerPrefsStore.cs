using UnityEngine;

namespace TrickySpikes {
    public class PlayerPrefsStore : IStore {

        public int LoadInt(string key) =>
            PlayerPrefs.GetInt(key, 0);

        public void SaveInt(string key, int value) =>
            PlayerPrefs.SetInt(key, value);
    }
}
