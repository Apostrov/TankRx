using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace TankRx.Input
{
    public class InputObservable : IInputObservable
    {
        public IObservable<Vector3> Movement => MovementObservable();

        private readonly MonoBehaviour _monoBehaviour;
        private readonly Input _input;

        public InputObservable(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
            _input = new Input();
            _input.Enable();
        }

        private IObservable<Vector3> MovementObservable()
        {
            return _monoBehaviour.UpdateAsObservable()
                .Select(_ =>
                {
                    var movementVector = _input.Player.Move.ReadValue<Vector2>();
                    return new Vector3(movementVector.x, 0f, movementVector.y);
                });
        }
    }
}