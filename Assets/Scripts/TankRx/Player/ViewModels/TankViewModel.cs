using UnityEngine;

namespace TankRx.Player.ViewModels
{
    public class TankViewModel : MonoBehaviour
    {
        public void Move(Vector3 direction)
        {
            transform.Translate(direction, Space.World);
            transform.localRotation = Quaternion.LookRotation(direction);
        }
    }
}