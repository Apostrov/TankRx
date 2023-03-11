using System;

namespace TankRx.Input
{
    public interface IInputObservable
    {
        public IObservable<bool> IsMoving { get; }
        public IObservable<float> Rotation { get; }
        public IObservable<bool> IsFired { get; }
        public IObservable<float> WeaponChange { get; }
    }
}