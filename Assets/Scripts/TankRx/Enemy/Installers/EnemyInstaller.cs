using TankRx.Enemy.Configs;
using TankRx.Enemy.Factory;
using UnityEngine;
using Zenject;

namespace TankRx.Enemy.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _config;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle().NonLazy();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }
    }
}