using UnityEngine;

namespace TankRx.Weapon.ViewModels
{
    public class WeaponViewModel : MonoBehaviour
    {
        [field: SerializeField] public Transform BulletSpawnPosition { get; private set; }
    }
}