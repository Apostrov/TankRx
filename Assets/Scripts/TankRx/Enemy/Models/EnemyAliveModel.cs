using System.Collections.Generic;
using TankRx.Enemy.ViewModels;

namespace TankRx.Enemy.Models
{
    public class EnemyAliveModel
    {
        private readonly HashSet<EnemyViewModel> _alive;

        public EnemyAliveModel()
        {
            _alive = new();
        }

        public void RegisterNewEnemy(EnemyViewModel enemy)
        {
            _alive.Add(enemy);
        }

        public void UnregisterEnemy(EnemyViewModel enemy)
        {
            _alive.Remove(enemy);
        }

        public int GetAliveNumber()
        {
            return _alive.Count;
        }
    }
}