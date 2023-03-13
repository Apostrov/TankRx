using UnityEngine;

namespace TankRx.Bullet.Models
{
    [System.Serializable]
    public struct BulletModel
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float LifeTime { get; private set; }
    }
}