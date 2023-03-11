using TankRx.Player.Models;
using Zenject;

namespace TankRx.Player.Installers
{
    public class PlayerTankInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITank>().To<Tank>().AsSingle().NonLazy();
            
        }
    }
}