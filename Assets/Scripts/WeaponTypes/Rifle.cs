using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour,IWeapon
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _weaponOrigin;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private float effectDuration;
    

    public Weapon weaponStats;
    private LineRenderer _laserLine;
    public GameObject impactEffect;
    public float currentAmmo { get; private set; }
    public float maxAmmo { get; set; }

    private bool isReloading = false;
    void OnEnable()
    {
        isReloading = false;
    }

    private void Start()
    {
        _laserLine = _weaponOrigin.GetComponent<LineRenderer>();
        currentAmmo = weaponStats.ammo;
        maxAmmo = weaponStats.maxAmmo;
    }
    private void OnDrawGizmos()
    {
        RaycastHit hitCam;
        Vector2 screenCenterPoint = new Vector2(_camera.scaledPixelWidth / 2f, _camera.scaledPixelHeight / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out hitCam, weaponStats.range))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_camera.transform.position, hitCam.point);
        }

        RaycastHit hitWep;
        if (Physics.Raycast(_weaponOrigin.position, (hitCam.point - _weaponOrigin.position).normalized, out hitWep, weaponStats.range))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_weaponOrigin.position, hitWep.point);
        }
    }
    public void Shoot()
    {
        currentAmmo--;
        
        if (currentAmmo >= 0 && !isReloading)
        {
            muzzleFlash.Play();
            RaycastHit hitCam;
            Vector2 screenCenterPoint = new Vector2(_camera.scaledPixelWidth / 2f, _camera.scaledPixelHeight / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            _laserLine.SetPosition(0, _weaponOrigin.position);
            if (Physics.Raycast(ray, out hitCam, weaponStats.range))
            {
                RaycastHit hitWep;
                if (Physics.Raycast(_weaponOrigin.position, (hitCam.point - _weaponOrigin.position).normalized, out hitWep, weaponStats.range))
                {
                    _laserLine.SetPosition(1, hitWep.point);
                    Enemy target = hitWep.transform.GetComponent<Enemy>();
                    if (target != null)
                    {
                        target.takeDamage(weaponStats.damage);
                    }

                    Destroy(Instantiate(impactEffect, hitWep.point, Quaternion.LookRotation(hitWep.normal)), 1f);
                }
            }
            StartCoroutine(ShootLaser());
            Debug.Log("Current ammo: " + currentAmmo + " Ammo capacity " + weaponStats.ammo + " Max ammo " + maxAmmo);
        }
        else
        {
            Reload();
        }
    }

    public void ReplenishAmmo()
    {
        maxAmmo = weaponStats.maxAmmo;
    }

    public float GetMaxAmmo()
    {
        return maxAmmo;
    }

    public float GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public Weapon GetWeaponStats()
    {
        return weaponStats;
    }

    private IEnumerator ShootLaser()
    {
        _laserLine.enabled = true;
        yield return new WaitForSeconds(effectDuration);
        _laserLine.enabled = false;
    }
    
    public void Reload()
    {
        if(maxAmmo > 0)
        {
            StartCoroutine(reloadTimer());
        }
        else
        {
            return;
        }
    }

    IEnumerator reloadTimer()
    {
        Debug.Log("Reloading...");
        isReloading = true;
        yield return new WaitForSeconds(weaponStats.reloadTime);
        float ammoGain = weaponStats.ammo - currentAmmo;
        if (maxAmmo > 0)
        {
            if (ammoGain > maxAmmo)
            {
                currentAmmo = maxAmmo;
                maxAmmo = 0;
            }
            else
            {
                currentAmmo += ammoGain;
                maxAmmo -= ammoGain;
            }
        }
        Debug.Log("Reloading complete!");
        isReloading = false;
    }
}
