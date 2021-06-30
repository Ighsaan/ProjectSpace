using Assets.Scripts.Game;
using Mirror;
using UnityEngine;

namespace ProjectSpace.Game
{
    public class PlayerMovementController : NetworkBehaviour
    {
        public float rotationOffSet;

        private PlayerController playerController;
        private Camera playerCam;

        private void Start()
        {
            playerController = GetComponent<PlayerController>();
            playerCam = GetComponent<PlayerCameraController>().playerCamera;
        }

        public override void OnStartAuthority()
        {
            Debug.Log("Hello has auth from movement");
        }
        void Update()
        {
            // exit from update if this is not the local player
            if (!hasAuthority) return;

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 objectPos = playerCam.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffSet));

            if (!playerController.isBouncing)
            {          
                if (Input.GetKey("w"))
                {
                    Vector3 targetPos = playerCam.ScreenToWorldPoint(Input.mousePosition);
                    targetPos.z = 0;
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, playerController.speed * Time.deltaTime);
                }

                if (Input.GetKey("a"))
                {
                    transform.Translate(Vector3.left * (playerController.turnSpeed * Time.deltaTime));
                }

                if (Input.GetKey("d"))
                {
                    transform.Translate(Vector3.right * (playerController.turnSpeed * Time.deltaTime));
                }
            }
        }

    }
}
