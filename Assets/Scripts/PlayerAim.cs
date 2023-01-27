using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float sensitivity;

    private float xAxis;
    private float yAxis;
    private Vector3 rotate;
    
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        xAxis = Input.GetAxis("Mouse Y");
        yAxis = Input.GetAxis("Mouse X");
        rotate = new Vector3(xAxis * sensitivity, yAxis * -sensitivity , 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }
}
