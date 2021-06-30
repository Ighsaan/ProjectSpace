using Mirror;
using ProjectSpace.Game;
using UnityEngine;

public class BulletController : NetworkBehaviour
{
    [ServerCallback]
    void OnCollisionEnter2D(Collision2D col)
    {
         PlayerController playerShot = col.transform.GetComponent<PlayerController>();
         if (playerShot)
         {
            NetworkServer.Destroy(gameObject);
            // Calculate y direction via hit Factor
        //    playerShot.TargetDoMagic(10);
         }

    }
}
