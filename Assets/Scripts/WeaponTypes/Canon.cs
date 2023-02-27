using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour, IWeapon
{
    public Weapon weaponStats;
    // Start is called before the first frame update
    public void Shoot()
    {
        Debug.Log("Canon Shoot");
    }

    public void Reload()
    {
        Debug.Log("Canon Reload");
    }

    public void ReplenishAmmo()
    {
        Debug.Log("Canon Refilled");
    }

    public float GetMaxAmmo()
    {
        return weaponStats.maxAmmo;
    }

    public Weapon GetWeaponStats()
    {
        return weaponStats;
    }

}
