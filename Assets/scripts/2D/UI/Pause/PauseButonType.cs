using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButonType : MonoBehaviour
{
    public void OnMainMenuGo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void OnRestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("2D GraficUpdate");
    }    
}
