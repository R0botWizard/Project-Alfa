using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Text score;
    public void Setup()
    {
        gameObject.SetActive(true);
        score.text = "Enemies slayed: "+GameManager.Instance.entitiesSlaeyd;
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Demo");
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.entitiesSlaeyd = 0;
    }
    
}
