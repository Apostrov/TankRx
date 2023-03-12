using UnityEngine;

namespace TankRx.Level.UnityComponents
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