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
            SubscribeToHeadRotation();
            SubscribeToFire();
            SubscribeToChangeWeapon();
        }

        private void SubscribeToMovements(TankViewModel tank)
        {
            _inputObservable.Movement
                .Where(movementVector => movementVector != Vector3.zero)
                .Subscribe(movementVector =>
                {
                    var direction = _config.TankSpeed * Time.deltaTime * movementVector;
                    tank.Move(direction);
                });
        }

        private void SubscribeToHeadRotation()
        {
            _inputObservable.HeadRotation
                .Where(rotationAxis => rotationAxis != 0f)
                .Subscribe(rotationAxis => { Debug.Log($"HeadRotation: {rotationAxis}"); });
        }

        private void SubscribeToFire()
        {
            _inputObservable.IsFired
                .Where(isFired => isFired)
                .Subscribe(_ => { Debug.Log("Fire"); });
        }

        private void SubscribeToChangeWeapon()
        {
            _inputObservable.WeaponChange
                .Where(changeAxis => changeAxis != 0f)
                .Subscribe(changeAxis => { Debug.Log($"ChangeWeapon: {changeAxis}"); });
        }
    }
}