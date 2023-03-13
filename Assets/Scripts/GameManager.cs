using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private PlayerController playerController;
    public int entitiesSlaeyd = 0;
    public int totalEntitiesSlayed;
    public int wins;
    public int losses;

    public float playerMaxHP;
    public float playerCurrentHP;
    public bool gameOver = false;
    private ScreenManager screenManager;

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

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void SetScreenManager(ScreenManager screenManager)
    {
        this.screenManager = screenManager;
    }

    public void InitializePlayerStats(float maxHP)
    {
        playerMaxHP = maxHP;
        playerCurrentHP = playerMaxHP;
    }
    private void GameOver()
    {
        if (gameOver)
        {
            screenManager.gameOverScreen.Setup();
            losses++;
            TotalKillCount();
        }
    }

    private void Win()
    {
        if(entitiesSlaeyd == 10)
        {
            screenManager.winScreen.Setup();
            wins++;
            TotalKillCount();
        }
    }

    public void PlayerTakeDamage(float damage)
    {
        if(playerCurrentHP >= 0)
        {
            playerCurrentHP -= damage;
        }
        else
        {
            gameOver = true;
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
        Win();
    }

    public void TotalKillCount()
    {
        totalEntitiesSlayed += entitiesSlaeyd;
        
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("TotalKillCount",totalEntitiesSlayed);
        PlayerPrefs.SetInt("WinCount", wins);
        PlayerPrefs.SetInt("LossCount", losses);
    }

    public void LoadData()
    {
        totalEntitiesSlayed = PlayerPrefs.GetInt("TotalKillCount",0);
        wins = PlayerPrefs.GetInt("WinCount", 0);
        losses = PlayerPrefs.GetInt("LossCount", 0);
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
