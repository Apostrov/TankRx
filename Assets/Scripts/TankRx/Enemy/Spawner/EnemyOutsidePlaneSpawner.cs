using TankRx.Enemy.Configs;
using TankRx.Enemy.Interfaces;
using TankRx.Level.Spawner;
using UniRx;
using UnityEngine;
using Zenject;

namespace TankRx.Enemy.Spawner
{
    public class EnemyOutsidePlaneSpawner : ALevelSpawner
    {
        [SerializeField] private MeshFilter _plane;

        private IEnemyFactory _enemyFactory;
        private EnemyConfig _config;

        [Inject]
        public void Construct(IEnemyFactory enemyFactory, EnemyConfig config)
        {
            _enemyFactory = enemyFactory;
            _config = config;
        }

        public override void Spawn()
        {
            Observable.Interval(System.TimeSpan.FromSeconds(_config.SpawnReload))
                .Subscribe(_ => { _enemyFactory.Create(GetRandomEdgePosition(), Quaternion.identity); })
                ;
        }

        private Vector3 GetRandomEdgePosition()
        {
            var bounds = _plane.mesh.bounds;
            var scale = _plane.transform.localScale;

            var planePosition = _plane.transform.position;
            var minX = planePosition.x - scale.x * bounds.size.x / 2f;
            var maxX = planePosition.x + scale.x * bounds.size.x / 2f;
            var minZ = planePosition.z - scale.z * bounds.size.z / 2f;
            var maxZ = planePosition.z + scale.z * bounds.size.z / 2f;

            var position = Vector3.zero;
            var side = Random.Range(0, 4);
            switch (side)
            {
                case 0: // Left
                    position.x = minX;
                    position.z = Random.Range(minZ, maxZ);
                    break;
                case 1: // Right
                    position.x = maxX;
                    position.z = Random.Range(minZ, maxZ);
                    break;
                case 2: // Top
                    position.x = Random.Range(minX, maxX);
                    position.z = maxZ;
                    break;
                case 3: // Bottom
                    position.x = Random.Range(minX, maxX);
                    position.z = minZ;
                    break;
            }

            position.y = 0f;

            return position;
        }
    }
}