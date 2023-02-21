using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private CollectableType _collectableType;
    public float respawnTime;
    

    public enum CollectableType
    {
        RedAmmo,
        BluAmmo,
    }

    private void replenishRed()
    {
        if (_weaponController.weapon.energy == Weapon.Energy.Red)
        {
            this.gameObject.SetActive(false);
            _weaponController.maxAmmo = _weaponController.weapon.maxAmmo;
        }

    }

    private void replenishBlu()
    {
        if (_weaponController.weapon.energy == Weapon.Energy.Blu)
        {
            this.gameObject.SetActive(false);
            _weaponController.maxAmmo = _weaponController.weapon.maxAmmo;
        }
    }

    private void collect()
    {
        switch (_collectableType)
        {
            case CollectableType.BluAmmo: replenishBlu(); break;
            case CollectableType.RedAmmo: replenishRed(); break;
        }
    }

    private void respawn()
    {
        if (!this.isActiveAndEnabled)
        {
            this.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _weaponController = other.GetComponentInChildren<WeaponController>();
            if (_weaponController.maxAmmo < _weaponController.weapon.maxAmmo)
            {
                collect();
            }
        }
    }


}
