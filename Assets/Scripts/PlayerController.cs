using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _maxHP;
    [SerializeField] private HealthBar _healthBar;
    [Header("Properties")]
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _xSensitivity;


    public bool isSprinting;
    private CharacterController _pc;
    public Vector3 dir = Vector3.zero;
    public Vector3 moveDir;
    private void Awake()
    {
        GameManager.Instance.InitializePlayerStats(_maxHP);
        _pc = GetComponent<CharacterController>();
        moveDir = Vector3.zero;
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
        
        _pc.Move(new Vector3(moveDir.x * playerSprint() * Time.deltaTime, verticalvelocity * Time.deltaTime, moveDir.z * playerSprint() * Time.deltaTime));
    }

    private void playerRotation()
    {
        float xMouse = Input.GetAxis("Mouse X") * _xSensitivity;

        transform.Rotate(new Vector3(0, xMouse * Time.deltaTime, 0));
    }
    public float playerSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            return _speed + 10;
        }
        isSprinting = false;
        return _speed;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AttackCollider")
        {
            Enemy enemy = other.GetComponentInParent<Enemy>();
            GameManager.Instance.PlayerTakeDamage(enemy.Damage);
            _healthBar.UpdateHealthBar(GameManager.Instance.playerMaxHP, GameManager.Instance.playerCurrentHP);
        }
    }

}
