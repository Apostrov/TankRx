using TankRx.Player.Factory;
using Zenject;

namespace TankRx.Player.Installers
{
    public class PlayerFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITankFactory>().To<TankFactory>().AsSingle().NonLazy();
        }
    }
}