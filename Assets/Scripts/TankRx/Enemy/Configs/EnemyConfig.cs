﻿using TankRx.Enemy.ViewModels;
using UnityEngine;

namespace TankRx.Enemy.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "TankRx/Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("Spawner")]
        public EnemyViewModel[] EnemyPrefabs;
        public float SpawnReload;

        public EnemyViewModel GetRandomEnemy()
        {
            return EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
        }
    }
}