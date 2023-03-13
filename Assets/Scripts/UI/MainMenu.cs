using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _killCount;
    [SerializeField] private Text _winCount;
    [SerializeField] private Text _lossCount;
    private void Start()
    {
        Setup();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Demo");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void Setup()
    {
        _killCount.text = "Kills: " + GameManager.Instance.totalEntitiesSlayed;
        _winCount.text = "Wins: " + GameManager.Instance.wins;
        _lossCount.text = "Losses: " + GameManager.Instance.losses;
    }

    
}
