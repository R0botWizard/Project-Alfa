using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _ySensitivity;
    [SerializeField] private Camera _camera;

    private float _transitionSpeed = 50;

    private void Awake()
    {
        
    }

    private void Update()
    {
        onAim();
        onFire();
        onZoom();
    }

    /*private void onAim()
    {
        float yMouse = Input.GetAxis("Mouse Y") * -_ySensitivity * Time.deltaTime;

        _camera.transform.Rotate(yMouse, 0, 0);
    }*/

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

    private void onFire()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("fire");
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

    



}
