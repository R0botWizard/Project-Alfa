using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Text score;
    public void Setup()
    {
        gameObject.SetActive(true);
        score.text = "Enemies slayed: " + GameManager.Instance.entitiesSlaeyd;
        Time.timeScale = 0f;
    }
    public void ContinueButton()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.entitiesSlaeyd = 0;
    }
}
