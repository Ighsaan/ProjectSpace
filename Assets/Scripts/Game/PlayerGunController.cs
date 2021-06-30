using Mirror;
using System.Collections;
using UnityEngine;

namespace ProjectSpace.Game
{
    class PlayerGunController: NetworkBehaviour
    {
        public GameObject bulletPrefab;
        private KeyCode Shoot = KeyCode.Mouse0;
        private bool canShoot = true;
        public Transform bulletSpawn;
        public float bulletLifeTime = 3.0f;
        public float bulletSpeed = 30f;

        private void Update()
        {

            if (!hasAuthority) return;
            if (canShoot == true && Input.GetKey(Shoot))
            {
                canShoot = false;
                CmdDoFire(bulletLifeTime);
                StartCoroutine(cooldownShoot());
            }
        }

        [Command]
        void CmdDoFire(float lifeTime)
        {
            GameObject bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                Quaternion.identity);

            var bullet2D = bullet.GetComponent<Rigidbody2D>();
            bullet2D.velocity = transform.up * bulletSpeed;
            Destroy(bullet, lifeTime);

            NetworkServer.Spawn(bullet);
        }

        IEnumerator cooldownShoot()
        {
            //Fire Rate is 10 Rounds Per Second.
            yield return new WaitForSeconds(0.1f);
            canShoot = true;
            StopCoroutine(cooldownShoot());
        }
    }
}
