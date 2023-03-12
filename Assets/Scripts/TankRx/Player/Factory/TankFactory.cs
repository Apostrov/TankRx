using TankRx.Bullet.Factory;
using TankRx.Input;
using TankRx.Player.Configs;
using TankRx.Player.ViewModels;
using UniRx;
using UnityEngine;

namespace TankRx.Player.Factory
{
    public class TankFactory : ITankFactory
    {
        private readonly PlayerConfig _config;
        private readonly IInputObservable _inputObservable;
        private readonly IBulletSpawner _bulletSpawner;

        public TankFactory(PlayerConfig config, IInputObservable inputObservable)
        {
            _config = config;
            _inputObservable = inputObservable;
            _bulletSpawner = new BulletSpawner(_config.BulletPrefab);
        }

        public TankViewModel Create(Vector3 position, Quaternion rotation)
        {
            var tank = Spawn(position, rotation);
            SubscribeToMovements(tank);
            SubscribeToRotation(tank);
            SubscribeToFire(tank);
            SubscribeToChangeWeapon(tank);
            return tank;
        }

        private TankViewModel Spawn(Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(_config.TankPrefab, position, rotation);
        }

        private void SubscribeToMovements(TankViewModel tank)
        {
            _inputObservable.IsMoving
                .Where(isMoving => isMoving)
                .Subscribe(_ =>
                {
                    var direction = _config.TankSpeed * Time.deltaTime * Vector3.forward;
                    tank.Move(direction);
                }).AddTo(tank);
        }

        private void SubscribeToRotation(TankViewModel tank)
        {
            _inputObservable.Rotation
                .Where(rotationAxis => rotationAxis != 0f)
                .Subscribe(rotationAxis =>
                {
                    var rotation = rotationAxis * Time.deltaTime * _config.TankRotationSpeed;
                    tank.Rotate(new Vector3(0f, rotation, 0f));
                }).AddTo(tank);
        }

        private void SubscribeToFire(TankViewModel tank)
        {
            _inputObservable.IsFired
                .Where(isFired => isFired)
                .Subscribe(_ =>
                {
                    _bulletSpawner.SpawnBullet(tank.BulletSpawnPosition.position, tank.transform.rotation,
                        _config.BulletSpeed, _config.BulletLifeTime);
                }).AddTo(tank);
        }

        private void SubscribeToChangeWeapon(TankViewModel tank)
        {
            _inputObservable.WeaponChange
                .Where(changeAxis => changeAxis != 0f)
                .Subscribe(changeAxis => { Debug.Log($"ChangeWeapon: {changeAxis}"); })
                .AddTo(tank);
        }
    }
}