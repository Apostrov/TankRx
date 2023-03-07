using TankRx.Input;
using TankRx.Player.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace TankRx.Player.ViewModels
{
    public class TankViewModel : MonoBehaviour
    {
        private IInputObservable _input;
        private PlayerConfig _config;

        [Inject]
        private void Construct(IInputObservable input, PlayerConfig config)
        {
            _input = input;
            _config = config;
        }

        private void Start()
        {
            SubscribeToMovements();
        }

        private void SubscribeToMovements()
        {
            _input.Movement
                .Where(v => v != Vector3.zero)
                .Subscribe(movementVector =>
                {
                    var direction = _config.TankSpeed * Time.deltaTime * movementVector;
                    transform.Translate(direction, Space.World);
                    transform.localRotation = Quaternion.LookRotation(direction);
                });
        }
    }
}