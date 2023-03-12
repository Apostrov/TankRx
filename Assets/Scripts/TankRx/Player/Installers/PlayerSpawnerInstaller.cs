using TankRx.Player.UnityComponents;
using UnityEngine;
using Zenject;

namespace TankRx.Player.Installers
{
    public class PlayerSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerOnLevelSpawner _playerSpawner;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerSpawner).AsSingle();
        }
    }
}