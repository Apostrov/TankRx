using System;
using TankRx.Enemy.Models;
using UnityEngine;

namespace TankRx.Enemy.ViewModels
{
    public class EnemyViewModel : MonoBehaviour
    {
        public EnemyModel Model { get; private set; }
        public Action OnDestroyCallback { private get; set; }

        public void Move(Vector3 direction)
        {
            transform.Translate(direction, Space.Self);
        }

        public void SetModel(EnemyModel model)
        {
            Model = new EnemyModel(model);
        }
        
        private void OnDestroy()
        {
            OnDestroyCallback?.Invoke();
        }
    }
}