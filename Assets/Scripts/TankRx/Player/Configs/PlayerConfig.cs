using TankRx.Bullet.Models;
using TankRx.Bullet.ViewModels;
using TankRx.Player.Models;
using TankRx.Player.ViewModels;
using UnityEngine;

namespace TankRx.Player.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "TankRx/Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Tank")]
        public TankViewModel TankPrefab;
        public TankModel PlayerTank;

        [Header("Weapons")]
        public GenericDictionary<WeaponType, BulletConfig> WeaponConfigs;
    }
    
    [System.Serializable]
    public class BulletConfig
    {
        public BulletViewModel BulletPrefab;
        public BulletModel BulletModel;
    }
}