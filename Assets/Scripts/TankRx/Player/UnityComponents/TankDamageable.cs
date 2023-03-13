using TankRx.Common.Interfaces;
using TankRx.Player.ViewModels;
using UnityEngine;

namespace TankRx.Player.UnityComponents
{
    public class TankDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private TankViewModel _tankViewModel;
        
        public void DoDamage(float damage)
        {
            _tankViewModel.Model.GetDamage(damage);
        }
    }
}