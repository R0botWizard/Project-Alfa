using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("General stats")]
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    public float Damage => _damage;
    [SerializeField] private NavMeshAgent _enemy;
    [SerializeField] private float _velocity;
    [SerializeField] private float _atackTime;
    [SerializeField] private float _atackCooldown;
    [Header("Triggering")]
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private Transform _player;
    [SerializeField] private float _folowRadius;
    [SerializeField] private float _atackRadius;
    [Header("Atack")]
    [SerializeField] Collider _atackCollider;
    [Header("State")]
    public bool isChasing  = false;
    public bool isAtacking = false;
    public bool isAtackActive = false;
    private void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemy.speed = _velocity;
    }
    private void Update()
    {
        float followDistance = Vector3.Distance(transform.position, _player.position);
        float atackDistance = Vector3.Distance(transform.position, _player.position);

        if (followDistance < _folowRadius)
        {
            isChasing = true;
            if(atackDistance < _atackRadius)
            {
                StartCoroutine(atackReset());
            }
        }
        else
        {
            isChasing = false;
        }


        enemyFollow();
        enemyAtack();
    }
    public void takeDamage(float amount)
    {
        _health -= amount;
        Debug.Log("Health: " + _health);
        if(_health <= 0)
        {
            die();
        }
    }
    
    private void die()
    {
        GameManager.Instance.KillCount();
        Destroy(gameObject);
    }

    private void enemyFollow()
    {
        if (isChasing)
        {
            _enemy.SetDestination(_player.transform.position);
        }
    }

    private void enemyAtack()
    {
        _atackCollider.enabled = isAtacking;
    }

    private IEnumerator atackReset()
    {
        if (!isAtackActive)
        {
            isAtackActive = true;
            yield return new WaitForSeconds(0.5f);
            isAtacking = true;
            yield return new WaitForSeconds(_atackTime);
            isAtacking = false;
            yield return new WaitForSeconds(_atackCooldown);
            isAtackActive = false;
        }
    }

    public void SetAtackTime(float time)
    {
        _atackTime = time;
    }
    




}
