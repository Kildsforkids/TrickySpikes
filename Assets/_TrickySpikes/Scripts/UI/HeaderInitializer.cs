using UnityEngine;

namespace TrickySpikes.UI {
    public class HeaderInitializer : MonoBehaviour {

        [SerializeField] private Transform canvas;
        [SerializeField] private GameObject headerPanelPrefab;

        private void Start() {
            CreateHeaderPanel();
        }

        private void CreateHeaderPanel() {
            Instantiate(headerPanelPrefab, canvas);
        }
    }
}
