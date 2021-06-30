using UnityEngine;

namespace ProjectSpace.Lobby
{
    class MainMenu: MonoBehaviour
    {
        [SerializeField] private NetworkManagerSpace networkManager = null;

        [Header("UI")]
        [SerializeField] private GameObject landingPagePanel = null;

        public void HostLobby()
        {
            networkManager.StartHost();
            landingPagePanel.SetActive(false);
        }
    }
}
