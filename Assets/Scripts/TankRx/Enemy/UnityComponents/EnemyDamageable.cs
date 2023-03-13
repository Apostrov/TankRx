using TankRx.Common.Interfaces;
using TankRx.Enemy.ViewModels;
using UnityEngine;

namespace TankRx.Enemy.UnityComponents
{
    public class EnemyDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyViewModel _enemyViewModel;
        
        public void DoDamage(float damage)
        {
            _enemyViewModel.Model.GetDamage(damage);
        }
    }
}