using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private Collision playerCollider;
    [SerializeField] private CollectableType collectableType;
    private Weapon weapon;

    public enum CollectableType
    {
        RedAmmo,
        BluAmmo,
        Medkit,
    }
    private void Start()
    {
        weapon = weaponController.weapon;
    }
    private void replenishRed()
    {
        
    }

    private void replenishBlu()
    {

    }

    private void replenishHp()
    {

    }

    private void refill()
    {
        OnCollisionEnter(playerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collectableType)
        {
            case CollectableType.BluAmmo: replenishBlu(); break;
            case CollectableType.RedAmmo: replenishRed(); break;
            case CollectableType.Medkit: replenishHp(); break;
        }
    }
}
