using System;
using TankRx.Bullet.Interfaces;
using TankRx.Bullet.Models;
using TankRx.Bullet.ViewModels;
using UniRx;
using UnityEngine;
using UnityEngine.Pool;

namespace TankRx.Bullet.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IObjectPool<BulletViewModel> _bulletPool;

        public BulletFactory(BulletViewModel bulletPrefab)
        {
            _bulletPool = new BulletsPool(bulletPrefab).GetPool();
        }

        public BulletViewModel Create(Vector3 position, Quaternion rotation, BulletModel model)
        {
            var bullet = Spawn(position, rotation, model);
            StartBulletMove(bullet, bullet.Model.Speed);
            StartBulletLifeTimeCounter(bullet, bullet.Model.LifeTime);
            return bullet;
        }

        private BulletViewModel Spawn(Vector3 position, Quaternion rotation, BulletModel model)
        {
            var bullet = _bulletPool.Get();
            bullet.Model = model;
            bullet.transform.SetPositionAndRotation(position, rotation);
            return bullet;
        }

        private void StartBulletMove(BulletViewModel bullet, float speed)
        {
            Observable.EveryUpdate().Subscribe(_ => { bullet.Move(Vector3.forward * speed * Time.deltaTime); })
                .AddTo(bullet.Disposable);
        }

        private void StartBulletLifeTimeCounter(BulletViewModel bullet, float lifeTime)
        {
            Observable.Timer(TimeSpan.FromSeconds(lifeTime))
                .Subscribe(_ => _bulletPool.Release(bullet))
                .AddTo(bullet.Disposable);
        }
    }
}