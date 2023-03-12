using TankRx.Player.Configs;
using TankRx.Player.Factory;
using TankRx.Player.Observables;
using UnityEngine;
using Zenject;

namespace TankRx.Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _config;

        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle().NonLazy();
            Container.Bind<ITankFactory>().To<TankFactory>().AsSingle();
            Container.Bind<IPlayerObservable>().To<PlayerObservable>().AsSingle();
        }
    }
}