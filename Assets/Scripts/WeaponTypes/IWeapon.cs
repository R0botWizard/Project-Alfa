using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Shoot();
    public void Reload();
    public void ReplenishAmmo();
    public float GetCurrentAmmo();
    public float GetMaxAmmo();
    public Weapon GetWeaponStats();
    public bool GetReloadStatus();
}


