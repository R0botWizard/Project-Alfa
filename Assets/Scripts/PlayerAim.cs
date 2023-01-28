using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _sensitivity;

    
    private void Awake()
    {

    }

    private void Update()
    {
        float xMouse = Input.GetAxis("Mouse X") * _sensitivity;
        float yMouse = Input.GetAxis("Mouse Y") * _sensitivity;

        transform.Rotate(new Vector3(0, xMouse * Time.deltaTime, 0)) ;
        
    }
}
