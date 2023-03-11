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
            SubscribeToRotation(tank);
            SubscribeToFire();
            SubscribeToChangeWeapon();
        }

        private void SubscribeToMovements(TankViewModel tank)
        {
            _inputObservable.IsMoving
                .Where(isMoving => isMoving)
                .Subscribe(_ =>
                {
                    var direction = _config.TankSpeed * Time.deltaTime * Vector3.forward;
                    tank.Move(direction);
                });
        }

        private void SubscribeToRotation(TankViewModel tank)
        {
            _inputObservable.Rotation
                .Where(rotationAxis => rotationAxis != 0f)
                .Subscribe(rotationAxis =>
                {
                    var rotation = rotationAxis * Time.deltaTime * _config.TankRotationSpeed;
                    tank.Rotate(new Vector3(0f, rotation, 0f));
                });
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