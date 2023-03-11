using Zenject;

namespace TankRx.Input
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var inputObservable = new InputObservable(this);
            Container.Bind<IInputObservable>().FromInstance(inputObservable).AsSingle().NonLazy();
        }
    }
}