using TankRx.Bullet.Models;
using TankRx.Bullet.ViewModels;
using UnityEngine;

namespace TankRx.Bullet.Interfaces
{
    public interface IBulletFactory
    {
        BulletViewModel Create(Vector3 position, Quaternion rotation, BulletModel model);
    }
}