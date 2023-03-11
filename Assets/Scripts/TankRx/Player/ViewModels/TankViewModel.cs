using UnityEngine;

namespace TankRx.Player.ViewModels
{
    public class TankViewModel : MonoBehaviour
    {
        public void Move(Vector3 direction)
        {
            transform.Translate(direction, Space.Self);
        }

        public void Rotate(Vector3 addRotation)
        {
            transform.localEulerAngles += addRotation;
        }
    }
}