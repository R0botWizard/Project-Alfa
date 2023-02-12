using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _weaponOrigin;
    [SerializeField] private ParticleSystem muzzleFlash;
    

    public Weapon weapon;
    public Animator weaponAnim;
    public GameObject impactEffect;



    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        RaycastHit hitCam;
        Vector2 screenCenterPoint = new Vector2(_camera.scaledPixelWidth / 2f, _camera.scaledPixelHeight / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out hitCam, weapon.range))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_camera.transform.position, hitCam.point);
        }

        RaycastHit hitWep;
        if (Physics.Raycast(_weaponOrigin.position,(hitCam.point - _weaponOrigin.position).normalized, out hitWep, weapon.range))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_weaponOrigin.position, hitWep.point);
        }
    }

    public void shootingAnimation(bool input)
    {
        weaponAnim.SetBool("isShooting",input);
        weaponAnim.speed = weapon.fireRate;
    }

    public void shoot()
    {
        /*switch (weapon.type)
        {
            case Weapon.Type.Rifle: break;
            case Weapon.Type.Canon: break;
        }*/
        muzzleFlash.Play();

        RaycastHit hitCam;
        Vector2 screenCenterPoint = new Vector2(_camera.scaledPixelWidth / 2f, _camera.scaledPixelHeight / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out hitCam, weapon.range))
        {
            RaycastHit hitWep;
            if (Physics.Raycast(_weaponOrigin.position, (hitCam.point - _weaponOrigin.position).normalized, out hitWep, weapon.range))
            {
                Enemy target = hitWep.transform.GetComponent<Enemy>();
                if (target != null)
                {
                    target.takeDamage(weapon.damage);
                }

                Destroy(Instantiate(impactEffect, hitWep.point, Quaternion.LookRotation(hitWep.normal)),1f);
                
            }
        }

        

        


    }

    
}
