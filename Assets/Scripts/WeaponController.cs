using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public IWeapon _weaponType;
    public Animator weaponAnim;
    private void Start()
    {
        //typeConfirm();
        _weaponType = GetComponent<IWeapon>();
    }
    /*public void typeConfirm()
    {
        if (_weaponType.GetWeaponStats().type == Weapon.Type.Rifle)
        {
            setType(FindObjectOfType<Rifle>());
        }
        if (_weaponType.GetWeaponStats().type == Weapon.Type.Canon)
        {
            setType(FindObjectOfType<Canon>());
        }
    }*/

    /*private void setType(IWeapon weaponType)
    {
        _weaponType = weaponType;
    }*/
    
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
