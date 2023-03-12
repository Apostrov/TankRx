using System;
using UnityEngine;

namespace TankRx.Player.Observables
{
    public interface IPlayerObservable
    {
        IObservable<Vector3?> PlayerPosition { get; }
        void RegisterPlayer(GameObject player);
        void UnregisterPlayer();
    }
}