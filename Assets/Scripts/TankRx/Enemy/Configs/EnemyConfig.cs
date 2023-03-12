using TankRx.Enemy.Models;
using TankRx.Enemy.ViewModels;
using UnityEngine;
using UnityEngine.Serialization;

namespace TankRx.Enemy.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "TankRx/Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public EnemyInfo[] EnemyPrefabs;

        [Header("Spawner")]
        public float SpawnReload;

        #region helpers

        public EnemyInfo GetRandomEnemy()
        {
            return EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
        }

        #endregion
    }

    [System.Serializable]
    public class EnemyInfo
    {
        [FormerlySerializedAs("EnemyPrefab")] public EnemyViewModel Prefab;
        public EnemyModel EnemyModel;
    }
}