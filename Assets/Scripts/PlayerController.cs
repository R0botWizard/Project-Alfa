using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _xSensitivity;

    private CharacterController _pc;
    private Vector3 dir = Vector3.zero;
    private Vector3 moveDir = Vector3.zero;
    private void Awake()
    {
        _pc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        playerMove();
        playerRotation();
        playerJump();
    }
    private void playerMove()
    {
        dir = new Vector3(Input.GetAxis("Horizontal"), verticalvelocity, Input.GetAxis("Vertical")).normalized;
        moveDir = dir;
        if (dir.x > 0)
        {
            moveDir = transform.right;
            moveDir.y = verticalvelocity;
        }
        if (dir.z > 0)
        {
            moveDir = transform.forward;
            moveDir.y = verticalvelocity;
        }
        if (dir.x < 0)
        {
            moveDir = -transform.right;
            moveDir.y = verticalvelocity;
        }
        if (dir.z < 0)
        {
            moveDir = -transform.forward;
            moveDir.y = verticalvelocity;
        }

        //_pc.Move(moveDir * playerSprint(_speed) * Time.deltaTime);
        
        _pc.Move(new Vector3(moveDir.x * playerSprint(_speed) * Time.deltaTime, verticalvelocity * Time.deltaTime, moveDir.z * playerSprint(_speed) * Time.deltaTime));
    }

    private void playerRotation()
    {
        float xMouse = Input.GetAxis("Mouse X") * _xSensitivity;

        transform.Rotate(new Vector3(0, xMouse * Time.deltaTime, 0));
    }
    private float playerSprint(float speed)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return speed + 10;
        }
        return speed;
    }

    private float gravity = 9.81f;
    private float verticalvelocity = 0;
    private void playerJump()
    {
        if (Input.GetButton("Jump") && _pc.isGrounded)
        {
            verticalvelocity = _jumpForce;
        }
        else if (_pc.isGrounded)
        {
            verticalvelocity = 0;
        }
        verticalvelocity -= gravity * Time.deltaTime;
    }

}
