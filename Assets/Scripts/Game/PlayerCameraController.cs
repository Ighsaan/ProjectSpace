using Mirror;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class PlayerCameraController : NetworkBehaviour
    {
        public Camera playerCamera;
        public override void OnStartAuthority()
        {
            playerCamera.transform.parent = null;
            playerCamera.transform.rotation = Quaternion.identity;
            playerCamera.enabled = true;
            playerCamera.gameObject.SetActive(true);
            Camera.main.gameObject.SetActive(false);
        }
    }
}
