using TankRx.Input;
using TankRx.Player.Configs;
using TankRx.Player.ViewModels;
using UniRx;
using UnityEngine;

namespace TankRx.Player.Models
{
    public class Tank : ITank
    {
        private readonly PlayerConfig _config;
        private readonly IInputObservable _inputObservable;

        public Tank(PlayerConfig config, IInputObservable inputObservable)
        {
            _config = config;
            _inputObservable = inputObservable;
        }

        public void SpawnTank(Vector3 position, Quaternion rotation)
        {
            var tank = Object.Instantiate(_config.TankPrefab, position, rotation);
            SubscribeToMovements(tank);
        }

        public void SubscribeToMovements(TankViewModel tank)
        {
            _inputObservable.Movement
                .Where(v => v != Vector3.zero)
                .Subscribe(movementVector =>
                {
                    var direction = _config.TankSpeed * Time.deltaTime * movementVector;
                    tank.Move(direction);
                });
        }
    }
}