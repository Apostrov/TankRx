using TankRx.Enemy.Configs;
using TankRx.Enemy.ViewModels;
using TankRx.Player.Observables;
using UniRx;
using UnityEngine;

namespace TankRx.Enemy.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyConfig _config;
        private readonly IPlayerObservable _playerObservable;

        public EnemyFactory(EnemyConfig config, IPlayerObservable playerObservable)
        {
            _config = config;
            _playerObservable = playerObservable;
        }

        public EnemyViewModel Create(Vector3 position, Quaternion rotation)
        {
            var enemy = Spawn(position, rotation);
            SubscribeToFollowPlayer(enemy);
            return enemy;
        }

        private EnemyViewModel Spawn(Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(_config.GetRandomEnemy(), position, rotation);
        }

        private void SubscribeToFollowPlayer(EnemyViewModel enemy)
        {
            _playerObservable.PlayerPosition
                .Where(position => position != null)
                .Subscribe(position =>
                {
                    var direction = (position.Value - enemy.transform.position).normalized;
                    var speed = _config.EnemySpeed * Time.deltaTime;
                    enemy.Move(direction * speed);
                }).AddTo(enemy);
        }
    }
}