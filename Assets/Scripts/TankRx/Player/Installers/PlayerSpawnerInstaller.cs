using TankRx.Player.Spawner;
using UnityEngine;
using Zenject;

namespace TankRx.Player.Installers
{
    public class PlayerSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private TankOnPositionSpawner _playerSpawner;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerSpawner).AsSingle();
        }
    }
}