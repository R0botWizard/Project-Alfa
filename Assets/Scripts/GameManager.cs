using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private PlayerController playerController;
    public int entitiesSlaeyd = 0;

    public float playerMaxHP;
    public float playerCurrentHP;
    public bool gameOver = false;
    

    private GameManager()
    {

    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            if (instance == null)
            {
                GameObject gameObject = new GameObject("GameManager");
                instance = gameObject.AddComponent<GameManager>();
            }

            return instance;
        }
    }

    private void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        playerController = FindObjectOfType<PlayerController>();
    }

    public void InitializePlayerStats(float maxHP)
    {
        playerMaxHP = maxHP;
        playerCurrentHP = playerMaxHP;
    }
    private void GameOver()
    {
        gameOver = true;
    }

    public void PlayerTakeDamage(float damage)
    {
        if(playerCurrentHP > 0)
        {
            playerCurrentHP -= damage;
        }
        else
        {
            GameOver();
        }
        
    }
    
    public Vector3 GetPlayerPosition()
    {
        return playerController.transform.position;
    }

    

    public void KillCount()
    {
        entitiesSlaeyd++;
    }

}
