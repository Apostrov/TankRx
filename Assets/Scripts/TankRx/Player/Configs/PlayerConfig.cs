using TankRx.Bullet.Models;
using TankRx.Bullet.ViewModels;
using TankRx.Player.ViewModels;
using UnityEngine;

namespace TankRx.Player.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "TankRx/Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Tank")]
        public TankViewModel TankPrefab;
        public float TankSpeed;
        public float TankRotationSpeed;
        
        [Header("Bullet")]
        public BulletViewModel BulletPrefab;
        public BulletModel PlayerBullet;
    }
}