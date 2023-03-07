using UnityEngine;

namespace TankRx.Player.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "TankRx/Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public float TankSpeed;
    }
}