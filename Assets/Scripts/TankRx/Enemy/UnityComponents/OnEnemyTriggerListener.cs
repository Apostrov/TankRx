using TankRx.Common.UnityComponents;
using TankRx.Enemy.ViewModels;
using UnityEngine;

namespace TankRx.Enemy.UnityComponents
{
    public class OnEnemyTriggerListener : ADamageOnTrigger
    {
        [SerializeField] private EnemyViewModel _enemyViewModel;

        protected override float Damage => _enemyViewModel.Model.HitDamage;

        protected override void OnSuccessTrigger()
        {
            Destroy(_enemyViewModel.gameObject);
        }
    }
}