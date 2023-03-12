﻿using TankRx.Level.UnityComponents;
using TankRx.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace TankRx.Player.Factory
{
    public class TankOnPositionSpawner : ALevelSpawner
    {
        [SerializeField] private Transform _spawnPosition;

        private ITankFactory _tankFactory;
        
        [Inject]
        public void Construct(ITankFactory tankFactory)
        {
            _tankFactory = tankFactory;
        }

        public override void Spawn()
        {
            _tankFactory.Create(_spawnPosition.position, _spawnPosition.rotation);
        }
    }
}