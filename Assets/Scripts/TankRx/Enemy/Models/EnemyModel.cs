using System;
using UniRx;
using UnityEngine;

namespace TankRx.Enemy.Models
{
    [Serializable]
    public struct EnemyModel
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public ReactiveProperty<float> Hp { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float HitDamage { get; private set; }

        [field: SerializeField, Range(0.1f, 1f)]
        public float GetDamageMultiplier { get; private set; }

        public EnemyModel(EnemyModel copy)
        {
            Type = copy.Type;
            Hp = new ReactiveProperty<float>(copy.Hp.Value);
            Speed = copy.Speed;
            HitDamage = copy.HitDamage;
            GetDamageMultiplier = copy.GetDamageMultiplier;
        }

        public void GetDamage(float damage)
        {
            Hp.Value -= damage * GetDamageMultiplier;
        }
    }
}