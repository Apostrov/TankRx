using TankRx.Input.Interfaces;
using TankRx.Input.Observables;
using Zenject;

namespace TankRx.Input.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputObservable>().To<InputObservable>().AsSingle().NonLazy();
        }
    }
}