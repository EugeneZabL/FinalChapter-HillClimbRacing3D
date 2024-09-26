using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButonType : MonoBehaviour
{
    public void OnMainMenuGo()
    {
        Time.timeScale = 1;
        LoadManager.Instance.ChangeScreen("MainMenu");
    }
    
    public void OnRestartLevel()
    {
        Time.timeScale = 1;
        LoadManager.Instance.ChangeScreen("2D GraficUpdate");
    }    
}
