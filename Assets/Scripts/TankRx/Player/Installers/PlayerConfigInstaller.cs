using TankRx.Player.Configs;
using UnityEngine;
using Zenject;

namespace TankRx.Player.Installers
{
    public class PlayerConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _config;

        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle().NonLazy();
        }
    }
}