using System;
using TankRx.Input.Interfaces;
using UniRx;

namespace TankRx.Input.Observables
{
    public class InputObservable : IInputObservable
    {
        public IObservable<bool> IsMoving => MovementObservable();
        public IObservable<float> Rotation => HeadRotationObservable();
        public IObservable<bool> IsFired => IsFiredObservable();
        public IObservable<float> WeaponChange => WeaponChangeObservable();
        
        private readonly Input _input;

        public InputObservable()
        {
            _input = new Input();
            _input.Enable();
        }

        private IObservable<bool> MovementObservable()
        {
            return Observable.EveryUpdate().Select(_ => _input.Player.Move.IsPressed());
        }

        private IObservable<float> HeadRotationObservable()
        {
            return Observable.EveryUpdate().Select(_ => _input.Player.Look.ReadValue<float>());
        }

        private IObservable<bool> IsFiredObservable()
        {
            return Observable.EveryUpdate().Select(_ => _input.Player.Fire.WasPressedThisFrame());
        }

        private IObservable<float> WeaponChangeObservable()
        {
            return Observable.EveryUpdate().Select(_ =>
            {
                if (_input.Player.ChangeWeapon.WasPressedThisFrame())
                    return _input.Player.ChangeWeapon.ReadValue<float>();
                return 0f;
            });
        }
    }
}