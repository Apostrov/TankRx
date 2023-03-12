using TankRx.Bullet.Interfaces;
using TankRx.Bullet.ViewModels;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace TankRx.Bullet.UnityComponents
{
    public class OnBulletTriggerListener : MonoBehaviour
    {
        [SerializeField] private BulletViewModel _bulletViewModel;

        private void Start()
        {
            this.OnTriggerEnterAsObservable()
                .Subscribe(collision =>
                {
                    if(!collision.TryGetComponent<IDamageable>(out var damageable)) return;
                    damageable.DoDamage(_bulletViewModel.Model.Damage);
                    _bulletViewModel.ReturnToPool();
                });
        }
    }
}