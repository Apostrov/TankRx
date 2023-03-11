using TankRx.Player.Models;
using UnityEngine;
using Zenject;

namespace TankRx.Player.UnityComponents
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;

        private ITank _tank;
        
        [Inject]
        private void Construct(ITank tank)
        {
            _tank = tank;
        }

        private void Start()
        {
            _tank.SpawnTank(_spawnPosition.position, _spawnPosition.rotation);
        }
    }
}