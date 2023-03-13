using TankRx.Enemy.Models;
using UnityEngine;

namespace TankRx.Enemy.ViewModels
{
    public class EnemyViewModel : MonoBehaviour
    {
        public EnemyModel Model { get; private set; }

        public void Move(Vector3 direction)
        {
            transform.Translate(direction, Space.Self);
        }

        public void SetModel(EnemyModel model)
        {
            Model = new EnemyModel(model);
        }
    }
}