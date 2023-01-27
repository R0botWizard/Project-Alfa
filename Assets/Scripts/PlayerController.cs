using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private CharacterController _pc;
    private Vector3 dir = Vector3.zero;
    private void Awake()
    {
        _pc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        playerMove();
        playerJump();
    }
    private void playerMove()
    {
        dir = new Vector3(Input.GetAxis("Horizontal"), verticalvelocity, Input.GetAxis("Vertical")).normalized;
        _pc.Move(dir * playerSprint(_speed) * Time.deltaTime);
 
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
