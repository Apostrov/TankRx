﻿using TankRx.Enemy.ViewModels;
using UnityEngine;

namespace TankRx.Enemy.Factory
{
    public interface IEnemyFactory
    {
        EnemyViewModel Create(Vector3 position, Quaternion rotation);
    }
}