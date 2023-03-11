using UnityEngine;

namespace TankRx.Player.Models
{
    public interface ITank
    {
        void SpawnTank(Vector3 position, Quaternion rotation);
    }
}