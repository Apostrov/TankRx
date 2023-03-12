using UnityEngine;

namespace TankRx.Level.Spawner
{
    public class RootSpawner : MonoBehaviour
    {
        [SerializeField] private ALevelSpawner[] _spawners;

        private void Start()
        {
            foreach (var spawner in _spawners)
            {
                spawner.Spawn();
            }
        }
    }
}