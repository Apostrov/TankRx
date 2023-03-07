using UnityEngine;
using Zenject;

namespace TankRx.Player.Configs
{
    public class PlayerConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _config;

        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromInstance(_config).AsSingle().NonLazy();
        }
    }
}