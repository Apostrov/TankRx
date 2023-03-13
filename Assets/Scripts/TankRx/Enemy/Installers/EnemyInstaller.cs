using TankRx.Enemy.Configs;
using TankRx.Enemy.Factory;
using TankRx.Enemy.Interfaces;
using TankRx.Enemy.Models;
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
            Container.Bind<EnemyAliveModel>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }
    }
}