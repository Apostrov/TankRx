using TankRx.Player.ViewModels;
using UnityEngine;

namespace TankRx.Player.Factory
{
    public interface ITankFactory
    {
        TankViewModel Create(Vector3 position, Quaternion rotation);
    }
}