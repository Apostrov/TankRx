using TankRx.Enemy.Configs;
using TankRx.Enemy.ViewModels;
using UnityEngine;

namespace TankRx.Enemy.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyConfig _config;
        
        public EnemyFactory(EnemyConfig config)
        {
            _config = config;
        }

        public EnemyViewModel Create(Vector3 position, Quaternion rotation)
        {
            var enemy = Spawn(position, rotation);
            return enemy;
        }

        private EnemyViewModel Spawn(Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(_config.GetRandomEnemy(), position, rotation);
        }
    }
}