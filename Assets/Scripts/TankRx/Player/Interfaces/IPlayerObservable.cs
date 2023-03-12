using System;
using UnityEngine;

namespace TankRx.Player.Interfaces
{
    public interface IPlayerObservable
    {
        IObservable<Vector3?> PlayerPosition { get; }
        void RegisterPlayer(GameObject player);
        void UnregisterPlayer();
    }
}