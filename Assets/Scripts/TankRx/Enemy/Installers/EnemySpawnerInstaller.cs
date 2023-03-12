using TankRx.Enemy.Spawner;
using UnityEngine;
using Zenject;

namespace TankRx.Enemy.Installers
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private EnemyOutsidePlaneSpawner _spawner;

        public override void InstallBindings()
        {
            Container.BindInstance(_spawner).AsSingle();
        }
    }
}