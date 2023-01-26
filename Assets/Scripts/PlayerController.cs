using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    
    private CharacterController _pc;

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
        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
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
    private void playerJump()
    {

    }

}
