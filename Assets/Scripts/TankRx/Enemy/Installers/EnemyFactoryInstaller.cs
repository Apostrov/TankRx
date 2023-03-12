using TankRx.Enemy.Factory;
using Zenject;

namespace TankRx.Enemy.Installers
{
    public class EnemyFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle().NonLazy();
        }
    }
}