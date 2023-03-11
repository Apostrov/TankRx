using TankRx.Player.ViewModels;
using UnityEngine;

namespace TankRx.Player.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "TankRx/Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public TankViewModel TankPrefab;
        public float TankSpeed;
        public float TankRotationSpeed;
    }
}