using TankRx.Enemy.Configs;
using TankRx.Enemy.Interfaces;
using TankRx.Enemy.ViewModels;
using TankRx.Player.Interfaces;
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
            SubscribeToDestroyOnZeroHp(enemy);
            return enemy;
        }

        private EnemyViewModel Spawn(Vector3 position, Quaternion rotation)
        {
            var enemyConfig = _config.GetRandomEnemy();
            var enemy = Object.Instantiate(enemyConfig.Prefab, position, rotation);
            enemy.SetModel(enemyConfig.EnemyModel);
            return enemy;
        }

        private void SubscribeToFollowPlayer(EnemyViewModel enemy)
        {
            _playerObservable.PlayerPosition
                .Where(position => position != null)
                .Subscribe(position =>
                {
                    var direction = (position.Value - enemy.transform.position).normalized;
                    var speed = enemy.Model.Speed * Time.deltaTime;
                    enemy.Move(direction * speed);
                }).AddTo(enemy);
        }

        private void SubscribeToDestroyOnZeroHp(EnemyViewModel enemy)
        {
            enemy.Model.Hp
                .Where(hp => hp <= 0f)
                .Subscribe(_ => Object.Destroy(enemy.gameObject));
        }
    }
}