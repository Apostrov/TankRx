using System;
using UnityEngine;

namespace TankRx.Input
{
    public interface IInputObservable
    {
        public IObservable<Vector3> Movement { get; }
        public IObservable<float> HeadRotation { get; }
        public IObservable<bool> IsFired { get; }
        public IObservable<float> WeaponChange { get; }
    }
}