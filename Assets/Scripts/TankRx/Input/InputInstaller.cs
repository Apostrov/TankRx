using Zenject;

namespace TankRx.Input
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputObservable>().To<InputObservable>().AsSingle().NonLazy();
        }
    }
}