using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _weaponOrigin;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private float laserDuration;
    private LineRenderer _laserLine;
    

    public Weapon weapon;
    public Animator weaponAnim;
    public GameObject impactEffect;
    public float currentAmmo { get; private set; }
    public float maxAmmo { get; set; }

    private void Start()
    {
        _laserLine = _weaponOrigin.GetComponent<LineRenderer>();
        currentAmmo = weapon.ammo;
        maxAmmo = weapon.maxAmmo;
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
    public void reloadAnimation()
    {

    }

    public void shoot()
    {
        /*switch (weapon.type)
        {
            case Weapon.Type.Rifle: break;
            case Weapon.Type.Canon: break;
        }*/
        
        currentAmmo--;
        if (currentAmmo > 0)
        {
            muzzleFlash.Play();
            RaycastHit hitCam;
            Vector2 screenCenterPoint = new Vector2(_camera.scaledPixelWidth / 2f, _camera.scaledPixelHeight / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            _laserLine.SetPosition(0,_weaponOrigin.position);
            if (Physics.Raycast(ray, out hitCam, weapon.range))
            {
                RaycastHit hitWep;
                if (Physics.Raycast(_weaponOrigin.position, (hitCam.point - _weaponOrigin.position).normalized, out hitWep, weapon.range))
                {
                    _laserLine.SetPosition(1, hitWep.point);
                    Enemy target = hitWep.transform.GetComponent<Enemy>();
                    if (target != null)
                    {
                        target.takeDamage(weapon.damage);
                    }

                    Destroy(Instantiate(impactEffect, hitWep.point, Quaternion.LookRotation(hitWep.normal)), 1f);
                }
            }
            StartCoroutine(ShootLaser());
            Debug.Log("Current ammo: "+ currentAmmo+" Ammo capacity "+ weapon.ammo+"Max ammo "+maxAmmo);
        }
        else
        {
            reload();
        }

    }

    private IEnumerator ShootLaser()
    {
        _laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        _laserLine.enabled = false;
    }
    public void reload()
    {
        float ammoGain = weapon.ammo - currentAmmo;
        if(maxAmmo > 0)
        {
            currentAmmo += ammoGain;
            maxAmmo -= ammoGain;
        }
    }
}
