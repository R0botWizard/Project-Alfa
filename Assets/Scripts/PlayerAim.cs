using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _sensitivity;
    [SerializeField] private Camera _camera;
     
    

    private float _transitionSpeed = 50;
    
    private void Awake()
    {
        
    }

    private void Update()
    {
        onFire();
        onZoom();
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
