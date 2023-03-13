using TankRx.Common.Interfaces;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace TankRx.Common.UnityComponents
{
    public abstract class ADamageOnTrigger : MonoBehaviour
    {
        protected abstract float Damage { get; }

        private void Start()
        {
            this.OnTriggerEnterAsObservable()
                .Subscribe(collision =>
                {
                    if (!collision.TryGetComponent<IDamageable>(out var damageable)) return;
                    damageable.DoDamage(Damage);
                    OnSuccessTrigger();
                });
        }

        protected abstract void OnSuccessTrigger();
    }
}