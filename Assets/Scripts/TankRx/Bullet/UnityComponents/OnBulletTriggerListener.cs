using TankRx.Bullet.ViewModels;
using TankRx.Common.UnityComponents;
using UnityEngine;

namespace TankRx.Bullet.UnityComponents
{
    public class OnBulletTriggerListener : ADamageOnTrigger
    {
        [SerializeField] private BulletViewModel _bulletViewModel;

        protected override float Damage => _bulletViewModel.Model.Damage;

        protected override void OnSuccessTrigger()
        {
            _bulletViewModel.ReturnToPool();
        }
    }
}