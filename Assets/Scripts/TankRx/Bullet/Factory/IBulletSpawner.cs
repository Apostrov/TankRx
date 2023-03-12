using TankRx.Bullet.ViewModels;
using UnityEngine;

namespace TankRx.Bullet.Factory
{
    public interface IBulletSpawner
    {
        BulletViewModel SpawnBullet(Vector3 position, Quaternion rotation, float flySpeed, float lifeTime);
    }
}