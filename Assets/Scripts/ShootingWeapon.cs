using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : ScriptableObject
{
    [SerializeField] private float _range;
    
    
    
    private enum WeaponType
    {
        LaserRifle,
        LaserRayRifle,
        PlasmaCanon,
    }

}
