using System;
using TankRx.Bullet.ViewModels;
using UniRx;
using UnityEngine;
using UnityEngine.Pool;

namespace TankRx.Bullet.Factory
{
    public class BulletSpawner : IBulletSpawner
    {
        private readonly IObjectPool<BulletViewModel> _bulletPool;

        public BulletSpawner(BulletViewModel bulletPrefab)
        {
            _bulletPool = new BulletsPool(bulletPrefab).GetPool();
        }

        public BulletViewModel SpawnBullet(Vector3 position, Quaternion rotation, float flySpeed, float lifeTime)
        {
            var bullet = _bulletPool.Get();
            bullet.transform.SetPositionAndRotation(position, rotation);
            StartBulletMove(bullet, flySpeed);
            StartBulletLifeTimeCounter(bullet, lifeTime);
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