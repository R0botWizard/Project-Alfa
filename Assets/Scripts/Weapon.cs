using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public float range;
    public float fireRate;
    public float damage;
    public float ammo;
    public float maxAmmo;
    public float reloadTime;
    public Type type;
    public Energy energy;
    public GameObject weapon;

    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public Vector3 scaleOffset;
    

    
    public enum Type
    {
        Rifle,
        Canon,
    }
    public enum Energy
    {
        Red,
        Blu,
    }
}
