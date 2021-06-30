using Mirror;
using UnityEngine;

namespace ProjectSpace.Game
{
    class PlayerController : NetworkBehaviour
    {
        public float speed = 1.5f;
        public float turnSpeed = 1.5f;

        public int health = 100;
        public bool isBouncing = false;
    }
}
