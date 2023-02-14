using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _ySensitivity;
    [SerializeField] private Camera _camera;
    [SerializeField] private WeaponController[] _weapons;
    private float _transitionSpeed = 50;
    private int _selectedWeapon;
    private void Awake()
    {
        
    }

    private void Update()
    {
        manageWeapons();
        onReload();
        onAim();
        onFire();
        onZoom();
        
    }
    private void onAim()
    {
        float yMouse = Input.GetAxis("Mouse Y") * -_ySensitivity * Time.deltaTime;

        float currentXRotation = _camera.transform.localEulerAngles.x;

        if (currentXRotation > 180) 
        {
            currentXRotation -= 360;
        }
        float clampedXRotation = Mathf.Clamp(currentXRotation + yMouse, -30, 30);

        _camera.transform.localEulerAngles = new Vector3(clampedXRotation, 0, 0);
    }

    private float nextTimeToFire = 0f;
    private void onFire()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / _weapons[_selectedWeapon].weapon.fireRate;
            _weapons[_selectedWeapon].shoot();
            _weapons[_selectedWeapon].shootingAnimation(true);
        }
        else
        {
            _weapons[_selectedWeapon].shootingAnimation(false);
        }
        
    }

    private void onZoom()
    {
        if (Input.GetButton("Fire2"))
        {
            if(_camera.fieldOfView > 40)
            {
                //_camera.fieldOfView -= _transitionSpeed * Time.deltaTime;
                _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView,40,_transitionSpeed*Time.deltaTime);

            }
        }
        else if(_camera.fieldOfView < 60)
        {
           // _camera.fieldOfView += _transitionSpeed * Time.deltaTime;
            _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView, 60, _transitionSpeed * Time.deltaTime);
            
        }
        
    }

    private void onReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _weapons[_selectedWeapon].reload();
        }
       
    }
    private void weaponSelect(int selectedWeaponIndex)
    {
        for(int i = 0; i< _weapons.Length; i++)
        {
            _weapons[i].gameObject.SetActive(false);
        }

        _weapons[selectedWeaponIndex].gameObject.SetActive(true);
        _selectedWeapon = selectedWeaponIndex;
        
    }
    private void manageWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSelect(0); 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSelect(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponSelect(2);
        }
    }

    



}
