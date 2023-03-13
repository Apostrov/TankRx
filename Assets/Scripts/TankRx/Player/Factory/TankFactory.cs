using TankRx.Bullet.Factory;
using TankRx.Bullet.Interfaces;
using TankRx.Input.Interfaces;
using TankRx.Player.Configs;
using TankRx.Player.Interfaces;
using TankRx.Player.ViewModels;
using UniRx;
using UnityEngine;

namespace TankRx.Player.Factory
{
    public class TankFactory : ITankFactory
    {
        private readonly PlayerConfig _config;
        private readonly IInputObservable _inputObservable;
        private readonly IPlayerObservable _playerObservable;
        private readonly IBulletFactory _bulletFactory;

        public TankFactory(PlayerConfig config, IInputObservable inputObservable, IPlayerObservable playerObservable)
        {
            _config = config;
            _inputObservable = inputObservable;
            _playerObservable = playerObservable;
            _bulletFactory = new BulletFactory(_config.BulletPrefab);
        }

        public TankViewModel Create(Vector3 position, Quaternion rotation)
        {
            var tank = Spawn(position, rotation);
            RegisterPlayerObservable(tank);
            SubscribeToMovements(tank);
            SubscribeToRotation(tank);
            SubscribeToFire(tank);
            SubscribeToChangeWeapon(tank);
            SubscribeToDestroyOnZeroHp(tank);
            return tank;
        }

        private void RegisterPlayerObservable(TankViewModel tank)
        {
            _playerObservable.RegisterPlayer(tank.gameObject);
        }

        private TankViewModel Spawn(Vector3 position, Quaternion rotation)
        {
            var tank = Object.Instantiate(_config.TankPrefab, position, rotation);
            tank.SetModel(_config.PlayerTank);
            return tank;
        }

        private void SubscribeToMovements(TankViewModel tank)
        {
            _inputObservable.IsMoving
                .Where(isMoving => isMoving)
                .Subscribe(_ =>
                {
                    var direction = tank.Model.Speed * Time.deltaTime * Vector3.forward;
                    tank.Move(direction);
                }).AddTo(tank);
        }

        private void SubscribeToRotation(TankViewModel tank)
        {
            _inputObservable.Rotation
                .Where(rotationAxis => rotationAxis != 0f)
                .Subscribe(rotationAxis =>
                {
                    var rotation = rotationAxis * Time.deltaTime * tank.Model.RotationSpeed;
                    tank.Rotate(new Vector3(0f, rotation, 0f));
                }).AddTo(tank);
        }

        private void SubscribeToFire(TankViewModel tank)
        {
            _inputObservable.IsFired
                .Where(isFired => isFired)
                .Subscribe(_ =>
                {
                    _bulletFactory.Create(tank.BulletSpawnPosition.position, tank.transform.rotation,
                        _config.PlayerBullet);
                }).AddTo(tank);
        }

        private void SubscribeToChangeWeapon(TankViewModel tank)
        {
            _inputObservable.WeaponChange
                .Where(changeAxis => changeAxis != 0f)
                .Subscribe(changeAxis => { Debug.Log($"ChangeWeapon: {changeAxis}"); })
                .AddTo(tank);
        }
        
        private void SubscribeToDestroyOnZeroHp(TankViewModel tank)
        {
            tank.Model.Hp
                .Where(hp => hp <= 0f)
                .Subscribe(_ => Object.Destroy(tank.gameObject));
        }
    }
}