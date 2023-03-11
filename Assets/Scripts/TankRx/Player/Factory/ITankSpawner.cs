using UnityEngine;

namespace TankRx.Player.Factory
{
    public interface ITankSpawner
    {
        void SpawnTank(Vector3 position, Quaternion rotation);
    }
}