using TankRx.Player.Models;
using TankRx.Weapon.ViewModels;
using UnityEngine;

namespace TankRx.Player.ViewModels
{
    public class TankViewModel : MonoBehaviour
    {
        [SerializeField] private GenericDictionary<WeaponType, WeaponViewModel> _weapons;
        public TankModel Model { get; private set; }

        public void SetModel(TankModel model)
        {
            Model = new TankModel(model);
        }

        public void Move(Vector3 direction)
        {
            transform.Translate(direction, Space.Self);
        }

        public void Rotate(Vector3 addRotation)
        {
            transform.localEulerAngles += addRotation;
        }

        public void ChangeWeapon(WeaponType weaponType)
        {
            foreach (var typeAndView in _weapons)
            {
                typeAndView.Value.gameObject.SetActive(weaponType == typeAndView.Key);
            }
        }

        public Vector3 GetBulletSpawnPosition()
        {
            return _weapons[Model.WeaponType.Value].BulletSpawnPosition.position;
        }
    }
}