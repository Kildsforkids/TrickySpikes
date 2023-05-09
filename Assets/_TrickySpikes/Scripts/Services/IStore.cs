namespace TrickySpikes {
    public interface IStore {
        void SaveInt(string key, int value);
        int LoadInt(string key);
    }
}
