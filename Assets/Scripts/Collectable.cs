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
        if (_weaponController._weaponType.GetWeaponStats().energy == Weapon.Energy.Red)
        {
            this.gameObject.SetActive(false);
            _weaponController._weaponType.ReplenishAmmo();
        }

    }

    private void replenishBlu()
    {
        if (_weaponController._weaponType.GetWeaponStats().energy == Weapon.Energy.Blu)
        {
            this.gameObject.SetActive(false);
            _weaponController._weaponType.ReplenishAmmo();
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
            Debug.Log("You You you");
            _weaponController = other.GetComponentInChildren<WeaponController>();
            Debug.Log("Weapon detected");
            if (_weaponController._weaponType.GetMaxAmmo() < _weaponController._weaponType.GetWeaponStats().maxAmmo)
            {
                collect();
            }
        }
    }


}
