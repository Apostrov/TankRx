using System;
using TankRx.Bullet.Models;
using UniRx;
using UnityEngine;

namespace TankRx.Bullet.ViewModels
{
    public class BulletViewModel : MonoBehaviour
    {
        public BulletModel Model { get; set; }
        public CompositeDisposable Disposable { get; } = new();
        
        public Action OnReturnToPool { private get; set; }

        public void Move(Vector3 direction)
        {
            transform.Translate(direction, Space.Self);
        }

        private void OnDestroy()
        {
            Disposable.Dispose();
        }

        public void ReturnToPool()
        {
            Disposable.Clear();
            OnReturnToPool?.Invoke();
        }
    }
}