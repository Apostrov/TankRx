using TankRx.Player.ViewModels;
using UnityEngine;
using Zenject;

namespace TankRx.Player.Installers
{
    public class PlayerTankInstaller : MonoInstaller
    {
        [SerializeField] private TankViewModel _tankPrefab;
        [SerializeField] private Transform _position;

        public override void InstallBindings()
        {
            var tank = Container.InstantiatePrefabForComponent<TankViewModel>(_tankPrefab, _position.transform.position,
                Quaternion.identity, null);
            Container.Bind<TankViewModel>().FromInstance(tank).AsSingle();
        }
    }
}