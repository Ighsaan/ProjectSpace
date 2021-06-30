using UnityEngine;

namespace ProjectSpace.Game
{
    class PlayerSpawnPoint: MonoBehaviour
    {
        private void Awake() => PlayerSpawnSystem.AddSpawnPoint(transform);
        private void OnDestroy() => PlayerSpawnSystem.RemoveSpawnPoint(transform);
    }
}
