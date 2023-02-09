using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _weaponOrigin;
    public Weapon weapon;
    public Animator weaponAnim;
    

    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        if (Physics.Raycast(_weaponOrigin.position,_camera.transform.forward , out hit, weapon.range))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_weaponOrigin.position, hit.point);
        }
    }

    public void shootingAnimation(bool input)
    {
        weaponAnim.SetBool("isShooting",input);
    }
    public void shoot()
    {
        /*switch (weapon.type)
        {
            case Weapon.Type.Rifle: break;
            case Weapon.Type.Canon: break;
        }*/

        RaycastHit hit;
        if (Physics.Raycast(_weaponOrigin.position,_camera.transform.forward, out hit, weapon.range))
        {
            //Debug.Log(hit.transform.name);
            
        };

       
    }

    
}
