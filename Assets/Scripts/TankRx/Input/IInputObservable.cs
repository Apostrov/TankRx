using System;
using UnityEngine;

namespace TankRx.Input
{
    public interface IInputObservable
    {
        public IObservable<Vector3> Movement { get; }
    }
}