using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public IWeapon _weaponType;
    public Animator weaponAnim;
    private void Start()
    {
        _weaponType = GetComponent<IWeapon>();
    }
    public void shootingAnimation(bool input)
    {
        weaponAnim.SetBool("isShooting", input);
        weaponAnim.speed = _weaponType.GetWeaponStats().fireRate;
    }
    public void shoot()
    {
        _weaponType.Shoot();
    }
    
    public void reloadAnimation()
    {

    }
    
    




}
