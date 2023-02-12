using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;

    public void takeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Health: " + health);
        if(health <= 0)
        {
            die();
        }
    }
    
    private void die()
    {
        Destroy(gameObject);
    }
}
