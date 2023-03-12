using TankRx.Player.Factory;
using UnityEngine;
using Zenject;

namespace TankRx.Player.UnityComponents
{
    public class PlayerOnLevelSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;

        private ITankSpawner _tankSpawner;
        
        [Inject]
        private void Construct(ITankSpawner tankSpawner)
        {
            _tankSpawner = tankSpawner;
        }

        private void Start()
        {
            _tankSpawner.SpawnTank(_spawnPosition.position, _spawnPosition.rotation);
        }
    }
}