using UnityEngine;

namespace TankRx.Player.ViewModels
{
    public class TankViewModel : MonoBehaviour
    {
        [field: SerializeField] public Transform BulletSpawnPosition { get; private set; }
        
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