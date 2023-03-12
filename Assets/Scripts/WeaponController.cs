using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private AmmoBar _ammoBar;
    public IWeapon _weaponType;
    public Animator weaponAnim;
    private void Start()
    {
        _weaponType = GetComponent<IWeapon>();
    }

    private void Update()
    {
        _ammoBar.UpdateAmmoBar(_weaponType.GetWeaponStats().ammo,_weaponType.GetCurrentAmmo(),_weaponType.GetMaxAmmo());
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
