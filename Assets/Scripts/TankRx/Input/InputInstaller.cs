using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace TankRx.Input
{
    public class InputInstaller : MonoInstaller, IInputObservable
    {
        public IObservable<Vector3> Movement => MovementObservable();
        private Input _input;
        
        public override void InstallBindings()
        {
            _input = new Input();
            _input.Enable();

            Container.Bind<IInputObservable>().FromInstance(this).AsSingle().NonLazy();
        }
        
        private IObservable<Vector3> MovementObservable()
        {
            return this.UpdateAsObservable()
                .Select(_ =>
                {
                    var movementVector = _input.Player.Move.ReadValue<Vector2>();
                    return new Vector3(movementVector.x, 0f, movementVector.y);
                });
        }
    }
}