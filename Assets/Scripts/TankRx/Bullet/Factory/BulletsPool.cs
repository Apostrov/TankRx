using TankRx.Bullet.ViewModels;
using UnityEngine;
using UnityEngine.Pool;

namespace TankRx.Bullet.Factory
{
    public class BulletsPool
    {
        private readonly BulletViewModel _prefab;
        private readonly IObjectPool<BulletViewModel> _pool;

        public BulletsPool(BulletViewModel prefab)
        {
            _prefab = prefab;
            _pool = new ObjectPool<BulletViewModel>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject);
        }

        public IObjectPool<BulletViewModel> GetPool()
        {
            return _pool;
        }

        BulletViewModel CreatePooledItem()
        {
            var item = Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);
            return item;
        }

        // Called when an item is returned to the pool using Release
        void OnReturnedToPool(BulletViewModel bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        void OnTakeFromPool(BulletViewModel bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        void OnDestroyPoolObject(BulletViewModel bullet)
        {
            Object.Destroy(bullet);
        }
    }
}