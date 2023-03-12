using TankRx.Enemy.Configs;
using UnityEngine;
using Zenject;

namespace TankRx.Enemy.Installers
{
    public class EnemyConfigInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _config;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle().NonLazy();
        }
    }
}