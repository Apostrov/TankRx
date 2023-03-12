using UnityEngine;

namespace TankRx.Enemy.ViewModels
{
    public class EnemyViewModel : MonoBehaviour
    {
        public void Move(Vector3 direction)
        {
            transform.Translate(direction, Space.Self);
        }
    }
}