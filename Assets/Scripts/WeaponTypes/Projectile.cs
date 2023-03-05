using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private LayerMask _enemiesMask;
    private float _damage;

    
    private void Start()
    {
        Debug.Log("Projectile will deal: "+ _damage+" dmg");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
    private List<Enemy> _damagedEnemies = new List<Enemy>();

    private void Explode()
    {
        if (_explosion != null)
        {
            Destroy(Instantiate(_explosion, transform.position, Quaternion.identity), 1f);
        }
        Collider[] enemies = Physics.OverlapSphere(transform.position, _explosionRadius, _enemiesMask);
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i].GetComponent<Enemy>();
            if (enemy != null && !_damagedEnemies.Contains(enemy))
            {
                enemy.takeDamage(_damage);
                _damagedEnemies.Add(enemy);
            }
        }
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
