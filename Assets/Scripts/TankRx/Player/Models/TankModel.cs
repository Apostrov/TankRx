using UniRx;
using UnityEngine;

namespace TankRx.Player.Models
{
    [System.Serializable]
    public struct TankModel
    {
        [field: SerializeField] public ReactiveProperty<float> Hp { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }

        [field: SerializeField, Range(0.1f, 1f)]
        public float GetDamageMultiplier { get; private set; }

        public TankModel(TankModel copy)
        {
            Hp = new ReactiveProperty<float>(copy.Hp.Value);
            Speed = copy.Speed;
            RotationSpeed = copy.RotationSpeed;
            GetDamageMultiplier = copy.GetDamageMultiplier;
        }

        public void GetDamage(float damage)
        {
            Hp.Value -= damage * GetDamageMultiplier;
        }
    }
}