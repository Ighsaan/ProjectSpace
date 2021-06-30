using Mirror;
using UnityEngine;

namespace ProjectSpace.Game
{
    class PlayerCollisionController : NetworkBehaviour
    {

        private Rigidbody2D rb;
        private PlayerController playerController;
        public float bounce = 100f;
        public float bounceDuration = 0.6f;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            playerController = GetComponent<PlayerController>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                //amount of force to apply
                rb.AddForce(collision.contacts[0].normal * bounce);
                playerController.isBouncing = true;
                Invoke("StopBounce", bounceDuration);
            }
        }
        void StopBounce()
        {
            playerController.isBouncing = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
        }
    }
}
