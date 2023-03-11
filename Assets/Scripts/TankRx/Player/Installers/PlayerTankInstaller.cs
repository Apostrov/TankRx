using TankRx.Player.Factory;
using Zenject;

namespace TankRx.Player.Installers
{
    public class PlayerTankInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITankSpawner>().To<TankSpawner>().AsSingle().NonLazy();
        }
    }
}