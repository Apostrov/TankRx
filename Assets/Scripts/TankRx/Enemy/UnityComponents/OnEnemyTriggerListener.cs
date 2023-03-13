using TankRx.Common.Interfaces;
using TankRx.Enemy.ViewModels;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace TankRx.Enemy.UnityComponents
{
    public class OnEnemyTriggerListener : MonoBehaviour
    {
        [SerializeField] private EnemyViewModel _enemyViewModel;

        private void Start()
        {
            this.OnTriggerEnterAsObservable()
                .Subscribe(collision =>
                {
                    if (!collision.TryGetComponent<IDamageable>(out var damageable)) return;
                    damageable.DoDamage(_enemyViewModel.Model.HitDamage);
                    Destroy(_enemyViewModel.gameObject);
                });
        }
    }
}