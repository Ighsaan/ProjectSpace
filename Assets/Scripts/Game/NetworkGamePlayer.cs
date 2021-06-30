using Mirror;
using ProjectSpace.Lobby;

namespace ProjectSpace.Game
{
    public class NetworkGamePlayer : NetworkBehaviour
    {
        [SyncVar]
        private string displayName = "Loading...";

        private NetworkManagerSpace room;

        private NetworkManagerSpace Room
        {
            get
            {
                if(room != null) { return room; }
                return room = NetworkManager.singleton as NetworkManagerSpace;
            }
        }

        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject); 
            Room.GamePlayers.Add(this);
        }

        [Server]
        public void SetDisplayName(string displayName)
        {
            this.displayName = displayName;
        }
    }
}
