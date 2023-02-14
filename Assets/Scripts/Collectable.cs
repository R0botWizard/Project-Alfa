using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private CollectableType _collectableType;
    [SerializeField] private float _respawnTimer;
    private float time;

    public enum CollectableType
    {
        RedAmmo,
        BluAmmo,
        Medkit,
    }

    private void Start()
    {
        time = _respawnTimer;
    }
    void Update()
    {
        if (!this.isActiveAndEnabled)
        {
            time -= Time.deltaTime;
            Debug.Log("ai bleaaaaa");
            respawn();
        }
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
        if (!this.isActiveAndEnabled && time <=0)
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
