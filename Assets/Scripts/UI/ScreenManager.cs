using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public WinScreen winScreen;

    private void Start()
    {
        GameManager.Instance.SetScreenManager(this);
    }
}
