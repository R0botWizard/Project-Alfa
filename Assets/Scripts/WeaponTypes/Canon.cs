using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour, IWeapon
{
    [SerializeField] Camera _camera;
    [SerializeField] Transform _weaponOrigin;
    [SerializeField] private ParticleSystem muzzleFlash;

    public Weapon weaponStats;
    private GameObject _currentProjectile;

    [Header("Projectile")]
    [SerializeField] GameObject _projectile;
    [SerializeField] private float _shootForce, _upwardForce;
    
    public float currentAmmo { get; private set; }
    public float maxAmmo { get; set; }
    private bool isReloading = false;
    void OnEnable()
    {
        isReloading = false;
    }

    private void Start()
    {
        currentAmmo = weaponStats.ammo;
        maxAmmo = weaponStats.maxAmmo;
    }
    public void Shoot()
    {
        
        currentAmmo--;
        if (currentAmmo >= 0 && !isReloading)
        {
            muzzleFlash.Play();
            //Debug.Log("Canon Shoot");
            Debug.Log("Current ammo: " + currentAmmo + " Ammo capacity " + weaponStats.ammo + " Max ammo " + maxAmmo);
            RaycastHit hitCam;
            Vector2 screenCenterPoint = new Vector2(_camera.scaledPixelWidth / 2f, _camera.scaledPixelHeight / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out hitCam, weaponStats.range))
            {
                RaycastHit hitWep;
                if (Physics.Raycast(_weaponOrigin.position, (hitCam.point - _weaponOrigin.position).normalized, out hitWep, weaponStats.range))
                {
                    Vector3 direction = hitWep.point - _weaponOrigin.position;
                    _currentProjectile = Instantiate(_projectile, _weaponOrigin.transform.position, Quaternion.identity);

                    _currentProjectile.transform.forward = direction.normalized;

                    _currentProjectile.GetComponent<Rigidbody>().AddForce(direction.normalized * _shootForce, ForceMode.Impulse);
                    _currentProjectile.GetComponent<Projectile>().SetDamage(weaponStats.damage);
                    
                }
            }
            
        }
        else
        {
            Reload();
        }
    }

    public void Reload()
    {
        StartCoroutine(reloadTimer());
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

    public void ReplenishAmmo()
    {
        maxAmmo = weaponStats.maxAmmo;
    }
    public float GetCurrentAmmo()
    {
        return currentAmmo;
    }
    public float GetMaxAmmo()
    {
        return maxAmmo;
    }

    public bool GetReloadStatus()
    {
        return isReloading;
    }
    public Weapon GetWeaponStats()
    {
        return weaponStats;
    }

}
